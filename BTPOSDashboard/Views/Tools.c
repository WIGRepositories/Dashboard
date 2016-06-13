/**************************************************************************
* Tools.c
****************************************************************************/
#include "posapi.h"
#include "Ctype.h"
#include "Tools.h"

/********************** Internal macros declaration ************************/
/********************** Internal structure declaration *********************/
/********************** Internal functions declaration *********************/
/********************** Internal variables declaration *********************/
/********************** external reference declaration *********************/
/******************>>>>>>>>>>>>>Implementations<<<<<<<<<<<<*****************/

// Get Current date&time in English form (16 bytes, eg: "OCT07,2008 11:22")
// This function is effective from 2000 to 2099 
void   GetCurTime(char *pszCurTime)
{
	char	szEngName[13][4] = {"   ","JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"};
	UINT8	sCurTime[7+1];
	UINT8   ucTemp;
	INT32   index;

	if (pszCurTime==NULL)
	{
		return;
	}

	memset(sCurTime,0,sizeof(sCurTime));
	sysGetTime(sCurTime);

 	ucTemp = sCurTime[1];
 	index = (ucTemp>>4) * 10 ;
 	ucTemp = sCurTime[1];
 	index += (ucTemp & 0x0F);
 	index %= 13; 

	sprintf((char *)pszCurTime, "%.3s%02X,%02X%02X %02X:%02X", szEngName[index],
			sCurTime[2], 0x20,
			sCurTime[0], sCurTime[3], sCurTime[4]);
}

int PubWaitKey(ulong ulWaitTime)
{
	int   iKey;

	kbFlush();
	if (ulWaitTime>0)
	{
		iKey = kbGetKeyMs((int)(ulWaitTime*1000));
	}
	else
	{
		iKey = kbGetKey();
	}
		
	return iKey;
}

void Disp_User_defined_ErroInfo(char *pszLine1, char *pszLine2, int iMode)
{
	lcdClrLine(2, 7);
	if (pszLine1 != NULL)
	{
		lcdDisplay(0, 3, iMode, (uint8_t *)pszLine1);
	}
	if (pszLine2 != NULL)
	{
		lcdDisplay(0, 5, iMode, (uint8_t *)pszLine2);
	}

	sysBeef(1, 200);
	sysDelayMs(200);
	
	PubWaitKey(5);
}

// 0:fault, 1:ok
int ISAllCharInString(uint8_t *pAllChar, int AllCharLen, uint8_t *str, int strLen)
{
    int i, j;
    int iFlag = 0;
    for (i=0; i<AllCharLen; i++)
    {
        iFlag = 0;
        for (j=0; j<strLen; j++)
        {
            if (pAllChar[i] == str[j])
            {
                iFlag = 1;
                break;
            }
        }
        if (0 == iFlag)
        {
            return 0;
        }
    }
    return 1;
}

void PubStrUpper(char *pszString)
{
    while( *pszString )
    {
        *pszString = toupper((char)*pszString);
        pszString++;
    }
}

char * PubFirstNotChar(char *psStr, char Char)
{
	char *psChar;
	if (psStr == NULL)
	{
		return NULL;
	}

	psChar = psStr;
	while(*psChar == Char && psChar != NULL)
	{
		psChar++;
	}

	return psChar;
}

unsigned long PubAsc2Long(char *psString, int iStrLen, ulong *pulOut)
{
    char    szBuff[15+1];
	unsigned long    ulTmp;

    sprintf(szBuff, "%.*s", (iStrLen <= 15 ? iStrLen : 15 ), psString);
	ulTmp =  (unsigned long)atol(szBuff);

    if (pulOut != NULL)
	{
		*pulOut = ulTmp;
	}
    return ulTmp;
}
//end of file
