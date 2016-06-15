#include "posapi.h"
#include "font.h"
#include "public.h"

const APPINFO AppInfo = {
	"BTPOSTicketing",
	"V1.0",
	"WEBINGATE",
	"20160610114808",
	"BT POS sample application",
	0x01
};

INT32 main(void)
{

	int iKey;
	int dKey;
	int inKey;
	// welcome sign
	Disp_Welcome_Sign();

	lcdCls();
	lcdDisplay(0, 0, DISP_CFONT | DISP_MEDIACY | DISP_REVERSE, " Ticketing Demo   ");

	kbFlush();

	//check first run
	//TestFirstRun();

	//Main menu
	kbFlush();
	while (1)
	{
		lcdCls();
		lcdDisplay(0, 0, DISP_CFONT | DISP_MEDIACY | DISP_REVERSE, " Ticketing Demo   ");

		lcdClrLine(2, 7);
		lcdDisplay(0, 2, DISP_CFONT, "1. Ticketing");
		lcdDisplay(0, 4, DISP_CFONT, "2. Validate ticket");
		lcdDisplay(0, 6, DISP_CFONT, "3. Reset");
		lcdDisplay(0, 8, DISP_CFONT, "4. Exit");

		iKey = kbGetKey();
		switch (iKey)
		{
		case KEY1:	

			//Ticketing();

			

			lcdCls();
			lcdDisplay(0, 0, DISP_CFONT | DISP_MEDIACY | DISP_REVERSE, "   Select Source   ");

			//kbFlush();

			//Main menu
			//kbFlush();

			
				lcdClrLine(2, 7);
				lcdDisplay(0, 2, DISP_CFONT, "1. Stage1");
				lcdDisplay(0, 4, DISP_CFONT, "2. Stage2");
				lcdDisplay(0, 6, DISP_CFONT, "3. Stage3");
				lcdDisplay(0, 8, DISP_CFONT, "4. Stage4");

				inKey = kbGetKey();
				
				

				lcdCls();
				lcdDisplay(0, 0, DISP_CFONT | DISP_MEDIACY | DISP_REVERSE, "   Select Destination   ");

				//kbFlush();

				//Main menu
				//kbFlush();


				lcdClrLine(2, 7);
				lcdDisplay(0, 2, DISP_CFONT, "1. Stage2");
				lcdDisplay(0, 4, DISP_CFONT, "2. Stage3");
				lcdDisplay(0, 6, DISP_CFONT, "3. Stage4");
				lcdDisplay(0, 8, DISP_CFONT, "4. Stage5");

				dKey = kbGetKey();

				/*int fare = GetFare(inKey, dKey);
				if (fare == 0)
				{
					lcdDisplay(0, 3, DISP_CFONT, (uint8_t *)" Invalid sourc & destination selected");
					return -1;
				}*/
				//prompt for payment options

				//if done, print 
				//else exit
				lcdDisplay(0, 3, DISP_CFONT, (uint8_t *)" printing tikcet");
				//TestPrnTicket(1, 3,10.0);
				TestPrnTicket();

			break;
		case KEY2:			
			ValidateTicket();
			break;
		case KEY3:			
			sysReset();
			break;
		case KEY4:
			sysReset();
			break;
		default:
			break;
		}
	}

	sysExit(0);
}

void Disp_Welcome_Sign(void)
{
	char szBuffer[20];

	//Get Current DateTime
	GetCurTime(szBuffer);

	lcdCls();
	lcdDisplay(0, 0, DISP_CFONT | DISP_MEDIACY | DISP_REVERSE, (uint8_t *)szBuffer);
	lcdDisplay(0, 3, DISP_CFONT, (uint8_t *)"Welcome to");
	lcdDisplay(0, 5, DISP_CFONT, (uint8_t *)"BT POS Tickeing Demo!!");
	sysDelayMs(1000);
}

