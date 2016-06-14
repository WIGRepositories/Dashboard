#include "posapi.h"
#include "font.h"

#include <stdarg.h>

#include "public.h"



INT32   PromptChnFlag = OFF;


//==================define scroll display var===================
#define     MAX_DISP_LINE       8
typedef struct
{
    uint32_t    Mode;
    uint32_t    valid;
    int8_t      Data[32];
}LineDataStrc;

LineDataStrc        LineData[MAX_DISP_LINE];
int32_t             CurDispLine=0;


UINT32 StrToLong(const UINT8 *buff2)  // �ַ���ת������
{
	UINT32   tmp = 0;

	tmp = buff2[0];
	tmp <<= 8;
	tmp += buff2[1];
	tmp <<= 8;
	tmp += buff2[2];
	tmp <<= 8;
	tmp += buff2[3];

	return tmp;
}

void LongToStr(UINT32 LongDat, UINT8 *buff2) // ������ת�ַ���
{
	buff2[3] = (UINT8)LongDat;
	LongDat >>= 8;

	buff2[2] = (UINT8)LongDat;
	LongDat >>= 8;

	buff2[1] = (UINT8)LongDat;
	LongDat >>= 8;

	buff2[0]=(UINT8)LongDat;
}

UINT16 StrToUINT16(const UINT8 *buff2)
{
	UINT16   tmp = 0;

	tmp = buff2[0];
	tmp <<= 8;
	tmp += buff2[1];
	return tmp;
}

void UINT16ToStr(UINT16 Num, UINT8 *buff2)
{
	buff2[1] = (UINT8)Num;
	Num >>= 8;
	buff2[0]=(UINT8)Num;
}

INT32 vTwoOne(UINT8 *in, UINT8 *out, INT32 in_len)
{
	INT32   i;

	for(i=0; i<in_len; i++)
	{
        if((in[i]>='0') && (in[i]<='9'))
        {
            out[i/2] = (out[i/2] & 0xF0) | ((in[i] - '0') & 0x0F);
        }
        else if((in[i]>='A') && (in[i]<='F'))
        {
            out[i/2] = (out[i/2] & 0xF0) | ((in[i] - 'A' + 0x0A) & 0x0F);
        }
        else if((in[i]>='a') && (in[i]<='f'))
        {
            out[i/2] = (out[i/2] & 0xF0) | ((in[i] - 'a' + 0x0A) & 0x0F);
        }
        else
        {
            return(ERROR);
        }
        if(i%2 == 0)
        {
            out[i/2] = out[i/2] << 4;
        }
	}
    return(OK);
}

void vOneTwo(UINT8 *in, UINT8 *out, INT32 in_len)
{
	INT32   i;

	for(i=in_len; i>0; i--)
	{
        if((in[i-1] & 0x0F) <= 0x09)
        {
            out[(i-1)*2+1] = (in[i-1] & 0x0F) + '0';
        }
        else
        {
            out[(i-1)*2+1] = (in[i-1] & 0x0F) - 0x0A + 'A';
        }

        if((in[i-1]>>4) <= 0x09)
        {
            out[(i-1)*2] = (in[i-1]>>4) + '0';
        }
        else
        {
            out[(i-1)*2] = (in[i-1]>>4) - 0x0A + 'A';
        }
	}
}

void XorBlock(UINT8 *InBlock1, UINT8 *InBlock2, UINT8 *OutBlock, INT32 Len)
{
    INT32   i;

    for(i=0; i<Len; i++)
    {
        OutBlock[i] = InBlock1[i] ^ InBlock2[i];
    }
}


void InitPromptLanguage(void)
{
    INT8    CurFontName[64];
    INT8    CurFontChar[64];
    INT32   CurFontStyle, CurFontSize;

    memset(CurFontName, 0x00, sizeof(CurFontName));
    memset(CurFontChar, 0x00, sizeof(CurFontChar));
    lcdGetCurFont(CurFontName, CurFontChar, &CurFontStyle, &CurFontSize, SET_PRIMARY_FONT);
    if(strcmp(CurFontChar, FONT_CHARSET_GB2312) == 0
        || strcmp(CurFontChar, FONT_CHARSET_GB18030) == 0)
    {
        PromptChnFlag = ON;
    }
    else
    {
        PromptChnFlag = OFF;
    }
}

int32_t PromptLangSet(void)
{
    return(PromptChnFlag);
}

void BeepErr(void)
{
    sysBeef(5, 1000);
}


int32_t SelectMenu(int32_t StartLine, int32_t EndLine, int32_t DispMode, int32_t TimeOutMs, int32_t PromptNum, int32_t PreCursor, uint8_t *pPrompt[])
{
    int32_t   Cursor, Begin;
    int32_t   Height, i, LcdMode, DispLine;
    int32_t   iRet;

    if(PreCursor>=0 && PreCursor<PromptNum)
    {
        Cursor = PreCursor;
    }
    else
    {
        Cursor = 0;
    }
    Begin  = Cursor;
    EndLine = MIN(EndLine, 7);
    EndLine = MAX(EndLine, 0);
    StartLine = MIN(EndLine, StartLine);
    StartLine = MAX(StartLine, 0);

    if(DispMode & DISP_CFONT)
    {
        Height = 2;
    }
    else
    {
        Height = 1;
    }

    if((EndLine+1-StartLine) < Height)
    {
        return(KB_ERROR);
    }
    while(1)
    {
        lcdClrLine(StartLine, EndLine);
        DispLine = StartLine;
        for(i=Begin; i<PromptNum; i++)
        {
            if(i == Cursor)
            {
                LcdMode = DispMode ^ DISP_REVERSE;
            }
            else
            {
                LcdMode = DispMode;
            }
            lcdDispMultiLang(0, DispLine, LcdMode, pPrompt[i*2], pPrompt[i*2+1]);
            DispLine += Height;
            if(DispLine+Height-1 > 7)
            {
                break;
            }
        }
        if(Begin != 0)
        {
            lcdSetIcon(ICON_UP, OPENICON);
        }
        else
        {
            lcdSetIcon(ICON_UP, CLOSEICON);
        }
        if(i < PromptNum-1)
        {
            lcdSetIcon(ICON_DOWN, OPENICON);
        }
        else
        {
            lcdSetIcon(ICON_DOWN, CLOSEICON);
        }
        iRet = kbGetKeyMs(TimeOutMs);
        lcdSetIcon(ICON_DOWN, CLOSEICON);
        lcdSetIcon(ICON_UP, CLOSEICON);
        switch(iRet)
        {
        case KEY_ENTER:
            lcdClrLine(StartLine, EndLine);
            return(Cursor);
        case KEY_TIMEOUT:
            lcdClrLine(StartLine, EndLine);
            return(KB_TIMEOUT);
        case KEY_CANCEL:
            lcdClrLine(StartLine, EndLine);
            return(KB_CANCEL);
        case KEY_UP:
            Cursor--;
            if(Cursor < 0)
            {
                Cursor = PromptNum - 1;
                Begin  = Cursor + 1 - (EndLine+1-StartLine)/Height;
                Begin  = MAX(Begin, 0);
            }
            else if(Cursor < Begin)
            {
                //  Begin--;
                Begin = Cursor + 1 - (EndLine+1-StartLine)/Height;
                Begin  = MAX(Begin, 0);
            }
            break;
        case KEY_DOWN:
            Cursor++;
            if(Cursor >= PromptNum)
            {
                Cursor = 0;
                Begin  = 0;
            }
            else if(Cursor-Begin+1 > (EndLine+1-StartLine)/Height)
            {
                //  Begin++;
                Begin = Cursor;
            }
            break;
        default :
            break;
        }
    }
}

