using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTPOSDashboardAPI.Models
{
    public class Alerts
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public string MessageTypeId { get; set; }
        public string StatusId { get; set; }
        public string UserId { get; set; }

        public string Name { get; set; }
    }
    public class Notifications
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public string MessageTypeId { get; set; }
        public string StatusId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
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

    public class BtposRecords
    {

        public int Id { get; set; }
        public string RecordData { get; set; }
        public int POSID { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime Downloaded { get; set; }

        public DateTime LastDownloadtime { get; set; }

        public int IsDirty { get; set; }

        public char insupddelflag { get; set; }

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


        public string ObjectName { get; set; }

        public string Path { get; set; }

    }
    public class roles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Active { get; set; }
        public string IsPublic { get; set; }
        public string Company { get; set; }
        public int CompanyId { get; set; }


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
    public class UserLogin
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
        public int CompanyId { set; get; }
        public int RoleId { set; get; }
        public int flag { set; get; }
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

    public class Routes
    {
        public int Id { set; get; }
        public string RouteName { set; get; }
        public string Code { set; get; }
        public string Description { set; get; }
        public int Active { set; get; }
        public decimal Distance { set; get; }
        public string Source { set; get; }
        public string Destination { set; get; }
        public int SourceId { set; get; }
        public int DestinationId { set; get; }
    }

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

    public class TypeGroups
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Active { get; set; }
        public string insupddelflag { get; set; }
    }

    public class Types
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Active { get; set; }



        public string TypeGroupId { get; set; }

        public string ListKey { get; set; }

        public string Listvalue { get; set; }
        public string insupddelflag { get; set; }
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

        public int InventoryId { get; set; }
        public string Name { get; set; }

        public string Image { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int AvailableQty { get; set; }

        public int Category { get; set; }
        public int SubCategory { get; set; }
        public int PerUnitPrice { get; set; }

        public int ReorderPont { get; set; }
        public int Active { get; set; }
        public string insupdflag { get; set; }

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

        public string CompanyId { get; set; }

        public string IMEI { get; set; }

        public string POSID { get; set; }

        public int StatusId { get; set; }

        public string ipconfig { get; set; }
        public string fleetowner { get; set; }
        public int? fleetownerid { get; set; }
        public int active { get; set; }

        public string insupdflag { get; set; }

    }
    public class VehicleDetails
    {
        public int busId { get; set; }

        public int busTypeId { get; set; }

        public int conductorId { get; set; }

        public string conductorName { get; set; }

        public int driverId { get; set; }

        public string driverName { get; set; }

        public int fleetOwnerId { get; set; }

        public string CompanyName { get; set; }

        public int Id { get; set; }

        public int POSID { get; set; }

        public string RegNo { get; set; }

        public string route { get; set; }

        public string Status { get; set; }

        public int statusid { get; set; }
        public int Active { get; set; }
        public string insupdflag { get; set; }
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

        public string desc { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
        public string ContactNo1 { get; set;}
        public string ContactNo2 { get; set; }
        public string Fax { get; set;}
        public string EmailId { get; set; }
        public string Title { get; set; }
        public string Caption { get; set; }
        public string Country { get; set; }
        public int ZipCode { get; set; }
        public string State { get; set; }

        public string insupdflag { get; set; }

    }

    public class CompanyRoles
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string RoleId { get; set; }
        public string Active { get; set; }
        public string IsPublic { get; set; }
        public string Company { get; set; }
        public int CompanyId { get; set; }

        public int insdelflag { get; set; }

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
        public int RefId { get; set; }

        public string Type { get; set; }

        public string createdBy { get; set; }

        public string Raised { get; set; }

        public string TicketTitle { get; set; }

        public string IssueDetails { get; set; }

        public string AddInfo { get; set; }

        public int Status { get; set; }

        public string Asign { get; set; }  	

        public int Id{get;set;}

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

        public DateTime Date { get; set; }

        public string destination { get; set; }

        public string fare { get; set; }

        public string greetingMessage { get; set; }

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

        public int totalamount { get; set; }

        public int amountpaid { get; set; }

        public string TransactionCode { get; set; }

        public string TransactionId { get; set; }

        public string transactionType { get; set; }

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
        public string ErrrorCode { set; get; }
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
    public class Users
    {
        public int Id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string MiddleName { set; get; }
        public string UserType { set; get; }
        public int UserTypeId { set; get; }
        public string EmpNo { set; get; }
        public string Email { set; get; }
        public string Adress { set; get; }
        public int AdressId { set; get; }
        public string MobileNo { set; get; }
        public string Role { set; get; }
        public int RoleId { set; get; }
        public int Active { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string insupdflag { get; set; }
        public int companyId { set; get; }
        public int Company { set; get; }
        public int? mgrId { set; get; }
        public int ManagerName { set; get; }
    }

    public class Register
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Emailaddress { get; set; }
        public string ConfirmPassword { get; set; }
        public string Gender { get; set; }
    }

    public class login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int result { get; set; }
    }
    public class stops
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int Active { get; set; }
        public string insupdflag { get; set; }
    }
    public class Objects
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Path { get; set; }
        public int Active { get; set; }
        public string insupddelflag { get; set; }

    }
    public class ObjectAccess
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int ObjectId { get; set; }

        public int AccessId { get; set; }
    }
    public class RouteDetails
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public decimal DistanceFromSource { get; set; }
        public decimal DistanceFromDestination { get; set; }
        public decimal DistanceFromPreviousStop { get; set; }
        public decimal DistanceFromNextStop { get; set; }
        public int PreviousStopId { get; set; }
        public int NextStopId { get; set; }
        public String StopName { get; set; }
        public String StopCode { get; set; }
        public int stopId { get; set; }
        public String prevstop { get; set; }
        public String nextstop { get; set; }
        public int StopNo { get; set; }
        public String insupddelflag { get; set; }
        public int FleetOwnerId { get; set; }

    }
    public class ISales
    {
        public int Id { get; set; }
        public String ItemName { get; set; }
        public int Quantity { get; set; }

        public int PerUnitPrice { get; set; }
        public String PurchaseDate { get; set; }
        public int InVoiceNumber { get; set; }
    }
    public class IPurchases
    {
        public int Id { get; set; }
        public String ItemName { get; set; }
        public String ItemCode { get; set; }
        public int Quantity { get; set; }

        public int PerUnitPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public int subCategoryId { get; set; }

        public string subCategory { get; set; }
    }
    public class InventoryItem
    {
        public int Id { get; set; }

        public String ItemName { get; set; }
        public String Code { get; set; }

        public String Description { get; set; }
        public String Category { get; set; }
        public String SubCategory { get; set; }

        public int ReOrderPoint { get; set; }
    }

    public class FleetOwnerRequest
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String MobileNo { get; set; }
        public String CompanyName { get; set; }
        public String Description { get; set; }
        public string insupdflag { get; set; }
    }
       
    public class RouteFare
    {
        public int Id { get; set; }

        public int RouteId { get; set; }
        public string VehicleType { get; set; }


        public int SourceStopId { get; set; }
        public int DestinationStopId { get; set; }
        public string Distance { get; set; }
        public int PerUnitPrice { get; set; }

        public int Amount { get; set; }

        public String FareType { get; set; }
        public int Active { get; set; }
    }
    public class FleetownerRoute
    {
        public int Id { get; set; }
        public int FleetOwnerId { get; set; }

        public int CompanyId { get; set; }

        public int RouteId { get; set; }

        public DateTime? From { get; set; }

        public DateTime? To { get; set; }
        public int Active { get; set; }
        public string insupddelflag { get; set; }
    }
    public class FleetOwnerRouteStop
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public int FleetOwnerId { get; set; }

        public int StopId { get; set; }

        public int StopNo { get; set; }
        public String PreviousStop { get; set; }
        public String NextStop { get; set; }

        public int Active { get; set; }
    }
    public class FleetOwnerRouteFare
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public string VehicleTypeId { get; set; }
        public int FromStopId { get; set; }
        public int ToStopId { get; set; }
        public decimal Distance { get; set; }
        public decimal PerUnitPrice { get; set; }
        public decimal Amount { get; set; }
        public String FareType { get; set; }
        public int FareTypeId { get; set; }
        public int VehicleId { get; set; }
        public int Active { get; set; }
        public int FleetOwnerId { get; set; }
        public int CompanyId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string insupddelflag { get; set; }
    }

    public class LicenseDetails
    {


        public int Id { get; set; }
        public string FeatureName { get; set; }
        public String FeatureLabel { get; set; }
        public String LicenseCode { get; set; }
        public String LicenseName { get; set; }
        public String FeatureValue { get; set; }
        public String LabelClass { get; set; }

        public int Active { get; set; }
        public int LicenseTypeId { get; set; }
        public int LicenseCatId { get; set; }
        public DateTime? fromDate { get; set; }
        public DateTime? toDate { get; set; }
        public string insupddelflag { get; set; }
    }

    public class LicensePricing
    {
        public int LicenseId { get; set; }
        public String RenewalFreqType { get; set; }
        public int RenewalFreqTypeId { get; set; }
        public int RenewalFreqUnit { get; set; }
        public string RenewalFreq { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime? fromdate { get; set; }
        public DateTime? todate { get; set; }
        public int Id { get; set; }

        public int categoryid { get; set; }
        public int Active { get; set; }
        public string insupddelflag { get; set; }
    }

    public class FleetDetails
    {
        public int VehicleLayoutId;
        public string VehicleLayout;
        public int Id { get; set; }

        public string VehicleRegNo { get; set; }
        public int VehicleTypeId { get; set; }

        public String FleetOwnerId { get; set; }
        public String CompanyId { get; set; }
        public String ServiceTypeId { get; set; }

        public int Active { get; set; }

        public String EngineNo { get; set; }

        public String FuelUsed { get; set; }

        public DateTime? MonthAndYrOfMfr { get; set; }

        public string ChasisNo { get; set; }

        public int SeatingCapacity { get; set; }

        public DateTime? DateOfRegistration { get; set; }
    }
    public class FleetRoutes
    {
        public int Id { get; set; }
        public string VehicleRegNo { get; set; }
        public string RouteName { get; set; }
        public string RouteCode { get; set; }
        public int VehicleId { get; set; }
        public int RouteId { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public DateTime? EffectiveTill { get; set; }
        public int Active { get; set; }
        public int cmpId { get; set; }
        public int fleetownerId { get; set; }
        public string insupddelflag { get; set; }
    }
    public class FleetAvailability
    {
        public int Id { get; set; }
        public string VehicleRegNo { get; set; }
        public int VehicleId { get; set; }
        public string FleetOwner { get; set; }
        public int fleetOwnerId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string insupddelflag { get; set; }
    }

    public class FleetStaff
    {
        public int Id { get; set; }
        public int cmpId { get; set; }
        public int roleId { get; set; }
        public int vehicleId { get; set; }
       
        public int UserId { get; set; }

        public int RoleName { get; set; }
        public int Company { get; set; }

        public string VechileRegNo { get; set; }
        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public int Active { get; set; }
        public string insupddelflag { get; set; }
    }

    public class FleetBTPOS
    {
        public int Id { get; set; }
        public int cmpId { get; set; }
        public int posId { get; set; }
        public int vehicleId { get; set; }

        public int fleetOwnerId { get; set; }

        public string BTPOSId { get; set; }        

        public string VechileRegNo { get; set; }
        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
               
        public string insupddelflag { get; set; }
    }

    public class VehicleConfig
    {
        public int? needFleetDetails { get; set; }
        public int? needRoutes { get; set; }
        public int? needRoles { get; set; }
        public int? needusers { get; set; }
        public int? needfleetowners { get; set; }
        public int? needvehicleType { get; set; }
        public int? needvehicleRegno { get; set; }
        public int? needServiceType { get; set; }
        public int? needCompanyName { get; set; }
        public int? needVehicleLayout { get; set; }
        public int? needFleetRoute { get; set; }
        public int? needRouteName { get; set; }
        public int? needHireVehicle { get; set; }
        public int? needbtpos { get; set; }
        public int? cmpId { get; set; }
        public int? fleetownerId { get; set; }
        public int? needfleetownerroutes { get; set; }

    }

    public class LicenseTypes {
        public int Id { set; get; }
        public int Active { set; get; }
        public string LicenseType { set; get; }
        public string Desc { set; get; }       
        public string LicenseCategory { set; get; }
        public int LicenseCategoryId { set; get; }
        
    }
    public class Inventory
    {
        public int Active { set; get; }
        public int availableQty { set; get; }
        public string category {set; get;}
        public string code { set; get; }
        public string desc { set; get; }
        public int InventoryId { set; get; }
        public  string name { set; get; }
        public  int PerUnitPrice{set; get;}
        public int reorderpoint{set; get;}
        public string subcat{set; get;}
    }
    public class PurchaseOrder
    {
        public int Id { set; get; }
        public string PONum { set; get; }
        public int TranscationId { set; get; }
        public DateTime? Date { set; get; }
        public decimal amount { set; get; }
        public int itemId { set; get; }
        public decimal Quantity { set; get; }
        public int StatusId { set; get; }
    }
    public class VehicleLayout
    {
        //public int Id { get; set; }
        public int VehicleLayoutTypeId { get; set; }
        public int RowNo { get; set; }
        public int ColNo { get; set; }
        public int VehicleTypeId { get; set; }
        public String label { get; set; }
        public string insupdflag { get; set; }
        //public int FleetOwnerId { get; set; }
    }
    public class FleetOwnerVehicleLayout
    {
        public int VehicleLayoutTypeId { get; set; }
        public int RowNo { get; set; }
        public int ColNo { get; set; }
        public int VehicleTypeId { get; set; }
        public String label { get; set; }
        public string insupdflag { get; set; }
        public int FleetOwnerId { get; set; }
    }

    
    public class reset
    {

        public string UserName { set; get; }
        public string OldPassword { set; get; }
        public string NewPassword { set; get; }
        public string ReenterNewPassword { set; get; }

    }
    public class FORouteFleetSchedule               
 {
       // public int Id { get; set; }
       public int VehicleId { get; set; }
       public int RouteId  {get; set; }
         public int FleetOwnerId  {get; set; }
          public int StopId { get; set; }
          public int ArrivalHr  {get; set; }
          public int DepartureHr  {get; set; }
          public decimal Duration  {get; set; }
         public int ArrivalMin {get; set; }
         public int DepartureMin  {get; set; }
        public string ArrivalAMPM {get; set; }
        public string DepartureAmPm {get; set; }
       public DateTime arrivaltime{get; set; }
         public DateTime departuretime{get; set; }

         public string StopName { get; set; }
         public string StopCode { get; set; }
         public string StopNo { get; set; }
         public string insupddelflag { get; set; }

    }

    public class ShoppingCart
    {
        public string ItemName { set; get; }
        public decimal UnitPrice { set; get; }
        public int ItemId { set; get; }

        public string insupddelflag { set; get; }
     
    }
    public class BTPOSMoitoringPage
    {
        public int BTPOSId { get; set; }
        public float Xcoordinate { get; set; }
        public float Ycoordinate { get; set; }
        public string LocationName { get; set; }
        public int SNo { get; set; }
        public DateTime DateTime { get; set; }

    }
}                     
        

