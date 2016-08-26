#ifndef     _PUBLIC_H_
#define     _PUBLIC_H_

#define     APP_NAME            "APPFILE"


typedef struct
{
    int32_t     retcode;        //  api返回
    uint8_t     *descript_en;   //  错误描述信息(英文)
    uint8_t     *descript_ch;   //  错误描述信息(中文)
}tWnet_ret;

typedef struct
{
    int32_t     total;        //  总行数
    uint8_t     linecontent[100][17];   //  每行的内容
   // uint8_t     *descript_ch;   //  错误描述信息(中文)
}ststr2line;

typedef struct
{
    int8_t      *prompt_chn;
    int8_t      *prompt_en;
    int32_t     selectline;
    int32_t     para;
    int32_t     (*menu_func)(int32_t);
}menu_unit_t;

void InitPromptLanguage(void);
int32_t PromptLangSet(void);
//void SCR_PRINT(int32_t Col, int32_t Line, uint32_t DispMode, uint8_t *HanziMsg, uint8_t *EngMsg);
//void SCR_PRINT_EXT(int32_t Col, int32_t Line, uint32_t DispMode, uint8_t *HanziMsg, uint8_t *EngMsg, int32_t iPara);
#define lcdDispMultiLang(col, line, mode, ch, en, arg...)    \
    do {    \
        if((PromptLangSet() == ON) && (((mode)&DISP_CFONT) == DISP_CFONT))\
            lcdDisplay(col, line, mode, ch, ## arg);\
        else    \
            lcdDisplay(col, line, mode, en, ## arg);\
    } while(0)

/////////////////

UINT32 StrToLong(const UINT8 *buff2);
void LongToStr(UINT32 LongDat, UINT8 *buff2);
UINT16 StrToUINT16(const UINT8 *buff2);
void UINT16ToStr(UINT16 Num, UINT8 *buff2);


INT32 vTwoOne(UINT8 *in, UINT8 *out, INT32 in_len);
void vOneTwo(UINT8 *in, UINT8 *out, INT32 in_len);
void XorBlock(UINT8 *InBlock1, UINT8 *InBlock2, UINT8 *OutBlock, INT32 Len);

void BeepErr(void);
int32_t SelectMenu(int32_t StartLine, int32_t EndLine, int32_t DispMode, int32_t TimeOutMs,
    int32_t PromptNum, int32_t PreCursor, uint8_t *pPrompt[]);
int32_t SelectProMenu(int32_t StartLine, int32_t EndLine, int32_t DispMode, int32_t TimeOutMs, menu_unit_t menu_unit[]);

void ScrollClr(void);
void ScrollDisplay(uint32_t Mode, char *str, ...);

int32_t SelectFont(int8_t *FontName, int8_t *CharSet, int32_t *size);

void ShowPrintStatus(int32_t Col, int32_t Line, uint32_t DispMode, int32_t iRet);
void ShowFileTransRet(int32_t Col, int32_t Line, uint32_t DispMode, int32_t iRet);
INT32 ShowPedRet(INT32 DispCol, INT32 DispLine, INT32 DispMode, INT32 OkTimeOutMs, INT32 ErrTimeOutMs, INT32  RetCode);
INT32 ShowKeyBoardRet(INT32 DispCol, INT32 DispLine, INT32 DispMode, INT32  RetCode);

uint8_t *ShowWnetPrompt(int32_t IsChPrompt, int32_t RetCode);
void ShowTWnetRet(int32_t line, int32_t ret);

#endif