int32_t SelectProMenu(int32_t StartLine, int32_t EndLine, int32_t DispMode, int32_t TimeOutMs, menu_unit_t menu_unit[])
{
    int32_t     Cursor;
    int32_t     Begin;
    int32_t     Height, i, LcdMode, DispLine;
    int32_t     iRet;
    int32_t     PromptNum;
    int32_t     CursorDispLine;

    if(menu_unit == NULL)
    {
        return(KB_ERROR);
    }

    EndLine = MIN(EndLine, 7);
    EndLine = MAX(EndLine, 0);
    StartLine = MIN(EndLine, StartLine);
    StartLine = MAX(StartLine, 0);

    if(DispMode & DISP_CFONT)
    {
        Height = 2;
    }
    else
    {
        Height = 1;
    }

    if((EndLine+1-StartLine) < Height)
    {
        return(KB_ERROR);
    }

    Cursor = 0;
    PromptNum = 0;
    CursorDispLine = StartLine;

    while(1)
    {
        if((menu_unit[PromptNum].prompt_chn == NULL) && (menu_unit[PromptNum].prompt_en == NULL))
        {
            break;
        }
        if(menu_unit[PromptNum].selectline >= 0)
        {
            Cursor = PromptNum;
            CursorDispLine = menu_unit[PromptNum].selectline;
            CursorDispLine = MAX(StartLine, CursorDispLine);
            CursorDispLine = MIN(EndLine+1-Height, CursorDispLine);
        }
        PromptNum++;
    }

    Begin = Cursor;
    while(Begin > 0)
    {
        CursorDispLine -= Height;
        if(CursorDispLine < StartLine)
        {
            break;
        }
        Begin--;
    }

    while(1)
    {
        lcdClrLine(StartLine, EndLine);
        DispLine = StartLine;
        for(i=Begin; i<PromptNum; i++)
        {
            if(i == Cursor)
            {
                LcdMode = DispMode ^ DISP_REVERSE;
                menu_unit[i].selectline = DispLine;
            }
            else
            {
                LcdMode = DispMode;
                menu_unit[i].selectline = -1;
            }
            lcdDispMultiLang(0, DispLine, LcdMode, menu_unit[i].prompt_chn, menu_unit[i].prompt_en);
            DispLine += Height;
            if(DispLine+Height-1 > EndLine)
            {
                break;
            }
        }
        if(Begin != 0)
        {
            lcdSetIcon(ICON_UP, OPENICON);
        }
        else
        {
            lcdSetIcon(ICON_UP, CLOSEICON);
        }
        if(i < PromptNum-1)
        {
            lcdSetIcon(ICON_DOWN, OPENICON);
        }
        else
        {
            lcdSetIcon(ICON_DOWN, CLOSEICON);
        }
        iRet = kbGetKeyMs(TimeOutMs);
        lcdSetIcon(ICON_DOWN, CLOSEICON);
        lcdSetIcon(ICON_UP, CLOSEICON);
        switch(iRet)
        {
        case KEY_ENTER:
            lcdClrLine(StartLine, EndLine);
            return(Cursor);
        case KEY_TIMEOUT:
            lcdClrLine(StartLine, EndLine);
            return(KB_TIMEOUT);
        case KEY_CANCEL:
            lcdClrLine(StartLine, EndLine);
            return(KB_CANCEL);
        case KEY_UP:
            menu_unit[Cursor].selectline = -1;
            Cursor--;
            if(Cursor < 0)
            {
                Cursor = PromptNum - 1;
                Begin  = Cursor + 1 - (EndLine+1-StartLine)/Height;
                Begin  = MAX(Begin, 0);
            }
            else if(Cursor < Begin)
            {
                //  Begin--;
                Begin = Cursor + 1 - (EndLine+1-StartLine)/Height;
                Begin  = MAX(Begin, 0);
            }
            break;
        case KEY_DOWN:
            menu_unit[Cursor].selectline = -1;
            Cursor++;
            if(Cursor >= PromptNum)
            {
                Cursor = 0;
                Begin  = 0;
            }
            else if(Cursor-Begin+1 > (EndLine+1-StartLine)/Height)
            {
                //  Begin++;
                Begin = Cursor;
            }
            break;
        default :
            break;
        }
    }
}
//====================ycy: scroll display=====================
void ScrollClr(void)
{
    int32_t     line;

    CurDispLine = 0;
    for(line=0; line<MAX_DISP_LINE; line++)
    {
        LineData[line].Mode  = 0;
        LineData[line].valid = OFF;
        memset(LineData[line].Data, 0, sizeof(LineData[line].Data));
    }
    lcdCls();
}
void ScrollDisplay(uint32_t Mode, char *str, ...)
{
    va_list     marker;
    uint8_t     glBuff[8192];
    uint32_t    charnum,linecharnum;
    uint32_t    pixnum;
    int32_t     begin, end, temp;

    memset(glBuff, 0, sizeof(glBuff));
    va_start( marker, str);
    vsnprintf(glBuff, sizeof(glBuff)-4, str, marker);
    va_end( marker );

    LineData[CurDispLine].Mode  = Mode;
    LineData[CurDispLine].valid = ON;
    memset(LineData[CurDispLine].Data, 0, sizeof(LineData[CurDispLine].Data));
    linecharnum = 0;
    pixnum      = 0;
    charnum     = 0;
    while(1)
    {
        if(glBuff[charnum] == 0)    break;
        if(glBuff[charnum] == '\n')
        {
            charnum++;
            CurDispLine++;
            if(CurDispLine >= MAX_DISP_LINE) CurDispLine = 0;
            LineData[CurDispLine].Mode  = Mode;
            LineData[CurDispLine].valid = ON;
            memset(LineData[CurDispLine].Data, 0, sizeof(LineData[CurDispLine].Data));
            linecharnum = 0;
            pixnum      = 0;
            continue;
        }
        if(Mode & DISP_CFONT) //  CFont
        {
            if(glBuff[charnum] > 0x80)
            {
                if((128-pixnum) < 16)
                {
                    CurDispLine++;
                    if(CurDispLine >= MAX_DISP_LINE) CurDispLine = 0;
                    LineData[CurDispLine].Mode  = Mode;
                    LineData[CurDispLine].valid = ON;
                    memset(LineData[CurDispLine].Data, 0, sizeof(LineData[CurDispLine].Data));
                    linecharnum = 0;
                    pixnum      = 0;
                    continue;
                }
                else
                {
                    LineData[CurDispLine].Data[linecharnum] = glBuff[charnum];
                    linecharnum++;
                    charnum++;
                    LineData[CurDispLine].Data[linecharnum] = glBuff[charnum];
                    linecharnum++;
                    charnum++;
                    pixnum += 16;
                }
            }
            else
            {
                if((128-pixnum) < 8)
                {
                    CurDispLine++;
                    if(CurDispLine >= MAX_DISP_LINE) CurDispLine = 0;
                    LineData[CurDispLine].Mode  = Mode;
                    LineData[CurDispLine].valid = ON;
                    memset(LineData[CurDispLine].Data, 0, sizeof(LineData[CurDispLine].Data));
                    linecharnum = 0;
                    pixnum      = 0;
                    continue;
                }
                else
                {
                    LineData[CurDispLine].Data[linecharnum] = glBuff[charnum];
                    linecharnum++;
                    charnum++;
                    pixnum += 8;
                }
            }
        }
        else
        {
            if(glBuff[charnum] > 0x80)
            {
                glBuff[charnum] = ' ';
            }
            if((128-pixnum) < 6)
            {
                CurDispLine++;
                if(CurDispLine >= MAX_DISP_LINE) CurDispLine = 0;
                LineData[CurDispLine].Mode  = Mode;
                LineData[CurDispLine].valid = ON;
                memset(LineData[CurDispLine].Data, 0, sizeof(LineData[CurDispLine].Data));
                linecharnum = 0;
                pixnum      = 0;
                continue;
            }
            else
            {
                LineData[CurDispLine].Data[linecharnum] = glBuff[charnum];
                linecharnum++;
                charnum++;
                pixnum += 6;
            }
        }
    }

    end   = CurDispLine;
    begin = end;
    temp  = 0;
    while(2)
    {
        if(LineData[begin].Mode & DISP_CFONT)
            temp += 2;
        else    temp++;
        if(temp > MAX_DISP_LINE)
        {
            begin++;
            if(begin >= MAX_DISP_LINE)   begin = 0;
            break;
        }
        if(begin == 0)  begin = MAX_DISP_LINE-1;
        else            begin--;
        if(LineData[begin].valid == OFF)
        {
            begin++;
            if(begin >= MAX_DISP_LINE)   begin = 0;
            break;
        }
    }

    lcdCls();
    temp = 0;
    while(3)
    {
        lcdDisplay(0, temp, LineData[begin].Mode, "%s", LineData[begin].Data);
        if(LineData[begin].Mode & DISP_CFONT)     temp += 2;
        else    temp++;
        if(begin == end)    break;
        begin++;
        if(begin >= MAX_DISP_LINE)   begin = 0;
    }
    CurDispLine++;
    if(CurDispLine >= MAX_DISP_LINE) CurDispLine = 0;
}

