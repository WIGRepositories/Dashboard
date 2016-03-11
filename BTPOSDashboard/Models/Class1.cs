using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTPOSDashboardAPI.Models;

namespace BTPOSDashboardAPI.Models
{
    public class Class1
    {
        public int Id { set; get; }
        public DateTime Date { set; get; }
        public int Amount { set; get; }
        public string Spenton { set; get; }
        public string Enteredby { set; get; }
        public TimeSpan Time { set; get; }
        public int BTPOSId { set; get; }
        public string Desc { set; get; }

    }
    public class BOTPOSL
    {
        public int Id { set; get; }
        public int BTPOSid { set; get; }
        public int licenseId { set; get; }
        public DateTime FromDate { set; get; }
        public DateTime EndDate { set; get; }
        public DateTime NotificationDate { set; get; }
        public int TransactionId { set; get; }
        public DateTime RenewedOn { set; get; }
    }
    public class FleetOL
    {
        public int Id { set; get; }
        public int FleetOwnerId { set; get; }
        public int LicenseId { set; get; }
        public int Code { set; get; }
        public DateTime FromDate { set; get; }
        public DateTime EndDate { set; get; }
        public DateTime NotificationDate { set; get; }
        public int TransactionId { set; get; }
        public DateTime RenewedOn { set; get; }
    }
    public class Payment
    {
        public int Id { set; get; }
        public int PaymentTypeId { set; get; }
        public int Amount { set; get; }
        public DateTime date { set; get; }
        public int TransactionId { set; get; }
    }
    public class Smsformat
    {
        public int Id { set; get; }
        public string message { set; get; }
        public int Active { set; get; }
        public string Desc1 { set; get; }
        public string fromaddr { set; get; }
        public string ToAddr { set; get; }
        public int BTPOSGrpId { set; get; }
    }
    public class Gmailformat
    {
        public int Id { set; get; }
        public string message { set; get; }
        public int Active { set; get; }
        public string Desc1 { set; get; }
        public string Fromaddr { set; get; }
        public string Toaddrs { set; get; }
        public int BTPOSGrpId { set; get; }
    }
    public class BTPOSOPRTR
    {
        public int Id { set; get; }
        public int BTPOSId { set; get; }
        public int Userid { set; get; }
        public int Active { set; get; }
    }
    public class BTPOSLoc
    {
        public int Id { set; get; }
        public int BTPOSid { set; get; }
        public int Xcord { set; get; }
        public int Ycord { set; get; }
        public TimeSpan time { set; get; }
        public DateTime date { set; get; }
        
    }
    public class Address
    {
        public int Id { set; get; }
        public int cityid { set; get; }
        public int stateid { set; get; }
        public int countryid { set; get; }
        public string street1 { set; get; }
        public string street2 { set; get; }
        public int zipcodeid { set; get; }
        public string City { set; get; }
        public string country { set; get; }
        public string State { set; get; }
        public string zipcode { set; get; }
    }
    public class SMSEmailSettings
    {
        public int AlertTypeId { set; get; }
        public string fromaddress { set; get; }
        public int Id { set; get; }
        public string smsemailtext { set; get; }
        public string toaddres { set; get; }
    }
    public class PrinterData
    {
        public int BtPOSidId { set; get; }
        public int Id { set; get; }
        public string ipconfig { set; get; }
        public string printeddata { set; get; }
        public string transactionId { set; get; }
    }
    public class SecurityLog
    {
        public int Id { set; get; }
        public string logdata { set; get; }
        public DateTime logedon { set; get; }
        public string source { set; get; }
    }
    public class ReportsFields
    {
        public string fieldName { set; get; }
        public int Id { set; get; }
        public string ReportTypeId { set; get; }
        }
    public class SystemLog
    {
        public int Id { set; get; }
        public string logdata { set; get; }
        public DateTime logedon { set; get; }
        public string source { set; get; }
    }
    public class UserLog
    {
        public int Id { set; get; }
        public string logdata { set; get; }
        public DateTime logedon { set; get; }
        public string source { set; get; }
        public int userid { set; get; }
    }
    public class ErrorCodes
    {
        public int Id { set; get; }
        public int Active { set; get; }
        public string Desc1 { set; get; }
        public string ErrrorCode {set;get;}
        public int Typegrpid { set; get; }
    }
    public class ReportsTypes
    {
        public int Id { set; get; }
        public int Active { set; get; }
        public string Desc1 { set; get; }
        public string ReportType { set; get; }
        public int Typegrpid { set; get; }
    }
    public class CardStatuses
    {
        public int Id { set; get; }
        public int Active { set; get; }
        public string CardStatus { set; get; }
        public string Desc1 { set; get; }
        public int Typegrpid { set; get; }
    }
    public class TypeGroups
    {
        public int Id { set; get; }
        public int Active { set; get; }      
        public string Desc1 { set; get; }
        public string Name { set; get; }
    }
    public class ExpensesClass
    {
        public int Id { set; get; }
        public int Active { set; get; }
        public string ExpenseType { set; get; }
        public string Desc1 { set; get; }
        public int Typegrpid { set; get; }
    }
    public class NOCBtPosStatus
    {
        public int Id { set; get; }
        public int Active { set; get; }
        public string NOCBtPostatus { set; get; }
        public string Desc1 { set; get; }
        public int Typegrpid { set; get; }
    }
    public class CardTypes 
    {
        public int Id { set; get; }
        public int Active { set; get; }
        public string Cardtype { set; get; }
        public string Desc1 { set; get; }
        public int Typegrpid { set; get; }
    }
    public class Types1
    {
        public int Id { set; get; }
        public int Active { set; get; }
        public string GroupName { set; get; }
        public string Desc1 { set; get; }
        public int Key1 { set; get; }
         public string Name { set; get; }
         public int Typegrpid { set; get; }
        public string Value { set; get; }
    }
    public class RouteType
    {
        public int Id { set; get; }
        public int Active { set; get; }
        public string Routetype { set; get; }
        public string Desc1 { set; get; }
        public int Typegrpid { set; get; }
    }
    public class AccessType
    {
        public int Id { set; get; }
        public int Active { set; get; }
        public string Accesstype { set; get; }
        public string Desc1 { set; get; }
        public int Typegrpid { set; get; }
    }
    public class LicenseKeyFile
    {
        public int Id { set; get; }
        public int BTPOSid { set; get; }
        public string EncrptyKey1 { set; get; }
        public string EncrptyKey2 { set; get; }
        public string keyfilename { set; get; }
    }
     public class FirmwareDetails
    {
        public int Id { set; get; }
        public int BTPOSid { set; get; }
        public string Desc1 { set; get; }
        public string FirmwareVersion { set; get; }
        public string Ipconfig { set; get; }
    }
     public class Users12
     {
         public int Id { set; get; }
         public string FirstName { set; get; }
         public string LastName { set; get; }
         public int UserType { set; get; }
         public int EmpNo { set; get; }
         public string Email { set; get; }
         public int AdressId { set; get; }
         public int MobileNo { set; get; }
         public string Role1 { set; get; }
         public int Active { get; set; }
         
     }
}