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


UINT32 StrToLong(const UINT8 *buff2)  // 字符串转长整型
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

void LongToStr(UINT32 LongDat, UINT8 *buff2) // 长整型转字符串
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
        lcdDispMultiLang(Col, Line, DispMode, "打印成功", "Print OK");
        break;
    case PRN_BUSY:
        lcdDispMultiLang(Col, Line, DispMode, "打印机忙", "Print BUSY");
        break;
    case PRN_PAPEROUT:
        lcdDispMultiLang(Col, Line, DispMode, "缺纸", "No Paper");
        break;
    case PRN_WRONG_PACKAGE:
        lcdDispMultiLang(Col, Line, DispMode, "数据错误", "Data Error");
        break;
    case PRN_FAULT:
        lcdDispMultiLang(Col, Line, DispMode, "打印错误", "Print Error");
        break;
    case PRN_TOOHEAT:
        lcdDispMultiLang(Col, Line, DispMode, "过热", "Over Heat");
        break;
    case PRN_UNFINISHED:
        lcdDispMultiLang(Col, Line, DispMode, "未打印完成", "Unfinished");
        break;
    case PRN_NOFONTLIB:
        lcdDispMultiLang(Col, Line, DispMode, "找不到字库", "No Font Lib");
        break;
    case PRN_OUTOFMEMORY:
        lcdDispMultiLang(Col, Line, DispMode, "打印缓存满", "Prn Buffer Full");
        break;
    default:
        lcdDispMultiLang(Col, Line, DispMode, "未知错误:%04XH", "Unknown :%04XH", iRet);
        break;
    }
}

