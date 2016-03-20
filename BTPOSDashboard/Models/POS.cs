using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POSDBAccess.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public string TransCode { get; set; }

        public string TransType { get; set; }

        public DateTime Date { get; set; }

        public string TransId { get; set; }

        public int TotalAmt { get; set; }

        public string PaymentId { get; set; }

        public string BTPOSid { get; set; }

    }

    public class EditHistory
    {

        public string Field { get; set; }

        public string SubItem { get; set; }

        public string Comment { get; set; }

        public DateTime Date { get; set; }

        public string ChangedBy { get; set; }

        public string ChangedType { get; set; }
    }

    public class EditHistoryDetails
    {

        public int EditHistoryId { get; set; }

        public string FromValue { get; set; }

        public string ToValue { get; set; }

        public string ChangeType { get; set; }

        public string Field1 { get; set; }

        public string Field2 { get; set; }
    }

    public class 	TypeGroups
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }

        public string Active { get; set; }

    }

    public class Types
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }

        public string Active { get; set; }

        public string IsVisible { get; set; }

        public string TypeGroup { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

    }

    public class RouteFares
    {
        public int Id { get; set; }

        public string RouteId { get; set; }

        public string Stopname { get; set; }

        public string Descr { get; set; }

        public string StopCode { get; set; }
        
        public object ToStop { get; set; }

        public object FromStop { get; set; }

        public object Fare { get; set; }

        public string Route { get; set; }

        public string Active { get; set; }

        public string Source { get; set; }

        public string Destination { get; set; }

        public string Code { get; set; }

        public string BTPOSGrpId { get; set; }

        public string Name { get; set; }
        
        public int DistFromSource { get; set; }

        public int DistFromDestination { get; set; }

        public int DistFromPrevStop { get; set; }

        public int DistFromNextStop { get; set; }

    }

       public class FleetOwner
       {
           public int Id { get; set; }

           public string UserId { get; set; }

           public string BTPOSgroupid { get; set; }

           public string Active { get; set; }

       }

       public class TroubleTicketingCategories
       {
           public int active { get; set; }

           public string desc { get; set; }

           public int Id { get; set; }

           public string TTCategory { get; set; }

           public int typegrpid { get; set; }

       }

       public class TransactionType
       {
           public int active { get; set; }

           public string desc { get; set; }

           public int Id { get; set; }

           public string TransactionTypes { get; set; }

           public int typegrpid { get; set; }

       }
       public class Inventory1
       {
           public int Active { get; set; }

           public int availableQty { get; set; }

           public string category { get; set; }

           public string code { get; set; }

           public string desc { get; set; }

           public int InventoryId { get; set; }

           public string name { get; set; }

           public int PerUnitPrice { get; set; }

           public int reorderpoint { get; set; }

           public string subcat { get; set; }

       }
       public class Expenses
       {
           public int amount { get; set; }

           public string Date { get; set; }

           public string desc { get; set; }

           public int Id { get; set; }

           public int MasterId { get; set; }

           public string paidBy { get; set; }

           public string paidFor { get; set; }

           public int transactionId { get; set; }

       }
       public class LicensePayments
       {
           public DateTime expiryOn { get; set; }

           public int Id { get; set; }

           public string licenseFor { get; set; }

           public int licenseId { get; set; }

           public string licenseType { get; set; }

           public DateTime paidon { get; set; }

           public DateTime renewedon { get; set; }

           public string transId { get; set; }

       }
       public class BTPOSInventorySales
       {
           public int amount { get; set; }

           public string code { get; set; }

           public int Id { get; set; }

           public int inventoryId { get; set; }

           public int perunit { get; set; }

           public int quantity { get; set; }

           public string soldon { get; set; }

           public int transactionId { get; set; }

           public string transactiontype { get; set; }

       }

       public class BTPOSDetails
       {
        
           public int Id { get; set; }

           public string GroupName { get; set; }

           public int GroupId { get; set; }

           public string IMEI { get; set; }

           public string Location { get; set; }

           public int POSID { get; set; }

           public int StatusId { get; set; }

           public string Status { get; set; }

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

       public class RouteFare
       {
           public int active { get; set; }

           public int fareCodeId { get; set; }

           public int Id { get; set; }

           public int routeId { get; set; }

       }

       public class RoutesConfiguration
       {
           public int distanceFromDest { get; set; }

           public int distanceFromLastStop { get; set; }

           public int distanceFromPrevStop { get; set; }

           public int distanceFromSource { get; set; }

           public int Id { get; set; }

           public int routeId { get; set; }

           public string stops { get; set; }

       }

       public class CompanyGroups
       {
           public int active { get; set; }

           public string admin { get; set; }

           public int adminId { get; set; }

           public string code { get; set; }

           public string descr { get; set; }

           public int Id { get; set; }

           public string Name { get; set; }

       }

       public class PaymentReceivings
       {
           public int amount { get; set; }

           public string code { get; set; }

           public string date { get; set; }

           public int desc { get; set; }

           public int Id { get; set; }

           public int inventoryId { get; set; }

           public int quantity { get; set; }

           public string receivedOn { get; set; }

           public int transactionId { get; set; }

           public string transactiontype { get; set; }

       }
       public class InventoryReceivings
       {
           public int amount { get; set; }

           public string code { get; set; }

           public string date { get; set; }

           public int Id { get; set; }        

           public int inventoryId { get; set; }

           public int quantity { get; set; }

           public string reason { get; set; }

           public int refundamt { get; set; }

           public string returnedOn { get; set; }

           public int transactionId { get; set; }

           public string transactiontype { get; set; }

       }
       
       public class TroubleTicketingDetails
       {
           public string addInfo { get; set; }

           public string createdBy { get; set; }

           public int createdOn { get; set; }

           public int Id { get; set; }

           public string raisedBy { get; set; }

           public int status { get; set; }

           public string ticketinfo { get; set; }

           public int ticketTypeId { get; set; }

           public int TTId { get; set; }

       }
       public class TroubleTicketingHandlers
       {
           public int handledOn { get; set; }

           public int Id { get; set; }

           public int status { get; set; }

           public int TTId { get; set; }

           public int userid { get; set; }

       }

       public class TroubleTicketingDevice
       {
           public int deviceid { get; set; }

           public int Id { get; set; }

           public int ticketTypeId { get; set; }

           public int TTId { get; set; }
       }

       public class SMSEmailSubscribers
       {
           public int AlertId { get; set; }

           public string emailid { get; set; }

           public DateTime enddate { get; set; }

           public int frequency { get; set; }

           public int Id { get; set; }

           public string phNo { get; set; }

           public DateTime startdate { get; set; }

           public int userid { get; set; }
       }

       public class SMSEmailConfiguration
       {
           public int AlertTypeId { get; set; }

           public DateTime enddate { get; set; }

           public DateTime hashkey { get; set; }   
           
           public int Id { get; set; }

           public string providername { get; set; }

           public string pwd { get; set; }

           public DateTime saltkey { get; set; }

           public DateTime startdate { get; set; }

           public string username { get; set; }
       }

       public class PaymentGatewaySettings
       {
           public DateTime enddate { get; set; }

           public DateTime hashkey { get; set; }

           public int Id { get; set; }

           public int PaymentGatewayTypeId { get; set; }

           public string providername { get; set; }

           public string pwd { get; set; }

           public DateTime saltkey { get; set; }

           public DateTime startdate { get; set; }

           public string username { get; set; }
       }

       public class Transactions
       {
           public int Id { get; set; }

           public string barcode { get; set; }

           public string BTPOSid { get; set; }

           public string busNumber { get; set; }

           public int busId { get; set; }

           public string change { get; set; }

           public string company { get; set; }

           public string companyId { get; set; }

           public string ConductorId { get; set; }

           public string ConductorName { get; set; }

           public string Date { get; set; }

           public string destination { get; set; }

           public string fare { get; set; }

           public string greetingMssg { get; set; }

           public string luggageType { get; set; }

           public string passengerType { get; set; }

           public string passengerId { get; set; }

           public string paymentId { get; set; }

           public string printdataId { get; set; }

           public string route { get; set; }

           public string routecode { get; set; }

           public string routeId { get; set; }

           public string source { get; set; }

           public DateTime time { get; set; }

           public string ticketHolderId { get; set; }

           public string ticketHolderName { get; set; }

           public string TicketNumber { get; set; }

           public string ticketValidityPeriod { get; set; }

           public int totalamt { get; set; }

           public int amtpaid { get; set; }

           public string TransactionCode { get; set; }

           public string TransId { get; set; }

           public string transType { get; set; }

           public int userid { get; set; }

           public string ChangeRendered { get; set; }

       }
       public class RegistrationBTPOS
       {
           public string code { get; set; }

           public string uniqueId { get; set; }

           public string ipconfig { get; set; }

           public string RegeneratedNo { get; set; }

           public int Active { get; set; }
       }

    public class loginpage
    {
        public string userid { get; set; }

        public string password { get; set; }
    }
    public class TicketGeneration
    {
        public string Source { get; set; }
        public string Target { get; set; }
        public int NoOfTickets { get; set; }
    }
    }