int Ticketing(){

	int sKey;
	int dKey;
	int fare;
	//display menu for choosing src
	//get the option for src
	sKey = SelectSrc();

	//display menu for target
	//get the option for tgt
	dKey = SelectTgt();

	if (sKey == 0)
	{
		lcdDisplay(0, 3, DISP_CFONT, (uint8_t *)" Invalid source");
		return -1;
	}

	if (dKey == 0)
	{
		lcdDisplay(0, 3, DISP_CFONT, (uint8_t *)" Invalid destination");
		return -1;
	}

	//display a fare
	/*fare = GetFare(sKey, dKey);
	if (fare == 0)
	{
		lcdDisplay(0, 3, DISP_CFONT, (uint8_t *)" Invalid sourc & destination selected");
		return -1;
	}*/
	//prompt for payment options

	//if done, print 
	//else exit

	//TestPrnTicket(1,2,10.0);
	TestPrnTicket();
	return 0;
}


int SelectSrc()
{
	int inKey;
	
	lcdCls();
	lcdDisplay(0, 0, DISP_CFONT | DISP_MEDIACY | DISP_REVERSE, "   Select Source   ");

	kbFlush();

	//Main menu
	kbFlush();
	
	while (1)
	{
		lcdClrLine(2, 7);
		lcdDisplay(0, 2, DISP_CFONT, "1. Stage1");
		lcdDisplay(0, 4, DISP_CFONT, "2. Stage2");
		lcdDisplay(0, 6, DISP_CFONT, "3. Stage3");
		lcdDisplay(0, 8, DISP_CFONT, "4. Stage4");

		inKey = kbGetKey();
		switch (inKey)
		{
		case KB_CANCEL:
			return(OK);
		case KB_TIMEOUT:
			break;
		case KB_ERROR:
			return(OK);
		case KEY1:
			return inKey;
			break;
		case KEY2:
			return inKey;
			break;
		case KEY3:
			return inKey;
			break;
		case KEY4:
			return inKey;
			break;
		default:
			return(OK);
			break;
		}
	}

	return 0;
}

int SelectTgt()
{
	int inKey1;

	lcdCls();
	lcdDisplay(0, 0, DISP_CFONT | DISP_MEDIACY | DISP_REVERSE, " Select Destination   ");

	kbFlush();

	//Main menu
	kbFlush();

	while (1)
	{
		lcdClrLine(2, 7);		
		lcdDisplay(0, 2, DISP_CFONT, "1. Stage2");
		lcdDisplay(0, 4, DISP_CFONT, "2. Stage3");
		lcdDisplay(0, 6, DISP_CFONT, "3. Stage4");
		lcdDisplay(0, 8, DISP_CFONT, "4. Stage4");

		inKey1 = kbGetKey();
		switch (inKey1)
		{
		case KB_CANCEL:
			return(OK);
		case KB_TIMEOUT:
			break;
		case KB_ERROR:
			return(OK);
		case KEY1:
			return inKey1;
			break;
		case KEY2:
			return inKey1;
			break;
		case KEY3:
			return inKey1;
			break;
		case KEY4:
			return inKey1;
			break;
		default:
			return(OK);
			break;
		}
	}

	return 0;
}

int GetFare(int s, int d){

	int f = 0;

	if (s == 1 && d == 1)
		return 10;

	if (s == 1 && d == 2)
		return 15;

	if (s == 1 && d == 3)
		return 20;
	if (s == 1 && d == 4)
		return 25;

	if (s == 2 && d == 1)
		return 10;

	if (s == 2 && d == 2)
		return 15;

	if (s == 2 && d == 3)
		return 20;

	if (s == 2 && d == 4)
		return 25;

	if (s == 3 && d == 1)
		return 10;

	if (s == 3 && d == 2)
		return 15;

	if (s == 3 && d == 3)
		return 20;

	if (s == 3 && d == 4)
		return 25;

	if (s == 4 && d == 1)
		return 10;

	if (s == 4 && d == 2)
		return 15;

	if (s == 4 && d == 3)
		return 20;

	if (s == 4 && d == 4)
		return 25;

	return f;
}

