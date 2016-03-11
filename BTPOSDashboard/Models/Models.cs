using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAshboard.Models
{
    public class Model
    {
        public int Id { get; set; }
      public DateTime Date {get;set;}
      public string Message { get; set; }
      public string MessageTypeId { get; set; }
      public string Status { get; set; }
    }
    public class Btpos
    {

        public int Id { get; set; }
        public int GroupId { get; set; }
        public int POSId { get; set; }
        public string Status { get; set; }
        public string IMEI { get; set; }
        public string Location { get; set; }
    }
    public class btposgroups
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string Desc { get; set; }
        public string Active { get; set; }
        public string Code { get; set; }
       
    }
    public class master
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Code { get; set; }
        public string Subcat { get; set; }
        public string Active { get; set; }

    }
    public class detail
    {
        public int Id { get; set; }
        public int InventoryId { get; set; }
        public int PerUnitPrice { get; set; }
        public string ReorderPoint { get; set; }
        public int AvailableQty { get; set; }
   

    }
    public class roledetails
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int ScreenId { get; set; }
        public string Access { get; set; }
        


    }
    public class roles
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int Desc { get; set; }
        public string Active { get; set; }

    }
    public class Blocklist
    {
        public string Id { get; set; }
        public int ItemId { get; set; }
        public string ItemTypeId { get; set; }
        public string Formdate { get; set; }
        public string Todate { get; set; }
        public string Active { get; set; }
        public string Desc { get; set; }
        public string Reason { get; set; }
        public string Blockedby { get; set; }
        public string UnBlockedby { get; set; }
        public string Blockedon { get; set; }
        public string UnBlockedon { get; set; }

    }
    public class COUNTRY
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Active { get; set; }

    }
    public class Payables
    {
        public int Id { get; set; }
        public string Amount { get; set; }
        public int MasterId { get; set; }
        public string Paidby { get; set; }

    }
    public class PayablesMaster
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string PaidFor { get; set; }
        public string Desc { get; set; }

    }
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
  
    public class logins
    {
        public int Id { set; get; }
        public int UserId { set; get; }
        public string LoginInfo { set; get; }
        public string Passkey { set; get; }
        public string Salt { set; get; }
        public string Active { set; get; }

      
    }
    public class userroles
    {
        public int Id { set; get; }
        public int UserId { set; get; }
        public int GroupId { set; get; }
        public int RoleId { set; get; }
        public string Passkey { set; get; }
     
    }
  
    public class STATE
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Count { get; set; }
        public string Code { get; set; }
        public string Active { get; set; }


    }

    public class SMSProviderConfig
    {

        public int Id { get; set; }
        public string ProviderName { get; set; }
        public string BTPOSGRPID { get; set; }
        public string Active { get; set; }
        public int UserId { get; set; }
        public string Passkey { get; set; }

    }
    public class ReceivingsMaster
    {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ReceivedFor { get; set; }
        public string Desc { get; set; }

    }
    public class Receivings
    {

        public int Id { get; set; }
        public string Amount { get; set; }
        public int MasterId { get; set; }
        public string ReceivedBy { get; set; }

    }
    public class Paymentgateway
    {

        public int Id { get; set; }
        public string ProviderName { get; set; }
        public string BTPOSGRPID { get; set; }
        public string Active { get; set; }
        public int UserId { get; set; }
        public string Passkey { get; set; }
        public string Url { get; set; }
        public string Testurl { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }


    }
    public class ZipCode
    {
         public int Id { get; set; }
        public string Code { get; set; }
        public string Active { get; set; }

    }
    public class BTPOSOPRTR
    {
        public int Id { set; get; }
        public int BTPOSId { set; get; }
        public int Userid { set; get; }
        public int Active { set; get; }
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
    public class Types
    {
        public int Id { set; get; }
        public string Desc { set; get; }
        public string Name { set; get; }
        public string Active { set; get; }
        public int TypeGroupId { set; get; }

        public object TypeGroup { get; set; }
    }
public class TypeGroups
{
    public int Id { set; get; }
    public string Desc { set; get; }
    public string Name { set; get; }
    public string Active { set; get; }
}
public class BusDetails
{
    public int busId { get; set; }

    public int busTypeId { get; set; }

    public int conductorId { get; set; }

    public string conductorName { get; set; }

    public int driverId { get; set; }

    public string driverName { get; set; }

    public int fleetOwnerId { get; set; }

    public string groupname { get; set; }

    public int Id { get; set; }

    public int POSID { get; set; }

    public string RegNo { get; set; }

    public string route { get; set; }

    public string Status { get; set; }

    public int statusid { get; set; }

}

}