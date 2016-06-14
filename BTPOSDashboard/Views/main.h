/***************************************************************************
* main.h
****************************************************************************/

#ifndef _MAIN_H_
#define _MAIN_H_

#define EDCAPP_AID			"BTPOSTicketing"
#define EDC_VER_STRING		"V1.0"

#ifdef __cplusplus
extern "C" {
#endif


void Disp_Welcome_Sign(void);
int Ticketing();
int SelectSrc();
int SelectTgt();
long GetFare(int s, int d);
int ValidateTicket();
int32_t TestFirstRun(int32_t inpara);
//int TestPrnTicket(int from, int to, float inpara);
int TestPrnTicket();
#ifdef __cplusplus
}
#endif

#endif // _TMSLIB_H_