int ValidateTicket(){
	//prompt to enter the ticket code
	//if code = 123 then dispaly success and prompt for print
	//other wise display message and prompt to press any key to exit

	//TestPrnTicket(1,2,10.0);
	TestPrnTicket();
}


int32_t TestFirstRun(int32_t inpara)
{
	int32_t     firstrun;

	kbFlush();
	firstrun = sysCheckFirstRun();
	if (firstrun == YES)
	{
		lcdCls();
		lcdDispMultiLang(0, 3, DISP_CFONT | DISP_CLRLINE | DISP_MEDIACY, "第一次运行", "First Run");
		sysBeef(5, 1000);
		kbGetKeyMs(5000);
	}
	return(firstrun);
}

//int TestPrnTicket(int from, int to, float inpara)
int TestPrnTicket()
{
	int from = 1;
	int to = 3;
	float inpara = 0.50;
	int			ret;
	char		seperatebuf[256];
	uint8_t		timebuf[16];

	uint8_t		bakFontName[36], bakFontCharacter[36];
	int			bakFontStyle, bakFontSize;

	strncpy(seperatebuf, "------------------------------", sizeof(seperatebuf));
	lcdCls();

	ret = prnInit();
	lcdDispMultiLang(0, 0, DISP_CFONT | DISP_REVERSE, "    测试打印    ", "  TEST PRINTER  ");

	prnGetCurFont(bakFontName, bakFontCharacter, &bakFontStyle, &bakFontSize, SET_PRIMARY_FONT);// backup the current font setting
	prnSetFont(FONT_ARIAL, FONT_CHARSET_ASCII, 0, 28, SET_PRIMARY_FONT);  //  use arial font size = 24
	prnPrintf("\n\n");
	prnPrintf("      INTERBUS Travel Ticket\n");

	prnPrintf("\n%s\n\n", seperatebuf);

	sysGetTime(timebuf);

	prnPrintf("Date: %02X/%02X/20%02X    Time:%02X:%02X\n", timebuf[2], timebuf[1], timebuf[0], timebuf[3], timebuf[4]);
	prnPrintf("Receipt No: 00001\n");
	prnPrintf("Route Number: R001\n\n");
	prnPrintf("From stage: Stage%d\n", from);
	prnPrintf("To stage  : Stage%d\n\n",to);

	prnSetFont(FONT_ARIAL, FONT_CHARSET_ASCII, 0, 32, SET_PRIMARY_FONT);  //  use arial font size=32
	prnPrintf("Total: $ %.2f\n", inpara);

	prnSetFont(FONT_ARIAL, FONT_CHARSET_ASCII, 0, 24, SET_PRIMARY_FONT);  //  use arial font size = 24
	prnSetFont(FONT_ARIAL, FONT_CHARSET_ASCII, 0, 24, SET_PRIMARY_FONT);  //  use arial font size = 24
	prnPrintf("\n\n");

	prnPrintf("            Operator Id: AA1");

	prnPrintf("\n%s---------------------\n", seperatebuf);
	prnPrintf("                    Thank You!\n");
	prnPrintf("\n\n\n");

	prnSetFont(bakFontName, bakFontCharacter, bakFontStyle, bakFontSize, SET_PRIMARY_FONT);	//  Restore to the backup font setting

	ret = prnStart();
	ShowPrintStatus(0, 2, DISP_CFONT | DISP_CLRLINE, ret);

	lcdClrLine(2, 7);
	lcdDispMultiLang(0, 6, DISP_CFONT | DISP_CLRLINE, "打印测试完成", "Ticket printed");
	sysBeep();
	kbFlush();
	kbGetKey();
	return(ret);
}

//end of file