void ShowFileTransRet(int32_t Col, int32_t Line, uint32_t DispMode, int32_t iRet)
{
    switch(iRet)
    {
    case LD_OK:             //  成功
        lcdDispMultiLang(Col, Line, DispMode, "成功:%02XH", "OK:%02XH", iRet);
        break;
    case LDERR_GENERIC:     //  失败
        lcdDispMultiLang(Col, Line, DispMode, "失败:%02XH", "ERROR:%02XH", iRet);
        break;
    case LDERR_BAUDERR:     //  波特率不支持
        lcdDispMultiLang(Col, Line, DispMode, "速率不支持:%02XH", "BAUD ERR:%02XH", iRet);
        break;
    case LDERR_INVALIDTIME: //  非法时间
        lcdDispMultiLang(Col, Line, DispMode, "非法时间:%02XH", "TIME ERR:%02XH", iRet);
        break;
    case LDERR_CLOCKHWERR:  //  时钟硬件错误
        lcdDispMultiLang(Col, Line, DispMode, "RTC错误:%02XH", "RTC ERR:%02XH", iRet);
        break;
    case LDERR_SIGERR:      //  验证签名失败
        lcdDispMultiLang(Col, Line, DispMode, "签名错误:%02XH", "SIG ERR:%02XH", iRet);
        break;
    case LDERR_TOOMANYAPP:  //  应用太多，不能下载更多应用
        lcdDispMultiLang(Col, Line, DispMode, "应用太多:%02XH", "MAX APP:%02XH", iRet);
        break;
    case LDERR_TOOMANYFILES://  文件太多，不能下载更多文件
        lcdDispMultiLang(Col, Line, DispMode, "文件太多:%02XH", "MAX FILE:%02XH", iRet);
        break;
    case LDERR_NOAPP:       //  指定应用不存在
        lcdDispMultiLang(Col, Line, DispMode, "没有应用:%02XH", "NO APP:%02XH", iRet);
        break;
    case LDERR_UNKNOWNAPP:  //  不可识别的应用类型
        lcdDispMultiLang(Col, Line, DispMode, "未知应用:%02XH", "UNKNOWN APP:%02XH", iRet);
        break;
    case LDERR_SIGTYPEERR:  //  签名的数据类型和下载请求类型不一致
        lcdDispMultiLang(Col, Line, DispMode, "类型错误:%02XH", "TYPE ERR:%02XH", iRet);
        break;
    case LDERR_SIGAPPERR:   //  签名的数据所属的应用名和下载请求应用名不一致
        lcdDispMultiLang(Col, Line, DispMode, "应用名错:%02XH", "NAME ERR:%02XH", iRet);
        break;
    case LDERR_WRITEFILEFAIL:   //  文件写入失败
        lcdDispMultiLang(Col, Line, DispMode, "写入错误:%02XH", "WRITE ERR:%02XH", iRet);
        break;
    case LDERR_NOSPACE:     //  没有足够的空间
        lcdDispMultiLang(Col, Line, DispMode, "空间满:%02XH", "NO SPACE:%02XH", iRet);
        break;
    case LDERR_RESENDLASTPACK:  //  校验错误，要求重新传输最后一个包
        lcdDispMultiLang(Col, Line, DispMode, "数据包错:%02XH", "PACK ERR:%02XH", iRet);
        break;
    case LDERR_UNSUPPORTEDCMD:  //  不支持该命令
        lcdDispMultiLang(Col, Line, DispMode, "命令不支持:%02XH", "CMD ERR:%02XH", iRet);
        break;
    default:
        lcdDispMultiLang(Col, Line, DispMode, "未知:%08XH", "Unknown:%08XH", iRet);
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
    {NET_OK,                "OK",           "成功"},
    {NET_ERR_RSP,           "RSP ERROR",    "错误的响应"},
    {NET_ERR_NOSIM,         "NO SIM",       "没有SIM卡"},
    {NET_ERR_PIN,           "NEED PIN",     "需要验证PIN"},
    {NET_ERR_PUK,           "NEED PUK",     "需要验证PUK"},
    {NET_ERR_PWD,           "PWD ERR",      "密码错误"},
    {NET_ERR_SIMDESTROY,    "SIM DESTROY",  "SIM毁坏"},
    {NET_ERR_CSQWEAK,       "CSQ TOO WEAK", "信号太弱"},
    {NET_ERR_LINKCLOSED,    "LINK CLOSED",  "链接断开"},
    {NET_ERR_LINKOPENING,   "LINK OPENING", "正在连接"},
    {NET_ERR_DETTACHED,     "DETTACHED",    "未注册网络"},
    {NET_ERR_ATTACHING,     "ATTACHING",    "搜寻网络"},
    {NET_ERR_EMERGENCY,     "EMERGENCY",    "紧急状态"},
    {NET_ERR_RING,          "RING...",      "有振铃"},
    {NET_ERR_BUSY,          "BUSY NOW",     "正在通话"},
    {NET_ERR_DIALING,       "DIALING...",   "拨号中"},
    {NET_ERR_UNKNOWN,       "UNKNOWN",      "未知错误"},
    {NET_ERR_ABNORMAL,      "ABNORMAL",     "异常错误"},
    {NET_ERR_NOMODULE,      "NO MODULE",    "无模块"},
//  errno.h
    {ENOMEM,                "NO MEM",       "内存不足"},
    {EFAULT,                "FAULT",        "错误"},
    {EINVAL,                "INVALID PARA", "无效参数"},
    {ENODATA,               "NO DATA",      "没有数据"},
    {ENONET,                "NO NET",       "没有网络"},
    {ENOLINK,               "NO LINK",      "没有链接"},
    {ECOMM,                 "SEND ERR",     "发送错误"},
    {EPROTO,                "PROTO ERR",    "协议错误1"},
    {EOVERFLOW,             "OVERFLOW",     "溢出"},
    {ENOTSOCK,              "NOT SOCK",     "没有SOCK"},
    {EPROTOTYPE,            "PROTO WRONG",  "协议错误2"},
    {ENOPROTOOPT,           "NO PROTO OPT", "无协议选项"},
    {EPROTONOSUPPORT,       "PROTO NO SUP", "协议不支持"},
    {EPFNOSUPPORT,          "PROTO FML",    "协议族未知"},
    {ENETDOWN,              "NET DOWN",     "网络断开"},
    {ENETUNREACH,           "NET UNREACH",  "网络不可达"},
    {ENETRESET,             "NET DROPPED",  "网络复位"},
    {ECONNRESET,            "CONN RESET",   "链接复位"},
    {EISCONN,               "IS CONN",      "已连接"},
    {ENOTCONN,              "NOT CONN",     "未连接"},
    {ESHUTDOWN,             "SHUT DOWN",    "断开"},
    {ETIMEDOUT,             "TIMEOUT",      "超时"},
    {ECONNREFUSED,          "REFUSED",      "链接被拒绝"},
    {EHOSTDOWN,             "HOST DOWN",    "主机断开"},
    {EHOSTUNREACH,          "HOST UNREACH", "主机不可达"},
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
    {EWIFI_ILLDELIMITER,    "ILLDELIMITER", "非法分隔符"},
    {EWIFI_ILLVAL,          "ILLVAL",       "非法值"},
    {EWIFI_EXPCR,           "EXPCR",        "缺CR"},
    {EWIFI_EXPNUM,          "EXPNUM",       "缺号码"},
    {EWIFI_EXPCRORCOMMA,    "EXPCRORCOMMA", "缺CR或逗号"},
    {EWIFI_EXPDNS,          "EXPDNS",       "缺DNS"},
    {EWIFI_EXPTILDE,        "EXP':'or'~'",  "缺':'或'~'"},
    {EWIFI_EXPSTR,          "EXP STRING",   "缺字符串"},
    {EWIFI_EXPEQL,          "EXP':'or'='",  "缺':'或'='"},
    {EWIFI_EXPTXT,          "EXP TEXT",     "缺文本内容"},
    {EWIFI_SYNTAX,          "SYNTAX ERR",   "语法错误"},
    {EWIFI_EXPCOMMA,        "EXP ','",      "缺','"},
    {EWIFI_ILLCMD,          "ILL CMD CODE", "命令码非法"},
    {EWIFI_SETPARA,         "SET PARA ERR", "设置参数错"},
    {EWIFI_GETPARA,         "GET PARA ERR", "获取参数错"},
    {EWIFI_USERABORT,       "USER ABORT",   "用户取消"},
    {EWIFI_BUILDPPP,        "BUILD PPP",    "建立PPP错"},
    {EWIFI_BUILDSMTP,       "BUILD SMTP",   "建立SMTP错"},
    {EWIFI_BUILDPOP3,       "BUILD POP3",   "建立POP3错"},
    {EWIFI_MAXMINE,         "MAX MIME",     "MIME上限"},
    {EWIFI_INTMEMFAIL,      "INTMEM FAIL",  "内部存储错"},
    {EWIFI_USERABORTSYS,    "USERABORTSYS", "取消系统"},
    {EWIFI_HFCCTSH,         "FLC CTSH ERR", "流控CTSH错"},
    {EWIFI_USERABORTDDD,    "ABORT BY ---", "被---取消"},
    {EWIFI_RES2065,         "RES: 2065",    "预留:2065"},
    {EWIFI_RES2066,         "RES: 2066",    "预留:2066"},
    {EWIFI_CMDIGNORE,       "CMD IGNORE",   "命令被忽略"},
    {EWIFI_SNEXIST,         "SN EXIST",     "SN已存在"},
    {EWIFI_HOSTTO,          "HOST TIMEOUT", "主机超时"},
    {EWIFI_MODEMRESPOND,    "MDM RSP FAIL", "MDM响应错"},
    {EWIFI_NODIALTONE,      "NO DIAL TONE", "无拨号音"},
    {EWIFI_NOCARRIER,       "NO CARRIER",   "无载波"},
    {EWIFI_DIALFAIL,        "DIAL FAILED",  "拨号失败"},
    {EWIFI_CONNLOST,        "CONNECT LOST", "掉链"},
    {EWIFI_ACCESSISP,       "ACCESS ISP",   "访问ISP错"},
    {EWIFI_LOCPOP3,         "LOCATE POP3",  "定位POP3错"},
    {EWIFI_POP3TO,          "POP3 TIMEOUT", "POP3超时"},
    {EWIFI_ACCESSPOP3,      "ACCESS POP3",  "访问POP3错"},
    {EWIFI_POP3FAIL,        "POP3 FAILED",  "POP3错"},
    {EWIFI_NOSUITMSG,       "NO SUIT MSG",  "邮箱没消息"},
    {EWIFI_LOCSMTP,         "LOCATE SMTP",  "定位SMTP错"},
    {EWIFI_SMTPTO,          "SMTP TIMEOUT", "SMTP超时"},
    {EWIFI_SMTPFAIL,        "SMTP FAILED",  "SMTP错"},
    {EWIFI_RES2084,         "RES: 2084",    "预留:2084"},
    {EWIFI_RES2085,         "RES: 2085",    "预留:2085"},
    {EWIFI_WRINTPARA,       "WRITE PARA",   "写入参数错"},
    {EWIFI_WEBIPREG,        "REG WEB ERR",  "注册WEB错"},
    {EWIFI_WEBIPREG,        "REG SOCK ERR", "注册SOCK错"},
    {EWIFI_EMAILIPREG,      "REG MAIL ERR", "注册MAIL错"},
    {EWIFI_IPREGFAIL,       "REG IP ERR",   "注册IP错"},
    {EWIFI_RES2091,         "RES: 2091",    "预留:2091"},
    {EWIFI_RES2092,         "RES: 2092",    "预留:2092"},
    {EWIFI_RES2093,         "RES: 2093",    "预留:2093"},
    {EWIFI_ONLINELOST,      "LOST-REEST",   "掉链重连"},
    {EWIFI_REMOTELOST,      "REMOTE LOST",  "主机断链"},
    {EWIFI_RES2098,         "RES: 2098",    "预留:2098"},
    {EWIFI_RES2099,         "RES: 2099",    "预留:2099"},
    {EWIFI_DEFAULTRES,      "RESTORE ERR",  "恢复预设错"},
    {EWIFI_NOISPDEF,        "NO ISP No.",   "无ISP号码"},
    {EWIFI_NOUSRNDEF,       "NO USRN",      "无USRN"},
    {EWIFI_NOPWDENTER,      "NO PWD ENTER", "未输密码"},
    {EWIFI_NODNSDEF,        "NO DNS",       "无DNS"},
    {EWIFI_NOPOP3DEF,       "NO POP3",      "无POP3"},
    {EWIFI_NOMBXDEF,        "NO MAILBOX",   "无邮箱"},
    {EWIFI_NOMPWDDEF,       "NO MPWD",      "无邮箱密码"},
    {EWIFI_NOTOADEF,        "NO TOA",       "无TOA"},
    {EWIFI_NOREADEF,        "NO REA",       "无REA"},
    {EWIFI_NOSMTPDEF,       "NO SMTP",      "无SMTP"},
    {EWIFI_SDATAOVERFLOW,   "SDATA OVERF",  "SDATA溢出"},
    {EWIFI_ILLCMDMDM,       "ILL CMD MDM",  "无效命令"},
    {EWIFI_FWUPDT,          "FW NOT UPDAT", "FW未完成"},
    {EWIFI_EMAILPARAUPDT,   "UPD MAILPARA", "MPARA升级"},
    {EWIFI_SNETPARA,        "SNET PARA",    "缺SNET参数"},
    {EWIFI_PARSECA,         "ERR PARSE CA", "CA语法错"},
    {EWIFI_RES2117,         "RES: 2117",    "预留:2117"},
    {EWIFI_USRVPARA,        "NO USRV PARA", "无USRV参数"},
    {EWIFI_WLPPSHORT,       "WLPP SHORT",   "密码太短"},
    {EWIFI_RES2120,         "RES: 2120",    "预留:2120"},
    {EWIFI_RES2121,         "RES: 2121",    "预留:2121"},
    {EWIFI_SNETHIF0,        "SNET:HIF=0",   "SNET:HIF=0"},
    {EWIFI_SNETBAUD,        "SNET:BAUD",    "SNET:速率"},
    {EWIFI_SNETHIFPARA,     "SNET:HIF",     "SNET:HIF"},
    {EWIFI_NOSOCK,          "NO SOCK",      "无SOCK"},
    {EWIFI_SOCKEMPTY,       "SOCK EMPTY",   "SOCK空"},
    {EWIFI_SOCKUNUSE,       "SOCK NOT USE", "SOCK未使用"},
    {EWIFI_SOCKDOWN,        "SOCK DOWN",    "SOCK DOWN"},
    {EWIFI_NOAVAILDSOCK,    "NO VAIL SOCK", "无有效SOCK"},
    {EWIFI_PPPOPEN,         "PPP OPEN ERR", "PPP打开错"},
    {EWIFI_CREATSOCK,       "OPEN SOCK",    "SOCK打开错"},
    {EWIFI_SOCKSEND,        "SOCK SND ERR", "SOCK发送错"},
    {EWIFI_SOCKRECV,        "SOCK RCV ERR", "SOCK接收错"},
    {EWIFI_PPPDOWN,         "PPP DOWN",     "PPP DOWN"},
    {EWIFI_SOCKFLUSH,       "SOCK FLUSH E", "SOCK刷新错"},
    {EWIFI_NOCARRIERSOCK,   "SOCK NO CARR", "SOCK无载波"},
    {EWIFI_GENERALEXCEPT,   "GNRL EXCEPT",  "普通例外"},
    {EWIFI_OUTOFMEM,        "OUT OF MEM",   "内存溢出"},
    {EWIFI_LOCPORTINUSE,    "PORT IN USE",  "端口在用"},
    {EWIFI_LOADCA,          "SSL:LOAD CA",  "SSL:载入CA"},
    {EWIFI_NEGSSL3,         "SSL:NEG ERR",  "SSL:协商错"},
    {EWIFI_ILLSSLSOCK,      "SSL:ILL SOCK", "SSL:端口错"},
    {EWIFI_NOTRUSTCA,       "NO TRUST CA",  "无可信CA"},
    {EWIFI_RES2223,         "RES: 2223",    "预留:2223"},
    {EWIFI_SSLDECODE,       "SSL:DECODE E", "SSL:解码错"},
    {EWIFI_NOADDSSLSOCK,    "SSL:NO SOCK",  "SSL:无端口"},
    {EWIFI_SSLPACKSIZE,     "SSL:MAX SIZE", "SSL:包太大"},
    {EWIFI_SSNDSIZE,        "SSND:MAXSIZE", "SSND包太大"},
    {EWIFI_SSNDCHKSUM,      "SSND:CHK SUM", "SSND校验错"},
    {EWIFI_HTTPUNKNOWN,     "HTTP:UNKNOWN", "HTTP:未知"},
    {EWIFI_HTTPTO,          "HTTP:TIMEOUT", "HTTP:超时"},
    {EWIFI_HTTPFAIL,        "HTTP:FAIL",    "HTTP:失败"},
    {EWIFI_NOURL,           "NO URL",       "无URL"},
    {EWIFI_ILLHTTPNAME,     "HTTP:ILLNAME", "HTTP无效名"},
    {EWIFI_ILLHTTPPORT,     "HTTP:ILLPORT", "HTTP端口错"},
    {EWIFI_ILLURL,          "ILL URL ADDR", "URL地址错"},
    {EWIFI_URLTOOLONG,      "URL:TOO LONG", "URL太长"},
    {EWIFI_WWWFAIL,         "WWW FAIL",     "WWW错"},
    {EWIFI_MACEXIST,        "EXIST MAC",    "MAC已存在"},
    {EWIFI_NOIP,            "NO IP ADDR",   "无IP地址"},
    {EWIFI_WLANPWR,         "WLAN:PWR ERR", "WLAN上电错"},
    {EWIFI_WLANRADIO,       "WLAN:RADIO E", "WLAN电波错"},
    {EWIFI_WLENRESET,       "WLAN:RESET E", "WLAN复位错"},
    {EWIFI_WLANHWSETUP,     "WLAN:HW FAIL", "WLAN硬件错"},
    {EWIFI_WIFIBUSY,        "WIFI:BUSY",    "WIFI忙"},
    {EWIFI_ILLWIFICHNL,     "WIFI:CHANNEL", "WIFI信道错"},
    {EWIFI_ILLSNR,          "WIFI:SNR",     "WIFI SNR错"},
    {EWIFI_RES2500,         "RES: 2500",    "预留:2500"},
    {EWIFI_COMMPLATFORM,    "PLATFORM ACT", "平台已激活"},
    {EWIFI_RES2502,         "RES: 2502",    "预留:2502"},
    {EWIFI_RES2503,         "RES: 2503",    "预留:2503"},
    {EWIFI_RES2504,         "RES: 2504",    "预留:2504"},
    {EWIFI_ALLFTPINUSE,     "FTP HDL USE",  "FTP在使用"},
    {EWIFI_NOTANFTP,        "NOT AN FTP",   "不是FTP"},
    {EWIFI_FTPSVRFOUND,     "NO FTP SVR",   "无FTP主机"},
    {EWIFI_CONNFTPTO,       "FTP:TIMEOUT",  "FTP超时"},
    {EWIFI_FTPLOGIN,        "FTP:LOGIN",    "FTP登录错"},
    {EWIFI_FTPCMD,          "FTP:CMD ERR",  "FTP命令错"},
    {EWIFI_FTPDATASOCK,     "FTP:DSOCKERR", "FTP:DSOCK"},
    {EWIFI_FTPSEND,         "FTP:SEND ERR", "FTP发送错"},
    {EWIFI_FTPDOWN,         "FTP:SVR DOWN", "FTP主机断"},
    {EWIFI_RES2514,         "RES: 2514",    "预留:2514"},
    {EWIFI_TELNETSVR,       "TNET:NO SVR",  "TNET无主机"},
    {EWIFI_CONNTELNETTO,    "TNET:TIMEOUT", "TNET:超时"},
    {EWIFI_TELNETCMD,       "TNET:CMD ERR", "TNET命令错"},
    {EWIFI_TELNETDOWN,      "TNET:SVRDOWN", "TNET主机断"},
    {EWIFI_TELNETACTIVE,    "TNET:NOT ACT", "TNET未激活"},
    {EWIFI_TELNETOPENED,    "TNET:OPENED",  "TNET已打开"},
    {EWIFI_TELNETBINMODE,   "TNET:BIN MOD", "TNETBINMOD"},
    {EWIFI_TELNETASCMODE,   "TNET:ASC MOD", "TNETASCMOD"},
    {EWIFI_RES2558,         "RES: 2558",    "预留:2558"},
    {EWIFI_RES2559,         "RES: 2559",    "预留:2559"},
    {EWIFI_RETRIEVERSP,     "MAIL RETRIEV", "邮件恢复错"},
    {EWIFI_SNETSOCKCLOSE,   "SSOCK CLESED", "远端关闭"},
    {EWIFI_PINGDEST,        "PING DST ERR", "PING不可达"},
    {EWIFI_PINGNOREPLY,     "PING NOREPLY", "PING无回应"}
};

int NetGetCodeNumber(void)
{
    return(ARRAY_SIZE(WnetRet));
}

//  返回无线模块返回值的提示串指针
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
        lcdDispMultiLang(0, 0, DISP_CFONT|DISP_MEDIACY, "选择字库(%d)", "Select Font(%d)", i);
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
    lcdDispMultiLang(0, 0, DISP_CFONT|DISP_REVERSE|DISP_CLRLINE, "   选择字符集   ", " SELECT CHARSET ");
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


