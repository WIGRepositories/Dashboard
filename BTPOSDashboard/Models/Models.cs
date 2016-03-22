using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTPOSDashboardAPI.Models
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
        public string Name { get; set; }
        public string Description { get; set; }
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
    
    public class Types
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Desc { set; get; }
       
        public string TypeGroup { get; set; }
        public string Active { set; get; }
    }

    public class Routes
    {
        public int Id{set;get;}
     public string Route {set;get;}
       public string Code {set;get;}
      public string Description {set;get;} 
      public string Active {set;get;} 
       public string BTPOSGroupId {set;get;}
      public string Source {set;get;} 
      public string Destination {set;get;} 
    }
}