void ShowPrintStatus(int32_t Col, int32_t Line, uint32_t DispMode, int32_t iRet)
{
    switch(iRet)
    {
    case PRN_OK:
        lcdDispMultiLang(Col, Line, DispMode, "��ӡ�ɹ�", "Print OK");
        break;
    case PRN_BUSY:
        lcdDispMultiLang(Col, Line, DispMode, "��ӡ��æ", "Print BUSY");
        break;
    case PRN_PAPEROUT:
        lcdDispMultiLang(Col, Line, DispMode, "ȱֽ", "No Paper");
        break;
    case PRN_WRONG_PACKAGE:
        lcdDispMultiLang(Col, Line, DispMode, "���ݴ���", "Data Error");
        break;
    case PRN_FAULT:
        lcdDispMultiLang(Col, Line, DispMode, "��ӡ����", "Print Error");
        break;
    case PRN_TOOHEAT:
        lcdDispMultiLang(Col, Line, DispMode, "����", "Over Heat");
        break;
    case PRN_UNFINISHED:
        lcdDispMultiLang(Col, Line, DispMode, "δ��ӡ���", "Unfinished");
        break;
    case PRN_NOFONTLIB:
        lcdDispMultiLang(Col, Line, DispMode, "�Ҳ����ֿ�", "No Font Lib");
        break;
    case PRN_OUTOFMEMORY:
        lcdDispMultiLang(Col, Line, DispMode, "��ӡ������", "Prn Buffer Full");
        break;
    default:
        lcdDispMultiLang(Col, Line, DispMode, "δ֪����:%04XH", "Unknown :%04XH", iRet);
        break;
    }
}

void ShowFileTransRet(int32_t Col, int32_t Line, uint32_t DispMode, int32_t iRet)
{
    switch(iRet)
    {
    case LD_OK:             //  �ɹ�
        lcdDispMultiLang(Col, Line, DispMode, "�ɹ�:%02XH", "OK:%02XH", iRet);
        break;
    case LDERR_GENERIC:     //  ʧ��
        lcdDispMultiLang(Col, Line, DispMode, "ʧ��:%02XH", "ERROR:%02XH", iRet);
        break;
    case LDERR_BAUDERR:     //  �����ʲ�֧��
        lcdDispMultiLang(Col, Line, DispMode, "���ʲ�֧��:%02XH", "BAUD ERR:%02XH", iRet);
        break;
    case LDERR_INVALIDTIME: //  �Ƿ�ʱ��
        lcdDispMultiLang(Col, Line, DispMode, "�Ƿ�ʱ��:%02XH", "TIME ERR:%02XH", iRet);
        break;
    case LDERR_CLOCKHWERR:  //  ʱ��Ӳ������
        lcdDispMultiLang(Col, Line, DispMode, "RTC����:%02XH", "RTC ERR:%02XH", iRet);
        break;
    case LDERR_SIGERR:      //  ��֤ǩ��ʧ��
        lcdDispMultiLang(Col, Line, DispMode, "ǩ������:%02XH", "SIG ERR:%02XH", iRet);
        break;
    case LDERR_TOOMANYAPP:  //  Ӧ��̫�࣬�������ظ���Ӧ��
        lcdDispMultiLang(Col, Line, DispMode, "Ӧ��̫��:%02XH", "MAX APP:%02XH", iRet);
        break;
    case LDERR_TOOMANYFILES://  �ļ�̫�࣬�������ظ����ļ�
        lcdDispMultiLang(Col, Line, DispMode, "�ļ�̫��:%02XH", "MAX FILE:%02XH", iRet);
        break;
    case LDERR_NOAPP:       //  ָ��Ӧ�ò�����
        lcdDispMultiLang(Col, Line, DispMode, "û��Ӧ��:%02XH", "NO APP:%02XH", iRet);
        break;
    case LDERR_UNKNOWNAPP:  //  ����ʶ���Ӧ������
        lcdDispMultiLang(Col, Line, DispMode, "δ֪Ӧ��:%02XH", "UNKNOWN APP:%02XH", iRet);
        break;
    case LDERR_SIGTYPEERR:  //  ǩ�����������ͺ������������Ͳ�һ��
        lcdDispMultiLang(Col, Line, DispMode, "���ʹ���:%02XH", "TYPE ERR:%02XH", iRet);
        break;
    case LDERR_SIGAPPERR:   //  ǩ��������������Ӧ��������������Ӧ������һ��
        lcdDispMultiLang(Col, Line, DispMode, "Ӧ������:%02XH", "NAME ERR:%02XH", iRet);
        break;
    case LDERR_WRITEFILEFAIL:   //  �ļ�д��ʧ��
        lcdDispMultiLang(Col, Line, DispMode, "д�����:%02XH", "WRITE ERR:%02XH", iRet);
        break;
    case LDERR_NOSPACE:     //  û���㹻�Ŀռ�
        lcdDispMultiLang(Col, Line, DispMode, "�ռ���:%02XH", "NO SPACE:%02XH", iRet);
        break;
    case LDERR_RESENDLASTPACK:  //  У�����Ҫ�����´������һ����
        lcdDispMultiLang(Col, Line, DispMode, "���ݰ���:%02XH", "PACK ERR:%02XH", iRet);
        break;
    case LDERR_UNSUPPORTEDCMD:  //  ��֧�ָ�����
        lcdDispMultiLang(Col, Line, DispMode, "���֧��:%02XH", "CMD ERR:%02XH", iRet);
        break;
    default:
        lcdDispMultiLang(Col, Line, DispMode, "δ֪:%08XH", "Unknown:%08XH", iRet);
        break;
    }
}


INT32 ShowPedRet(INT32 DispCol, INT32 DispLine, INT32 DispMode, INT32 OkTimeOutMs, INT32 ErrTimeOutMs, INT32  RetCode)
{
    switch(RetCode)
    {
    case PED_RET_OK:
        lcdDisplay(DispCol, DispLine, DispMode, "RET %02XH:OK", RetCode);
        if(OkTimeOutMs != 0)
        {
            kbFlush();
            sysBeef(2, 500);
        }
        return(kbGetKeyMs(OkTimeOutMs));
    case PED_RET_LOCKED:
        lcdDisplay(DispCol, DispLine, DispMode, "RET %02XH:Ped Locked", RetCode);
        break;
    case PED_RET_ERROR:
        lcdDisplay(DispCol, DispLine, DispMode, "RET %02XH:Error", RetCode);
        break;
    case PED_RET_COMMERR:
        lcdDisplay(DispCol, DispLine, DispMode, "RET %02XH:Comm Err", RetCode);
        break;
    case PED_RET_NEEDAUTH:
        lcdDisplay(DispCol, DispLine, DispMode, "RET %02XH:NeedAuth", RetCode);
        break;
    case PED_RET_AUTHERR:
        lcdDisplay(DispCol, DispLine, DispMode, "RET %02XH:Auth Err", RetCode);
        break;
    case PED_RET_APPTSSAKERR:
        lcdDisplay(DispCol, DispLine, DispMode, "RET %02XH:AppTssakErr", RetCode);
        break;
    case PED_RET_PEDTSSAKERR:
        lcdDisplay(DispCol, DispLine, DispMode, "RET %02XH:PedTssakErr", RetCode);
        break;
    case PED_RET_KEYINDEXERR:
        lcdDisplay(DispCol, DispLine, DispMode, "RET %02XH:KeyID Err", RetCode);
        break;
    case PED_RET_NOKEY:
        lcdDisplay(DispCol, DispLine, DispMode, "RET %02XH:No Key", RetCode);
        break;
    case PED_RET_KEYFULL:
        lcdDisplay(DispCol, DispLine, DispMode, "RET %02XH:Key Full", RetCode);
        break;
    case PED_RET_KEYLENERR:
        lcdDisplay(DispCol, DispLine, DispMode, "RET %02XH:KeyLen Err", RetCode);
        break;
    case PED_RET_NOPIN:
        lcdDisplay(DispCol, DispLine, DispMode, "RET %02XH:No PIN", RetCode);
        if(OkTimeOutMs != 0)
        {
            kbFlush();
            sysBeef(2, 500);
        }
        return(kbGetKeyMs(OkTimeOutMs));
    case PED_RET_CANCEL:
        lcdDisplay(DispCol, DispLine, DispMode, "RET %02XH:Cancel", RetCode);
        break;
    case PED_RET_TIMEOUT:
        lcdDisplay(DispCol, DispLine, DispMode, "RET %02XH:TimeOut", RetCode);
        break;
    case PED_RET_NEEDWAIT:
        lcdDisplay(DispCol, DispLine, DispMode, "RET %02XH:Need Wait", RetCode);
        break;
    case PED_RET_KEYOVERFLOW:
        lcdDisplay(DispCol, DispLine, DispMode, "RET %02XH:Over Flow", RetCode);
        break;
    case PED_RET_NOCARD:
        lcdDisplay(DispCol, DispLine, DispMode, "RET %02XH:No IC Card", RetCode);
        break;
    case PED_RET_ICCNOTPWRUP:
        lcdDisplay(DispCol, DispLine, DispMode, "RET %02XH:Not PwrUp", RetCode);
        break;
    case PED_RET_PARITYERR:
        lcdDisplay(DispCol, DispLine, DispMode, "RET %02XH:Parity Err", RetCode);
        break;
    default :
        break;
    }
    if(ErrTimeOutMs != 0)
    {
        kbFlush();
        sysBeef(5, 1000);
    }
    return(kbGetKeyMs(ErrTimeOutMs));
}

INT32 ShowKeyBoardRet(INT32 DispCol, INT32 DispLine, INT32 DispMode, INT32  RetCode)
{
    switch(RetCode)
    {
    case KEY0 ... KEY9:
        lcdDisplay(DispCol, DispLine, DispMode, "KEY:%c--%02XH", RetCode, RetCode);
        break;
    case KEY_ALPHA:
        lcdDisplay(DispCol, DispLine, DispMode, "KEY:ALPHA--%02XH", RetCode);
        break;
    case KEY_BACKSPACE:
        lcdDisplay(DispCol, DispLine, DispMode, "KEY:BACK--%02XH", RetCode);
        break;
    case KEY_CANCEL:
        lcdDisplay(DispCol, DispLine, DispMode, "KEY:CANCEL--%02XH", RetCode);
        break;
    case KEY_CLEAR:
        lcdDisplay(DispCol, DispLine, DispMode, "KEY:CLEAR--%02XH", RetCode);
        break;
    case KEY_DOWN:
        lcdDisplay(DispCol, DispLine, DispMode, "KEY:DOWN--%02XH", RetCode);
        break;
    case KEY_ENTER:
        lcdDisplay(DispCol, DispLine, DispMode, "KEY:ENTER--%02XH", RetCode);
        break;
    case KEY_FN:
        lcdDisplay(DispCol, DispLine, DispMode, "KEY:FUNC--%02XH", RetCode);
        break;
    case KEY_INVALID:
        lcdDisplay(DispCol, DispLine, DispMode, "KEY:INVALID--%02XH", RetCode);
        break;
    case KEY_MENU:
        lcdDisplay(DispCol, DispLine, DispMode, "KEY:MENU--%02XH", RetCode);
        break;
    case KEY_PRNUP:
        lcdDisplay(DispCol, DispLine, DispMode, "KEY:FEED--%02XH", RetCode);
        break;
    case KEY_TIMEOUT:
        lcdDisplay(DispCol, DispLine, DispMode, "KEY:TIMEOUT--%02XH", RetCode);
        break;
    case KEY_UP:
        lcdDisplay(DispCol, DispLine, DispMode, "KEY:UP--%02XH", RetCode);
        break;
    }
    return(0);
}




tWnet_ret   WnetRet[] =
{
//  wnet
    {NET_OK,                "OK",           "�ɹ�"},
    {NET_ERR_RSP,           "RSP ERROR",    "�������Ӧ"},
    {NET_ERR_NOSIM,         "NO SIM",       "û��SIM��"},
    {NET_ERR_PIN,           "NEED PIN",     "��Ҫ��֤PIN"},
    {NET_ERR_PUK,           "NEED PUK",     "��Ҫ��֤PUK"},
    {NET_ERR_PWD,           "PWD ERR",      "�������"},
    {NET_ERR_SIMDESTROY,    "SIM DESTROY",  "SIM�ٻ�"},
    {NET_ERR_CSQWEAK,       "CSQ TOO WEAK", "�ź�̫��"},
    {NET_ERR_LINKCLOSED,    "LINK CLOSED",  "���ӶϿ�"},
    {NET_ERR_LINKOPENING,   "LINK OPENING", "��������"},
    {NET_ERR_DETTACHED,     "DETTACHED",    "δע������"},
    {NET_ERR_ATTACHING,     "ATTACHING",    "��Ѱ����"},
    {NET_ERR_EMERGENCY,     "EMERGENCY",    "����״̬"},
    {NET_ERR_RING,          "RING...",      "������"},
    {NET_ERR_BUSY,          "BUSY NOW",     "����ͨ��"},
    {NET_ERR_DIALING,       "DIALING...",   "������"},
    {NET_ERR_UNKNOWN,       "UNKNOWN",      "δ֪����"},
    {NET_ERR_ABNORMAL,      "ABNORMAL",     "�쳣����"},
    {NET_ERR_NOMODULE,      "NO MODULE",    "��ģ��"},
//  errno.h
    {ENOMEM,                "NO MEM",       "�ڴ治��"},
    {EFAULT,                "FAULT",        "����"},
    {EINVAL,                "INVALID PARA", "��Ч����"},
    {ENODATA,               "NO DATA",      "û������"},
    {ENONET,                "NO NET",       "û������"},
    {ENOLINK,               "NO LINK",      "û������"},
    {ECOMM,                 "SEND ERR",     "���ʹ���"},
    {EPROTO,                "PROTO ERR",    "Э�����1"},
    {EOVERFLOW,             "OVERFLOW",     "���"},
    {ENOTSOCK,              "NOT SOCK",     "û��SOCK"},
    {EPROTOTYPE,            "PROTO WRONG",  "Э�����2"},
    {ENOPROTOOPT,           "NO PROTO OPT", "��Э��ѡ��"},
    {EPROTONOSUPPORT,       "PROTO NO SUP", "Э�鲻֧��"},
    {EPFNOSUPPORT,          "PROTO FML",    "Э����δ֪"},
    {ENETDOWN,              "NET DOWN",     "����Ͽ�"},
    {ENETUNREACH,           "NET UNREACH",  "���粻�ɴ�"},
    {ENETRESET,             "NET DROPPED",  "���縴λ"},
    {ECONNRESET,            "CONN RESET",   "���Ӹ�λ"},
    {EISCONN,               "IS CONN",      "������"},
    {ENOTCONN,              "NOT CONN",     "δ����"},
    {ESHUTDOWN,             "SHUT DOWN",    "�Ͽ�"},
    {ETIMEDOUT,             "TIMEOUT",      "��ʱ"},
    {ECONNREFUSED,          "REFUSED",      "���ӱ��ܾ�"},
    {EHOSTDOWN,             "HOST DOWN",    "�����Ͽ�"},
    {EHOSTUNREACH,          "HOST UNREACH", "�������ɴ�"},
//  wifi
    {EWIFI_BUSY,            "I/BUSY",       "I/BUSY"},
    {EWIFI_DONE,            "I/DONE",       "I/DONE"},
    {EWIFI_ONLINE,          "I/ONLINE",     "I/ONLINE"},
    {EWIFI_OFFLINE,         "I/OFFLINE",    "I/OFFLINE"},
    {EWIFI_RCV,             "I/RCV",        "I/RCV"},
    {EWIFI_PART,            "I/PART",       "I/PART"},
    {EWIFI_EOP,             "I/EOP",        "I/EOP"},
    {EWIFI_EOM,             "I/EOM",        "I/EOM"},
    {EWIFI_MBE,             "I/MBE",        "I/MBE"},
    {EWIFI_UPDATE,          "I/UPDATE",     "I/UPDATE"},
    {EWIFI_ILLDELIMITER,    "ILLDELIMITER", "�Ƿ��ָ���"},
    {EWIFI_ILLVAL,          "ILLVAL",       "�Ƿ�ֵ"},
    {EWIFI_EXPCR,           "EXPCR",        "ȱCR"},
    {EWIFI_EXPNUM,          "EXPNUM",       "ȱ����"},
    {EWIFI_EXPCRORCOMMA,    "EXPCRORCOMMA", "ȱCR�򶺺�"},
    {EWIFI_EXPDNS,          "EXPDNS",       "ȱDNS"},
    {EWIFI_EXPTILDE,        "EXP':'or'~'",  "ȱ':'��'~'"},
    {EWIFI_EXPSTR,          "EXP STRING",   "ȱ�ַ���"},
    {EWIFI_EXPEQL,          "EXP':'or'='",  "ȱ':'��'='"},
    {EWIFI_EXPTXT,          "EXP TEXT",     "ȱ�ı�����"},
    {EWIFI_SYNTAX,          "SYNTAX ERR",   "�﷨����"},
    {EWIFI_EXPCOMMA,        "EXP ','",      "ȱ','"},
    {EWIFI_ILLCMD,          "ILL CMD CODE", "������Ƿ�"},
    {EWIFI_SETPARA,         "SET PARA ERR", "���ò�����"},
    {EWIFI_GETPARA,         "GET PARA ERR", "��ȡ������"},
    {EWIFI_USERABORT,       "USER ABORT",   "�û�ȡ��"},
    {EWIFI_BUILDPPP,        "BUILD PPP",    "����PPP��"},
    {EWIFI_BUILDSMTP,       "BUILD SMTP",   "����SMTP��"},
    {EWIFI_BUILDPOP3,       "BUILD POP3",   "����POP3��"},
    {EWIFI_MAXMINE,         "MAX MIME",     "MIME����"},
    {EWIFI_INTMEMFAIL,      "INTMEM FAIL",  "�ڲ��洢��"},
    {EWIFI_USERABORTSYS,    "USERABORTSYS", "ȡ��ϵͳ"},
    {EWIFI_HFCCTSH,         "FLC CTSH ERR", "����CTSH��"},
    {EWIFI_USERABORTDDD,    "ABORT BY ---", "��---ȡ��"},
    {EWIFI_RES2065,         "RES: 2065",    "Ԥ��:2065"},
    {EWIFI_RES2066,         "RES: 2066",    "Ԥ��:2066"},
    {EWIFI_CMDIGNORE,       "CMD IGNORE",   "�������"},
    {EWIFI_SNEXIST,         "SN EXIST",     "SN�Ѵ���"},
    {EWIFI_HOSTTO,          "HOST TIMEOUT", "������ʱ"},
    {EWIFI_MODEMRESPOND,    "MDM RSP FAIL", "MDM��Ӧ��"},
    {EWIFI_NODIALTONE,      "NO DIAL TONE", "�޲�����"},
    {EWIFI_NOCARRIER,       "NO CARRIER",   "���ز�"},
    {EWIFI_DIALFAIL,        "DIAL FAILED",  "����ʧ��"},
    {EWIFI_CONNLOST,        "CONNECT LOST", "����"},
    {EWIFI_ACCESSISP,       "ACCESS ISP",   "����ISP��"},
    {EWIFI_LOCPOP3,         "LOCATE POP3",  "��λPOP3��"},
    {EWIFI_POP3TO,          "POP3 TIMEOUT", "POP3��ʱ"},
    {EWIFI_ACCESSPOP3,      "ACCESS POP3",  "����POP3��"},
    {EWIFI_POP3FAIL,        "POP3 FAILED",  "POP3��"},
    {EWIFI_NOSUITMSG,       "NO SUIT MSG",  "����û��Ϣ"},
    {EWIFI_LOCSMTP,         "LOCATE SMTP",  "��λSMTP��"},
    {EWIFI_SMTPTO,          "SMTP TIMEOUT", "SMTP��ʱ"},
    {EWIFI_SMTPFAIL,        "SMTP FAILED",  "SMTP��"},
    {EWIFI_RES2084,         "RES: 2084",    "Ԥ��:2084"},
    {EWIFI_RES2085,         "RES: 2085",    "Ԥ��:2085"},
    {EWIFI_WRINTPARA,       "WRITE PARA",   "д�������"},
    {EWIFI_WEBIPREG,        "REG WEB ERR",  "ע��WEB��"},
    {EWIFI_WEBIPREG,        "REG SOCK ERR", "ע��SOCK��"},
    {EWIFI_EMAILIPREG,      "REG MAIL ERR", "ע��MAIL��"},
    {EWIFI_IPREGFAIL,       "REG IP ERR",   "ע��IP��"},
    {EWIFI_RES2091,         "RES: 2091",    "Ԥ��:2091"},
    {EWIFI_RES2092,         "RES: 2092",    "Ԥ��:2092"},
    {EWIFI_RES2093,         "RES: 2093",    "Ԥ��:2093"},
    {EWIFI_ONLINELOST,      "LOST-REEST",   "��������"},
    {EWIFI_REMOTELOST,      "REMOTE LOST",  "��������"},
    {EWIFI_RES2098,         "RES: 2098",    "Ԥ��:2098"},
    {EWIFI_RES2099,         "RES: 2099",    "Ԥ��:2099"},
    {EWIFI_DEFAULTRES,      "RESTORE ERR",  "�ָ�Ԥ���"},
    {EWIFI_NOISPDEF,        "NO ISP No.",   "��ISP����"},
    {EWIFI_NOUSRNDEF,       "NO USRN",      "��USRN"},
    {EWIFI_NOPWDENTER,      "NO PWD ENTER", "δ������"},
    {EWIFI_NODNSDEF,        "NO DNS",       "��DNS"},
    {EWIFI_NOPOP3DEF,       "NO POP3",      "��POP3"},
    {EWIFI_NOMBXDEF,        "NO MAILBOX",   "������"},
    {EWIFI_NOMPWDDEF,       "NO MPWD",      "����������"},
    {EWIFI_NOTOADEF,        "NO TOA",       "��TOA"},
    {EWIFI_NOREADEF,        "NO REA",       "��REA"},
    {EWIFI_NOSMTPDEF,       "NO SMTP",      "��SMTP"},
    {EWIFI_SDATAOVERFLOW,   "SDATA OVERF",  "SDATA���"},
    {EWIFI_ILLCMDMDM,       "ILL CMD MDM",  "��Ч����"},
    {EWIFI_FWUPDT,          "FW NOT UPDAT", "FWδ���"},
    {EWIFI_EMAILPARAUPDT,   "UPD MAILPARA", "MPARA����"},
    {EWIFI_SNETPARA,        "SNET PARA",    "ȱSNET����"},
    {EWIFI_PARSECA,         "ERR PARSE CA", "CA�﷨��"},
    {EWIFI_RES2117,         "RES: 2117",    "Ԥ��:2117"},
    {EWIFI_USRVPARA,        "NO USRV PARA", "��USRV����"},
    {EWIFI_WLPPSHORT,       "WLPP SHORT",   "����̫��"},
    {EWIFI_RES2120,         "RES: 2120",    "Ԥ��:2120"},
    {EWIFI_RES2121,         "RES: 2121",    "Ԥ��:2121"},
    {EWIFI_SNETHIF0,        "SNET:HIF=0",   "SNET:HIF=0"},
    {EWIFI_SNETBAUD,        "SNET:BAUD",    "SNET:����"},
    {EWIFI_SNETHIFPARA,     "SNET:HIF",     "SNET:HIF"},
    {EWIFI_NOSOCK,          "NO SOCK",      "��SOCK"},
    {EWIFI_SOCKEMPTY,       "SOCK EMPTY",   "SOCK��"},
    {EWIFI_SOCKUNUSE,       "SOCK NOT USE", "SOCKδʹ��"},
    {EWIFI_SOCKDOWN,        "SOCK DOWN",    "SOCK DOWN"},
    {EWIFI_NOAVAILDSOCK,    "NO VAIL SOCK", "����ЧSOCK"},
    {EWIFI_PPPOPEN,         "PPP OPEN ERR", "PPP�򿪴�"},
    {EWIFI_CREATSOCK,       "OPEN SOCK",    "SOCK�򿪴�"},
    {EWIFI_SOCKSEND,        "SOCK SND ERR", "SOCK���ʹ�"},
    {EWIFI_SOCKRECV,        "SOCK RCV ERR", "SOCK���մ�"},
    {EWIFI_PPPDOWN,         "PPP DOWN",     "PPP DOWN"},
    {EWIFI_SOCKFLUSH,       "SOCK FLUSH E", "SOCKˢ�´�"},
    {EWIFI_NOCARRIERSOCK,   "SOCK NO CARR", "SOCK���ز�"},
    {EWIFI_GENERALEXCEPT,   "GNRL EXCEPT",  "��ͨ����"},
    {EWIFI_OUTOFMEM,        "OUT OF MEM",   "�ڴ����"},
    {EWIFI_LOCPORTINUSE,    "PORT IN USE",  "�˿�����"},
    {EWIFI_LOADCA,          "SSL:LOAD CA",  "SSL:����CA"},
    {EWIFI_NEGSSL3,         "SSL:NEG ERR",  "SSL:Э�̴�"},
    {EWIFI_ILLSSLSOCK,      "SSL:ILL SOCK", "SSL:�˿ڴ�"},
    {EWIFI_NOTRUSTCA,       "NO TRUST CA",  "�޿���CA"},
    {EWIFI_RES2223,         "RES: 2223",    "Ԥ��:2223"},
    {EWIFI_SSLDECODE,       "SSL:DECODE E", "SSL:�����"},
    {EWIFI_NOADDSSLSOCK,    "SSL:NO SOCK",  "SSL:�޶˿�"},
    {EWIFI_SSLPACKSIZE,     "SSL:MAX SIZE", "SSL:��̫��"},
    {EWIFI_SSNDSIZE,        "SSND:MAXSIZE", "SSND��̫��"},
    {EWIFI_SSNDCHKSUM,      "SSND:CHK SUM", "SSNDУ���"},
    {EWIFI_HTTPUNKNOWN,     "HTTP:UNKNOWN", "HTTP:δ֪"},
    {EWIFI_HTTPTO,          "HTTP:TIMEOUT", "HTTP:��ʱ"},
    {EWIFI_HTTPFAIL,        "HTTP:FAIL",    "HTTP:ʧ��"},
    {EWIFI_NOURL,           "NO URL",       "��URL"},
    {EWIFI_ILLHTTPNAME,     "HTTP:ILLNAME", "HTTP��Ч��"},
    {EWIFI_ILLHTTPPORT,     "HTTP:ILLPORT", "HTTP�˿ڴ�"},
    {EWIFI_ILLURL,          "ILL URL ADDR", "URL��ַ��"},
    {EWIFI_URLTOOLONG,      "URL:TOO LONG", "URL̫��"},
    {EWIFI_WWWFAIL,         "WWW FAIL",     "WWW��"},
    {EWIFI_MACEXIST,        "EXIST MAC",    "MAC�Ѵ���"},
    {EWIFI_NOIP,            "NO IP ADDR",   "��IP��ַ"},
    {EWIFI_WLANPWR,         "WLAN:PWR ERR", "WLAN�ϵ��"},
    {EWIFI_WLANRADIO,       "WLAN:RADIO E", "WLAN�粨��"},
    {EWIFI_WLENRESET,       "WLAN:RESET E", "WLAN��λ��"},
    {EWIFI_WLANHWSETUP,     "WLAN:HW FAIL", "WLANӲ����"},
    {EWIFI_WIFIBUSY,        "WIFI:BUSY",    "WIFIæ"},
    {EWIFI_ILLWIFICHNL,     "WIFI:CHANNEL", "WIFI�ŵ���"},
    {EWIFI_ILLSNR,          "WIFI:SNR",     "WIFI SNR��"},
    {EWIFI_RES2500,         "RES: 2500",    "Ԥ��:2500"},
    {EWIFI_COMMPLATFORM,    "PLATFORM ACT", "ƽ̨�Ѽ���"},
    {EWIFI_RES2502,         "RES: 2502",    "Ԥ��:2502"},
    {EWIFI_RES2503,         "RES: 2503",    "Ԥ��:2503"},
    {EWIFI_RES2504,         "RES: 2504",    "Ԥ��:2504"},
    {EWIFI_ALLFTPINUSE,     "FTP HDL USE",  "FTP��ʹ��"},
    {EWIFI_NOTANFTP,        "NOT AN FTP",   "����FTP"},
    {EWIFI_FTPSVRFOUND,     "NO FTP SVR",   "��FTP����"},
    {EWIFI_CONNFTPTO,       "FTP:TIMEOUT",  "FTP��ʱ"},
    {EWIFI_FTPLOGIN,        "FTP:LOGIN",    "FTP��¼��"},
    {EWIFI_FTPCMD,          "FTP:CMD ERR",  "FTP�����"},
    {EWIFI_FTPDATASOCK,     "FTP:DSOCKERR", "FTP:DSOCK"},
    {EWIFI_FTPSEND,         "FTP:SEND ERR", "FTP���ʹ�"},
    {EWIFI_FTPDOWN,         "FTP:SVR DOWN", "FTP������"},
    {EWIFI_RES2514,         "RES: 2514",    "Ԥ��:2514"},
    {EWIFI_TELNETSVR,       "TNET:NO SVR",  "TNET������"},
    {EWIFI_CONNTELNETTO,    "TNET:TIMEOUT", "TNET:��ʱ"},
    {EWIFI_TELNETCMD,       "TNET:CMD ERR", "TNET�����"},
    {EWIFI_TELNETDOWN,      "TNET:SVRDOWN", "TNET������"},
    {EWIFI_TELNETACTIVE,    "TNET:NOT ACT", "TNETδ����"},
    {EWIFI_TELNETOPENED,    "TNET:OPENED",  "TNET�Ѵ�"},
    {EWIFI_TELNETBINMODE,   "TNET:BIN MOD", "TNETBINMOD"},
    {EWIFI_TELNETASCMODE,   "TNET:ASC MOD", "TNETASCMOD"},
    {EWIFI_RES2558,         "RES: 2558",    "Ԥ��:2558"},
    {EWIFI_RES2559,         "RES: 2559",    "Ԥ��:2559"},
    {EWIFI_RETRIEVERSP,     "MAIL RETRIEV", "�ʼ��ָ���"},
    {EWIFI_SNETSOCKCLOSE,   "SSOCK CLESED", "Զ�˹ر�"},
    {EWIFI_PINGDEST,        "PING DST ERR", "PING���ɴ�"},
    {EWIFI_PINGNOREPLY,     "PING NOREPLY", "PING�޻�Ӧ"}
};

int NetGetCodeNumber(void)
{
    return(ARRAY_SIZE(WnetRet));
}

//  ��������ģ�鷵��ֵ����ʾ��ָ��
uint8_t *ShowWnetPrompt(int32_t IsChPrompt, int32_t RetCode)
{
    int32_t     i;
    int32_t     codenum;

    codenum = NetGetCodeNumber();
    for(i=0; i<codenum; i++)
    {
        if((RetCode == WnetRet[i].retcode) || (RetCode == -WnetRet[i].retcode))
        {
            if(IsChPrompt)
            {
                return(WnetRet[i].descript_ch);
            }
            else
            {
                return(WnetRet[i].descript_en);
            }
        }
    }
    return(NULL);
}


void ShowTWnetRet(int32_t line, int32_t ret)
{
    uint8_t     *Prompt;

    Prompt = ShowWnetPrompt(NO, ret);
    if(line == -1)
    {
        if(Prompt == NULL)
        {
            ScrollDisplay(DISP_ASCII|DISP_CLRLINE, "RET=%d", ret);
        }
        else
        {
            ScrollDisplay(DISP_ASCII|DISP_CLRLINE, "RET=%d,%s", ret, Prompt);
        }
    }
    else
    {
        if(Prompt == NULL)
        {
            lcdDisplay(0, line, DISP_ASCII|DISP_CLRLINE, "RET=%d",ret);
        }
        else
        {
            lcdDisplay(0, line, DISP_ASCII|DISP_CLRLINE, "RET=%d,%s", ret, Prompt);
        }
    }
}

int32_t SelectFont(int8_t *FontName, int8_t *CharSet, int32_t *size)
{
    font_lib_t  TotalLib[50];
    int32_t     i, LibNum;
    int32_t     iRet;
    int32_t     SelectLine = 0;
    uint8_t     *menu_fontname[128] =
    {
        FONT_CHARSET_ASCII			,	FONT_CHARSET_ASCII			,
        FONT_CHARSET_GB2312			,	FONT_CHARSET_GB2312			,
        FONT_CHARSET_GB18030		,	FONT_CHARSET_GB18030		,
        FONT_CHARSET_VIETNAM		,	FONT_CHARSET_VIETNAM		,
        FONT_CHARSET_ARABIC			,	FONT_CHARSET_ARABIC			,
        FONT_CHARSET_UNICODE		,	FONT_CHARSET_UNICODE		,
        FONT_CHARSET_CP437			,	FONT_CHARSET_CP437			,
        FONT_CHARSET_CP737			,	FONT_CHARSET_CP737			,
        FONT_CHARSET_CP775			,	FONT_CHARSET_CP775			,
        FONT_CHARSET_CP850			,	FONT_CHARSET_CP850			,
        FONT_CHARSET_CP852			,	FONT_CHARSET_CP852			,
        FONT_CHARSET_CP855			,	FONT_CHARSET_CP855			,
        FONT_CHARSET_CP857			,	FONT_CHARSET_CP857			,
        FONT_CHARSET_CP860			,	FONT_CHARSET_CP860			,
        FONT_CHARSET_CP861			,	FONT_CHARSET_CP861			,
        FONT_CHARSET_CP862			,	FONT_CHARSET_CP862			,
        FONT_CHARSET_CP863			,	FONT_CHARSET_CP863			,
        FONT_CHARSET_CP864			,	FONT_CHARSET_CP864			,
        FONT_CHARSET_CP865			,	FONT_CHARSET_CP865			,
        FONT_CHARSET_CP866			,	FONT_CHARSET_CP866			,
        FONT_CHARSET_CP869			,	FONT_CHARSET_CP869			,
        FONT_CHARSET_CP874			,	FONT_CHARSET_CP874			,
        FONT_CHARSET_CP932			,	FONT_CHARSET_CP932			,
        FONT_CHARSET_CP936			,	FONT_CHARSET_CP936			,
        FONT_CHARSET_CP949			,	FONT_CHARSET_CP949			,
        FONT_CHARSET_CP950			,	FONT_CHARSET_CP950			,
        FONT_CHARSET_CP1250			,	FONT_CHARSET_CP1250			,
        FONT_CHARSET_CP1251			,	FONT_CHARSET_CP1251			,
        FONT_CHARSET_CP1255			,	FONT_CHARSET_CP1255			,
        FONT_CHARSET_ISO8859_1		,	FONT_CHARSET_ISO8859_1		,
        FONT_CHARSET_ISO8859_2		,	FONT_CHARSET_ISO8859_2		,
        FONT_CHARSET_ISO8859_3		,	FONT_CHARSET_ISO8859_3		,
        FONT_CHARSET_ISO8859_4		,	FONT_CHARSET_ISO8859_4		,
        FONT_CHARSET_ISO8859_5		,	FONT_CHARSET_ISO8859_5		,
        FONT_CHARSET_ISO8859_6		,	FONT_CHARSET_ISO8859_6		,
        FONT_CHARSET_ISO8859_7		,	FONT_CHARSET_ISO8859_7		,
        FONT_CHARSET_ISO8859_8		,	FONT_CHARSET_ISO8859_8		,
        FONT_CHARSET_ISO8859_9		,	FONT_CHARSET_ISO8859_9		,
        FONT_CHARSET_ISO8859_10		,	FONT_CHARSET_ISO8859_10		,
        FONT_CHARSET_ISO8859_11		,	FONT_CHARSET_ISO8859_11		,
        FONT_CHARSET_ISO8859_12		,	FONT_CHARSET_ISO8859_12		,
        FONT_CHARSET_ISO8859_13		,	FONT_CHARSET_ISO8859_13		,
        FONT_CHARSET_ISO8859_14		,	FONT_CHARSET_ISO8859_14		,
        FONT_CHARSET_ISO8859_15		,   FONT_CHARSET_ISO8859_15		,
    };

    memset(TotalLib, 0x00, sizeof(TotalLib));
    LibNum = font_list_lib(NULL, NULL, TotalLib, ARRAY_SIZE(TotalLib));
    i = 0;
    while(1)
    {
        lcdCls();
        lcdDispMultiLang(0, 0, DISP_CFONT|DISP_MEDIACY, "ѡ���ֿ�(%d)", "Select Font(%d)", i);
        lcdDisplay(0, 2, DISP_CFONT, "%s", TotalLib[i].m_font);
        lcdDisplay(0, 4, DISP_CFONT, "%s", TotalLib[i].m_charset);
        lcdDisplay(0, 6, DISP_CFONT, "%d", TotalLib[i].m_height);
        iRet = kbGetKey();
        if(iRet == KEY_CANCEL)
        {
            return(KB_CANCEL);
        }
        else if(iRet == KEY_ENTER)
        {
            break;
        }
        else if(iRet == KEY_DOWN)
        {
            i = (i+1) % LibNum;
        }
        else if(iRet == KEY_UP)
        {
            i = (i+LibNum-1) % LibNum;
        }
    }

    if(FontName != NULL)
    {
        strncpy(FontName, TotalLib[i].m_font, sizeof(TotalLib[i].m_font));
    }
    if(size != NULL)
    {
        *size = TotalLib[i].m_height;
    }
    if(strcmp(TotalLib[i].m_charset, FONT_CHARSET_UNICODE) != 0)
    {
        if(CharSet != NULL)
        {
            strncpy(CharSet, TotalLib[i].m_charset, sizeof(TotalLib[i].m_charset));
        }
        return(OK);
    }

    lcdCls();
    lcdDispMultiLang(0, 0, DISP_CFONT|DISP_REVERSE|DISP_CLRLINE, "   ѡ���ַ���   ", " SELECT CHARSET ");
    SelectLine = SelectMenu(2, 7, DISP_ASCII, -1, 44, SelectLine, menu_fontname);
    switch(SelectLine)
    {
    case KB_CANCEL:
        return(KB_CANCEL);
    case KB_TIMEOUT:
        return(KB_TIMEOUT);
    case KB_ERROR:
        return(KB_CANCEL);
    default :
        if(CharSet != NULL)
        {
            strcpy(CharSet, menu_fontname[SelectLine*2]);
        }
        break;
    }

    return(OK);
}


