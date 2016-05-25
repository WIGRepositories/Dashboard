USE [POSDashboard]

/****** Object:  Table [dbo].[Alerts]    Script Date: 05/05/2016 18:38:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Alerts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Message] [varchar](50) NOT NULL,
	[MessageTypeId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Alerts] ADD  CONSTRAINT [DF_AlertNotifications_UserId]  DEFAULT ((1)) FOR [UserId]
GO

/****** Object:  Table [dbo].[Notifications]    Script Date: 05/05/2016 18:40:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Notifications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Message] [varchar](500) NOT NULL,
	[MessageTypeId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Notifications] ADD  CONSTRAINT [DF_Notifications_UserId]  DEFAULT ((1)) FOR [UserId]
GO


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expenses](
	[amount] [int] NOT NULL,
	[Date] [varchar](50) NOT NULL,
	[desc] [varchar](50) NOT NULL,
	[Id] [varchar](50) NOT NULL,
	[MasterId] [int] NOT NULL,
	[paidBy] [varchar](50) NOT NULL,
	[paidFor] [varchar](50) NOT NULL,
	[transactionId] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EditHistory]    Script Date: 05/04/2016 17:20:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO


CREATE TABLE [dbo].[EditHistory](
	[Field] [varchar](50) NOT NULL,
	[SubItem] [varchar](50) NOT NULL,
	[Comment] [varchar](50) NOT NULL,
	[Date] [datetime] NOT NULL,
	[ChangedBy] [varchar](50) NOT NULL,
	[ChangedType] [varchar](50) NOT NULL,
	[Task] [varchar](50) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EditHistoryDetails]    Script Date: 05/04/2016 17:21:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[EditHistoryDetails](
	[EditHistoryId] [int] NOT NULL,
	[FromValue] [varchar](50) NULL,
	[ToValue] [varchar](50) NULL,
	[ChangeType] [varchar](50) NOT NULL,
	[Field1] [varchar](50) NULL,
	[Field2] [varchar](50) NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO

/****** Object:  StoredProcedure [dbo].[InsEditHistory]    Script Date: 05/04/2016 17:21:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[InsEditHistory]
(@Task varchar(50) =null,@Field varchar(50) =null
           ,@SubItem varchar(50) =null
           ,@Comment varchar(50) =null
           ,@Date datetime
           ,@ChangedBy varchar(50) =null
           ,@ChangedType varchar(50) =null           
           ,@edithistoryid int = -1 OUTPUT)
as
begin


INSERT INTO [POSDashboard].[dbo].[EditHistory]
           ([Field]
           ,[SubItem]
           ,[Comment]
           ,[Date]
           ,[ChangedBy]
           ,[ChangedType]
           ,[Task])
     VALUES
           (@Field
           ,@SubItem
           ,@Comment
           ,@Date
           ,@ChangedBy
           ,@ChangedType
           ,@Task)

 SELECT @edithistoryid = @@IDENTITY



end

GO

/****** Object:  StoredProcedure [dbo].[InsEditHistoryDetails]    Script Date: 05/04/2016 17:21:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[InsEditHistoryDetails]
(@EditHistoryId  int
         ,@FromValue varchar(50) = null
           ,@ToValue varchar(50)= null
           ,@ChangeType varchar(50)
           ,@Field1 varchar(50) = null
           ,@Field2 varchar(50) = null)
AS
BEGIN
	INSERT INTO [POSDashboard].[dbo].[EditHistoryDetails]
           ([EditHistoryId]
           ,[FromValue]
           ,[ToValue]
           ,[ChangeType]
           ,[Field1]
           ,[Field2])
     VALUES
           (@EditHistoryId
           ,@FromValue
           ,@ToValue
           ,@ChangeType
           ,@Field1
           ,@Field2)

END


CREATE TABLE [dbo].[COUNTRY](
	[ID] [numeric](18, 0) NULL,
	[Name] [nchar](10) NULL,
	[Code] [nchar](10) NULL,
	[Active] [nchar](10) NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Desc] [varchar](50) NULL,
	[Active] [int] NOT NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[CompanyRoles]    Script Date: 05/05/2016 10:16:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CompanyRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[Active] [int] NOT NULL
) ON [PRIMARY]

GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BTPOSSheduleUploads](
	[Id] [numeric](18, 0) NULL,
	[POSID] [numeric](18, 0) NULL,
	[UploadOn] [nchar](10) NULL,
	[UploadedOn] [nchar](10) NULL,
	[Status] [nchar](10) NULL,
	[UploadData] [nchar](10) NULL,
	[Ipconfig] [nchar](10) NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BTPOSSecheduledUpdates](
	[Id] [numeric](18, 0) NULL,
	[POSID] [numeric](18, 0) NULL,
	[UploadOn] [nchar](10) NULL,
	[UploadedOn] [nchar](10) NULL,
	[Status] [nchar](10) NULL,
	[UploadData] [nchar](10) NULL,
	[IpConfig] [nchar](10) NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BTPOSRegistration](
	[Id] [numeric](18, 0) NULL,
	[POSID] [numeric](18, 0) NULL,
	[Status] [nchar](10) NULL,
	[FleetOwenerId] [numeric](18, 0) NULL,
	[RegisteredOn] [nchar](10) NULL,
	[IpConfig] [nchar](10) NULL,
	[RegStatus] [nchar](10) NULL,
	[LincenseNo] [nchar](10) NULL,
	[ActivatedOn] [nchar](10) NULL,
	[ExpiryDate] [nchar](10) NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BTPOSRecords](
	[Id] [numeric](18, 0) NULL,
	[BTPOSId] [numeric](18, 0) NULL,
	[IpConfig] [nchar](10) NULL,
	[RecordData] [nchar](10) NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BTPOSPortSettings](
	[Id] [numeric](18, 0) NULL,
	[BTPOSID] [numeric](18, 0) NULL,
	[Ipconfig] [nchar](10) NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BTPOSInventorySales](
	[amount] [int] NOT NULL,
	[code] [varchar](50) NOT NULL,
	[Id] [int] NOT NULL,
	[inventoryId] [int] NOT NULL,
	[perunit] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[soldon] [varchar](50) NOT NULL,
	[transactionId] [int] NOT NULL,
	[transactiontype] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BTPOSFaultsCatageries](
	[Active] [numeric](18, 0) NULL,
	[BTPOSFaultCategory] [nchar](10) NULL,
	[Desc] [nchar](10) NULL,
	[Id] [numeric](18, 0) NULL,
	[TypeGrpid] [nchar](10) NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BTPOSDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[POSID] [varchar](20) NOT NULL,
	[StatusId] [int] NOT NULL,
	[IMEI] [varchar](50) NULL,
	[ipconfig] [varchar](20) NULL,
	[active] [int] NULL,
	[FleetOwnerId] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BTPOSAuditDetails](
	[BTPOSID] [numeric](18, 0) NULL,
	[EditHistoryId] [numeric](18, 0) NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blocklist](
	[Id] [numeric](18, 0) NULL,
	[ItemId] [numeric](18, 0) NULL,
	[ItemTypeId] [numeric](18, 0) NULL,
	[Formdate] [nchar](10) NULL,
	[Todate] [nchar](10) NULL,
	[Active] [numeric](18, 0) NULL,
	[Desc] [nchar](10) NULL,
	[Reason] [nchar](10) NULL,
	[Blockedby] [nchar](10) NULL,
	[UnBlockedby] [nchar](10) NULL,
	[Blockedon] [nchar](10) NULL,
	[UnBlockedon] [nchar](10) NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetAuditDetails]
AS
BEGIN
	
select * from AuditDetails
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[register](
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[ConfirmPassword] [nvarchar](50) NULL,
	[Emailaddress] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReceivingsMaster](
	[Id] [numeric](18, 0) NULL,
	[Date] [smalldatetime] NULL,
	[ReceivedFor] [nchar](10) NULL,
	[Desc] [nchar](10) NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[POSTerminal](
	[Id] [int] NULL,
	[POSId] [varchar](10) NULL,
	[Status] [int] NULL,
	[GroupId] [int] NULL,
	[Location] [varchar](100) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Routes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RouteName] [varchar](50) NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[Description] [varchar](50) NULL,
	[Active] [int] NOT NULL CONSTRAINT [DF_Routes_Active]  DEFAULT ((1)),
	[SourceId] [int] NOT NULL,
	[DestinationId] [int] NOT NULL,
	[Distance] [decimal](18, 0) NULL
) ON [PRIMARY]

SET ANSI_NULLS ON
GO


SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getRoutes]
as
begin
SELECT r.[Id]
      ,[RouteName]
      ,r.[Code]
      ,r.[Description]
      ,r.[Active]
      ,src.name as Source
      ,dest.name as Destination
      ,[SourceId]
      ,[DestinationId]
      ,[Distance]
  FROM [POSDashboard].[dbo].[Routes] r
  inner join stops src on src.id = r.sourceid
  inner join stops dest on dest.id = destinationid
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentReceivings](
	[amount] [int] NOT NULL,
	[code] [varchar](50) NOT NULL,
	[date] [varchar](50) NOT NULL,
	[desc] [int] NOT NULL,
	[Id] [int] NOT NULL,
	[inventoryId] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[receivedOn] [varchar](50) NOT NULL,
	[transactionId] [int] NOT NULL,
	[transactiontype] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receivings](
	[Id] [numeric](18, 0) NULL,
	[Amount] [nchar](10) NULL,
	[MasterId] [numeric](18, 0) NULL,
	[ReceivedBy] [nchar](10) NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentGatewayType](
	[Active] [numeric](18, 0) NULL,
	[Desc] [nchar](10) NULL,
	[Id] [numeric](18, 0) NULL,
	[PaymentGatewayType] [nchar](10) NULL,
	[TypeGripId] [numeric](18, 0) NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPaymentgateway]
AS
BEGIN
	
select * from Paymentgateway
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentGatewaySettings](
	[enddate] [datetime] NOT NULL,
	[hashkey] [datetime] NOT NULL,
	[Id] [int] NOT NULL,
	[PaymentGatewayTypeId] [int] NOT NULL,
	[providername] [varchar](50) NOT NULL,
	[pwd] [varchar](50) NOT NULL,
	[saltkey] [datetime] NOT NULL,
	[startdate] [datetime] NOT NULL,
	[username] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentCatergory](
	[Active] [numeric](18, 0) NULL,
	[Desc] [nchar](10) NULL,
	[Id] [numeric](18, 0) NULL,
	[PaymentCatergory] [nchar](10) NULL,
	[TypegripId] [nchar](10) NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[Card] [varchar](50) NOT NULL,
	[MobilePayment] [varchar](50) NOT NULL,
	[Cash] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PayablesMaster](
	[Id] [numeric](18, 0) NULL,
	[Date] [smalldatetime] NULL,
	[PaidFor] [nchar](10) NULL,
	[Desc] [nchar](10) NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE[dbo].[InsUpdDelPayables](@Id numeric(30),
           @Amount VARCHAR(50),
           @MasterId numeric(30),
           @Paidby varchar(50))
AS
BEGIN
	

INSERT INTO 
[Payables] VALUES
           (@Id, 
          @Amount,
           @MasterId,
           @Paidby)
          
   
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPayables]
AS
BEGIN
	
select * from Payables
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Objects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](100) NULL,
	[Path] [varchar](500) NOT NULL,
	[Active] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ObjectAccesses](
	[Id] [int] NOT NULL,
	[ObjectId] [int] NOT NULL,
	[AccessId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE[dbo].[InsUpdDelNOCBTPOSTracking](@Id numeric(10),              
           @BTPOSId numeric(10),
           @Xcord varchar(50),
           @Ycord Varchar(50),
           @Time varchar(20),
           @Date Datetime)
AS
BEGIN
	

INSERT INTO 
[NOCBTPOSTracking] VALUES
           (@Id,
              
           @BTPOSId,
           @Xcord,
           @Ycord,
           @Time,
           @Date)
   
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetNOCBTPOSTracking]
AS
BEGIN
	
select * from NOCBTPOSTracking
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mulitiplicationsave](
	[rows] [numeric](18, 0) NULL,
	[columns] [numeric](18, 0) NULL,
	[layoutId] [numeric](18, 0) NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[menu](
	[Ticketgeneration] [varchar](50) NOT NULL,
	[Settings] [varchar](50) NOT NULL,
	[Reports] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[loginpage](
	[userid] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LicensePayments](
	[expiryOn] [datetime] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[licenseFor] [varchar](50) NOT NULL,
	[licenseId] [int] NOT NULL,
	[licenseType] [varchar](50) NOT NULL,
	[paidon] [datetime] NOT NULL,
	[renewedon] [datetime] NOT NULL,
	[transId] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LicenseKeyFile](
	[Id] [int] NOT NULL,
	[LicenseType] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[desc] [varchar](50) NOT NULL,
	[active] [int] NOT NULL,
	[key] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LicenceStatus](
	[Active] [numeric](18, 0) NULL,
	[Desc] [nchar](10) NULL,
	[Id] [numeric](18, 0) NULL,
	[LicenseStatusType] [nchar](10) NULL,
	[TypeGripidId] [nchar](10) NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LicenceCatergories](
	[Active] [numeric](18, 0) NULL,
	[Desc] [nchar](10) NULL,
	[Id] [numeric](18, 0) NULL,
	[LicenseCategory] [nchar](10) NULL,
	[TypegripId] [nchar](10) NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventorySales](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [varchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[PerUnitPrice] [int] NOT NULL,
	[PurchaseDate] [varchar](50) NOT NULL,
	[InVoiceNumber] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryReceivings](
	[amount] [int] NOT NULL,
	[code] [varchar](50) NOT NULL,
	[date] [varchar](50) NOT NULL,
	[Id] [int] NOT NULL,
	[inventoryId] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[reason] [varchar](50) NOT NULL,
	[refundamt] [int] NOT NULL,
	[returnedOn] [varchar](50) NOT NULL,
	[transactionId] [int] NOT NULL,
	[transactiontype] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory](
	[Active] [int] NOT NULL,
	[availableQty] [int] NOT NULL,
	[category] [varchar](50) NOT NULL,
	[code] [varchar](50) NOT NULL,
	[desc] [varchar](50) NOT NULL,
	[InventoryId] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[PerUnitPrice] [int] NOT NULL,
	[reorderpoint] [int] NOT NULL,
	[subcat] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
USE [POSDashboard]
GO
/****** Object:  Table [dbo].[InventoryPurchases]    Script Date: 05/06/2016 23:52:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InventoryPurchases](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [varchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[PerUnitPrice] [int] NOT NULL,
	[PurchaseDate] [datetime] NOT NULL,
	[PurchaseOrderNumber] [varchar](20) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Types](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NULL,
	[Active] [int] NOT NULL,
	[TypeGroupId] [int] NOT NULL,
	[listkey] [varchar](10) NULL,
	[listvalue] [varchar](20) NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeGroups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NULL,
	[Active] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TroubleTicketingStatus](
	[Active] [numeric](18, 0) NULL,
	[Desc] [nchar](10) NULL,
	[Id] [numeric](18, 0) NULL,
	[TtStatusTpe] [nchar](10) NULL,
	[TypeGripId] [numeric](18, 0) NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TroubleTicketingSlaType](
	[Active] [numeric](18, 0) NULL,
	[Desc] [nchar](10) NULL,
	[Id] [numeric](18, 0) NULL,
	[TTSLAType] [nchar](10) NULL,
	[TypeGripId] [numeric](18, 0) NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TroubleTicketingHandlers](
	[handledOn] [int] NOT NULL,
	[Id] [int] NOT NULL,
	[status] [int] NOT NULL,
	[TTId] [int] NOT NULL,
	[userid] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TroubleTicketingDevice](
	[deviceid] [int] NOT NULL,
	[Id] [int] NOT NULL,
	[ticketTypeId] [int] NOT NULL,
	[TTId] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetPOSDetails]
AS
BEGIN

SELECT t.[Id]
      ,[POSId]
      ,[Status]
      ,g.GroupName
      ,g.Id
      ,[Location]
  FROM [POSDashboard].[dbo].[POSTerminal] t
  inner join dbo.Groups g on g.Id = t.GroupId

END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TroubleTicketingDetails](
	[addInfo] [varchar](50) NOT NULL,
	[createdBy] [varchar](50) NOT NULL,
	[createdOn] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[raisedBy] [varchar](50) NOT NULL,
	[status] [varchar](50) NOT NULL,
	[ticketinfo] [varchar](50) NOT NULL,
	[ticketTypeId] [int] NOT NULL,
	[TTId] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TroubleTicketingCategories](
	[active] [int] NOT NULL,
	[desc] [varchar](50) NOT NULL,
	[Id] [int] NOT NULL,
	[TTCategory] [varchar](50) NOT NULL,
	[typegrpid] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionTypes](
	[active] [int] NOT NULL,
	[desc] [varchar](50) NOT NULL,
	[Id] [int] NOT NULL,
	[TransactionTypes] [varchar](50) NOT NULL,
	[typegrpid] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[barcode] [varchar](50) NOT NULL,
	[BTPOSid] [varchar](50) NOT NULL,
	[busNumber] [varchar](50) NOT NULL,
	[busId] [int] NULL,
	[change] [varchar](50) NULL,
	[company] [varchar](50) NOT NULL,
	[companyId] [varchar](50) NULL,
	[ConductorId] [varchar](50) NULL,
	[ConductorName] [varchar](50) NOT NULL,
	[Date] [datetime] NOT NULL,
	[destination] [varchar](50) NOT NULL,
	[fare] [varchar](50) NULL,
	[greetingMessage] [varchar](50) NOT NULL,
	[luggageType] [varchar](50) NOT NULL,
	[passengerType] [varchar](50) NOT NULL,
	[passengerId] [varchar](50) NULL,
	[paymentId] [varchar](50) NOT NULL,
	[printdataId] [varchar](50) NOT NULL,
	[route] [varchar](50) NULL,
	[routecode] [varchar](50) NOT NULL,
	[routeId] [varchar](50) NULL,
	[source] [varchar](50) NOT NULL,
	[time] [datetime] NOT NULL,
	[ticketHolderId] [varchar](50) NULL,
	[ticketHolderName] [varchar](50) NULL,
	[TicketNumber] [varchar](50) NOT NULL,
	[ticketValidityPeriod] [varchar](50) NULL,
	[totalamount] [int] NOT NULL,
	[amountpaid] [int] NOT NULL,
	[TransactionCode] [varchar](50) NOT NULL,
	[TransactionId] [varchar](50) NULL,
	[transactionType] [varchar](50) NOT NULL,
	[userid] [int] NOT NULL,
	[ChangeRendered] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionMaster](
	[Id] [int] NOT NULL,
	[TransCode] [varchar](50) NOT NULL,
	[Date] [datetime] NOT NULL,
	[TransType] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TicketGeneration](
	[Source] [varchar](50) NOT NULL,
	[Target] [varchar](50) NOT NULL,
	[NoOfTickets] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[table2](
	[Travels] [nvarchar](50) NULL,
	[DepartArriveDuration] [nvarchar](50) NULL,
	[Seats] [nvarchar](50) NULL,
	[Rating] [nvarchar](50) NULL,
	[Fare] [nvarchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionDetails](
	[Id] [int] NULL,
	[TransId] [varchar](50) NULL,
	[TotalAmt] [int] NULL,
	[PaymentId] [varchar](50) NULL,
	[BTPOSid] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](150) NULL,
	[CategoryId] [int] NOT NULL,
	[Active] [int] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSTATE]
AS
BEGIN
	
select * from STATE
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SMSProviderConfig](
	[Id] [numeric](18, 0) NULL,
	[ProviderName] [nchar](10) NULL,
	[BTPOSGRPID] [nchar](10) NULL,
	[Active] [nchar](10) NULL,
	[UserId] [numeric](18, 0) NULL,
	[Passkey] [nchar](10) NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SMSEmailSubscribers](
	[AlertId] [int] NOT NULL,
	[emailid] [varchar](50) NOT NULL,
	[enddate] [datetime] NOT NULL,
	[frequency] [int] NOT NULL,
	[Id] [int] NOT NULL,
	[phNo] [varchar](50) NOT NULL,
	[startdate] [datetime] NOT NULL,
	[userid] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SMSEmailConfiguration](
	[AlertTypeId] [int] NOT NULL,
	[enddate] [datetime] NOT NULL,
	[hashkey] [datetime] NOT NULL,
	[Id] [int] NOT NULL,
	[providername] [varchar](50) NOT NULL,
	[pwd] [varchar](50) NOT NULL,
	[saltkey] [datetime] NOT NULL,
	[startdate] [datetime] NOT NULL,
	[username] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoutesVehicle](
	[Id] [int] NOT NULL,
	[VehicleId] [nvarchar](50) NOT NULL,
	[RouteId] [nvarchar](50) NOT NULL,
	[EffectiveFrom] [nvarchar](50) NOT NULL,
	[EffectiveTill] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stops](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[Description] [varchar](30) NULL,
	[Code] [varchar](10) NOT NULL,
	[Active] [int] NULL
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoutesConfiguration](
	[distanceFromDest] [int] NOT NULL,
	[distanceFromLastStop] [int] NOT NULL,
	[distanceFromPrevStop] [int] NOT NULL,
	[distanceFromSource] [int] NOT NULL,
	[Id] [int] NOT NULL,
	[routeId] [int] NOT NULL,
	[stops] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getRoutesFares]
as
begin
select * from RoutesFares
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RouteFare](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RouteId] [int] NOT NULL,
	[VehicleType] [nvarchar](50) NOT NULL,
	[SourceStopId] [int] NOT NULL,
	[DestinationStopId] [int] NOT NULL,
	[Distance] [nvarchar](50) NOT NULL,
	[PerUnitPrice] [int] NOT NULL,
	[Amount] [int] NOT NULL,
	[FareType] [nvarchar](50) NOT NULL,
	[Active] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RouteFareDetails](
	[Id] [int] NOT NULL,
	[RouteId] [varchar](50) NOT NULL,
	[FleetOwnerId] [int] NOT NULL,
	[Source] [varchar](50) NOT NULL,
	[Destination] [nvarchar](50) NOT NULL,
	[Stop] [nvarchar](50) NOT NULL,
	[Kilometers] [int] NOT NULL,
	[Fare] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RouteDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RouteId] [int] NOT NULL,
	[StopId] [int] NOT NULL,
	[DistanceFromSource] [decimal](18, 0) NULL,
	[DistanceFromDestination] [decimal](18, 0) NULL,
	[DistanceFromPreviousStop] [decimal](18, 0) NULL,
	[DistanceFromNextStop] [decimal](18, 0) NULL,
	[PreviousStopId] [int] NOT NULL,
	[NextStopId] [int] NOT NULL,
	[StopNo] [int] null
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Roles]    Script Date: 05/20/2016 21:36:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](500) NULL,
	[Active] [int] NOT NULL,
	[IsPublic] [int] NULL CONSTRAINT [DF_Roles_IsPublic]  DEFAULT ((1))
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleObjectAccesses](
	[Id] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[ObjectId] [int] NOT NULL,
	[AccessId] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getRoledetails]
as begin 
select * from RoleDetails
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportsFields](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[ReportType] [varchar](50) NOT NULL,
	[FromDate] [datetime] NOT NULL,
	[ToDate] [datetime] NOT NULL,
	[active] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegistrationBTPOS](
	[code] [varchar](50) NOT NULL,
	[uniqueId] [varchar](50) NOT NULL,
	[ipconfig] [varchar](50) NOT NULL,
	[Active] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO

GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE[dbo].[InsUpdDelSTATE](@Id NUMERIC(10),
           @Name VARCHAR(20),
           @Count VARCHAR(20),
           @Code VARCHAR(20),
           @Active varchar(20))
AS
BEGIN
	

INSERT INTO 
[STATE] VALUES
           (@ID,
           @Name,
           @Count,
           @Code,
           @Active)
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdDelObjects](@Id int,
@Name varchar(50),
@Description varchar(100) = '',
@Path Varchar(500),
@Active int = 1)
as
begin
insert into Object (Name,Description,Path ,Active) values(@Name,@Description, @Path, @Active)
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdDelObjectAccess](@Id int,
@ObjectId int,
@AccessId int,@Name varchar(50))

as
begin
insert into ObjectAccess (ObjectId,AccessId,Name) values(@ObjectId,@AccessId,@Name)
end

GO
/****** Object:  Table [dbo].[Users]    Script Date: 05/22/2016 12:38:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](40)  NOT NULL,
	[LastName] [varchar](40)  NOT NULL,
	[EmpNo] [varchar](50)  NOT NULL,
	[Email] [varchar](40)  NULL,
	[AddressId] [int] NULL,
	[MobileNo] [varchar](15) NULL,
	[Active] [int] NOT NULL,
	[MiddleName] [varchar](50) NULL,
	[CompanyId] [int] NOT NULL,
	[ManagerId] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZipCode](
	[Id] [numeric](18, 0) NULL,
	[Code] [nchar](10) NULL,
	[Active] [nchar](10) NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleDetails](
	[busId] [money] NOT NULL,
	[busTypeId] [int] NOT NULL,
	[conductorId] [int] NOT NULL,
	[conductorName] [varchar](50) NOT NULL,
	[driverId] [int] NOT NULL,
	[driverName] [varchar](50) NOT NULL,
	[fleetOwnerId] [int] NOT NULL,
	[CompanyName] [varchar](50) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[POSID] [int] NOT NULL,
	[RegNo] [varchar](50) NOT NULL,
	[route] [varchar](50) NOT NULL,
	[Status] [varchar](50) NOT NULL,
	[statusid] [int] NOT NULL,
	[Active] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[InsUpdDelRoledetails](@Id int,

@ObjectName varchar(50),
@Path varchar(50)
)
as
begin
insert into Object (ObjectName,Path) values(@ObjectName, @Path)
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE[dbo].[InsUpdDelPaymentgateway](@Id numeric(20),
           @ProviderName varchar(20),
           @BTPOSGRPID VARCHAR(20),
           @Active numeric(20),
           @userId numeric(20),
           @Passkey varchar(20),
           @Url varchar(20),
           @Testurl varchar(20),
           @Salt varchar(20),
           @Hash varchar(20),
           @PaymentGatwayTypeId varchar(20))
AS
BEGIN
	

INSERT INTO 
[Paymentgateway] VALUES
           (@Id,
           @ProviderName,
           @BTPOSGRPID,
           @Active,
           @UserId,
           @Passkey,
           @Url,
           @Testurl,
           @Salt,
           @Hash,
           @PaymentGatwayTypeId)
   
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [varchar](50) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Description] [varchar](50) NULL,
	[CategoryId] [int] NOT NULL,
	[SubCategoryId] [int] NOT NULL,
	[ReOrderPoint] [int] NOT NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[FleetBtpos]    Script Date: 05/25/2016 08:33:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FleetBtpos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VehicleId] [int] NOT NULL,
	[FromDate] [datetime] NULL,
	[ToDate] [datetime] NULL,
	[BTPOSId] [int] NOT NULL
) ON [PRIMARY]


GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

/****** Object:  Table [dbo].[FleetDetails]    Script Date: 05/20/2016 12:07:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FleetDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VehicleRegNo] [varchar](15) NOT NULL,
	[VehicleTypeId] [int] NOT NULL,
	[FleetOwnerId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[ServiceTypeId] [int] NOT NULL,
	[Active] [int] NOT NULL,
	[LayoutTypeId] [int] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO



SET ANSI_PADDING OFF
GO



GO

SET ANSI_PADDING OFF
GO

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FleetRoutes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VehicleId] [int] NOT NULL,
	[RouteId] [int] NOT NULL,
	[EffectiveFrom] [datetime] NULL,
	[EffectiveTill] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FleetStaff](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[FromDate] [datetime]  NULL,
	[ToDate] [datetime]  NULL,
	[VehicleId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL
) ON [PRIMARY]



GO

/****** Object:  Table [dbo].[FleetAvailability]    Script Date: 05/25/2016 10:29:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FleetAvailability](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VehicleId] [int] NOT NULL,
	[FromDate] [datetime] NULL,
	[ToDate] [datetime] NULL
) ON [PRIMARY]


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FleetOwnerRouteStop](
	[FleetOwnerId] [int] NOT NULL,
	[RouteId] [int] NULL,
	[StopId] [int] NULL,
	[StopNo] [int] NULL,
	[PreviousStop] [nvarchar](50) NULL,
	[NextStop] [nvarchar](50) NULL,
	[Active] [int] NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FleetOwnerRouteFare](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RouteId] [int] NOT NULL,
	[VehicleType] [nvarchar](50) NOT NULL,
	[SourceStopId] [int] NOT NULL,
	[DestinationStopId] [int] NOT NULL,
	[Distance] [nvarchar](50) NOT NULL,
	[PerUnitPrice] [int] NOT NULL,
	[Amount] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[FleetOwnerId] [int] NOT NULL,
	[FareType] [nvarchar](50) NOT NULL,
	[Active] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FleetOwnerRoute](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FleetOwnerId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[RouteId] [int] NOT NULL,
	[From] [nvarchar](50) NOT NULL,
	[To] [nvarchar](50) NOT NULL,
	[Active] [int] NOT NULL
) ON [PRIMARY]




GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogins](
	[LoginInfo] [nvarchar](50) NOT NULL,
	[PassKey] [nvarchar](50) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[salt] [varchar](50) NULL,
	[Active] [int] NOT NULL CONSTRAINT [DF_UserLogins_Active]  DEFAULT ((1))
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FleetOwnerRouteDetails](
	[FleetOwnerId] [int] NOT NULL,
	[RouteId] [varchar](50) NOT NULL,
	[Stop1] [nvarchar](50) NOT NULL,
	[PreviousStop] [nvarchar](50) NOT NULL,
	[NextStop] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FleetOwner](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CompanyId] [int] NULL,
	[Active] [int] NOT NULL,
	[FleetOwnerCode] [varchar](10) NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fares](
	[Id] [int] NULL,
	[FromStop] [varchar](50) NULL,
	[ToStop] [varchar](50) NULL,
	[Fare] [varchar](50) NULL,
	[Active] [varchar](50) NULL,
	[RouteId] [varchar](50) NULL,
	[Name] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdDelExpenses](@amount int,@Date varchar(50),@desc varchar(50),@Id int,@MasterId int,@paidBy varchar(50),@paidFor varchar (50),@transactionId int)
as
begin
insert into Expenses values(@amount,@Date,@desc,@Id,@MasterId,@paidBy,@paidFor,@transactionId)
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getExpenses]
as
begin
select * from Expenses
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getEditHistoryDetails]
(@edithistoryid int =-1)
as
begin
SELECT [EditHistoryId]
      ,[FromValue]
      ,[ToValue]
      ,[ChangeType]
      ,e.Task
      ,e.SubItem
  FROM [POSDashboard].[dbo].[EditHistoryDetails] ed
  inner join EditHistory e on e.Id = ed.EditHistoryId
  WHERE EditHistoryId = @edithistoryid
  
end

GO

CREATE procedure [dbo].[getEditHistory]
as
begin
select * from EditHistory
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCOUNTRY]
AS
BEGIN
	
select * from COUNTRY
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE[dbo].[InsUpdDelCOUNTRY](@Id NUMERIC(10),
           @Name VARCHAR(50),   
           @Code VARCHAR(50),
           @Active VARCHAR(50))
AS
BEGIN
	

INSERT INTO 
[COUNTRY] VALUES
           (@Id,
           @Name,
           @Code
           ,@Active)
   
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUsers]
(@cmpId int = -1)
AS
BEGIN

SELECT U.[Id]
      ,U.[FirstName]
      ,U.[LastName]      
      ,U.[EmpNo]
      ,U.[Email]
      ,U.[AddressId]
      ,U.[MobileNo]    
      ,U.[Active]
      ,U.[MiddleName]
      ,mgr.Firstname + ' ' +mgr.LastName as mgrName
      ,mgr.Id
      ,ul.logininfo as UserName
      ,ul.passkey as [Password]            
      ,c.name as [Company]
  FROM [POSDashboard].[dbo].[Users] U
  inner join company c on (U.companyid = c.id)
  left outer join Users mgr on mgr.id = U.managerid
  left outer join dbo.userlogins ul on ul.userid = U.id    
  where (c.id = @cmpid or   @cmpid = -1)
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetRoles]
(@allroles int = -1)
as
begin

if @allroles = -1

select distinct Roles.Id, Roles.Name, Description, Roles.Active,IsPublic
from Roles

else

if @allroles = 0

select distinct Roles.Id, Roles.Name, Description, Roles.Active,IsPublic
from Roles 
where ispublic = 0

else
 
select distinct Roles.Id, Roles.Name, Description, Roles.Active,IsPublic
from Roles 
where ispublic = 1

end 

go

/****** Object:  StoredProcedure [dbo].[InsUpdDelCompany]    Script Date: 05/04/2016 17:22:18 ******/

CREATE procedure [dbo].[InsUpdDelCompanyRoles](
@active int,
@Id int,
@roleid int,
@CompanyId int,
@insupdflag int = 0
)
as
begin

if @insupdflag = 0
begin

INSERT INTO [CompanyRoles]
           ([CompanyId]
           ,[RoleId]
           ,[Active])
     VALUES
           (@CompanyId,@roleid,@active)
end

else
begin
 delete from [CompanyRoles] where [CompanyId] = @CompanyId and RoleId = @roleid
end

end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getCompanies]
(@userid int =-1)
as
begin
SELECT distinct c.[active]
      ,[code]
      ,[desc]
      ,c.[Id]
      ,[Name]
  FROM [POSDashboard].[dbo].[Company] c
  inner join Users u on  (u.companyId = c.id or  @userid = -1)
  
end

--delete from CompanyGroups
--select * from company

--[getCompanies] 1

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[InsUpdDelCompany]    Script Date: 05/04/2016 17:22:18 ******/

CREATE procedure [dbo].[InsUpdDelCompany](
@active int,
@code varchar(50),
@desc varchar(50) = '',
@Id int,
@Name varchar(50),
@insupdflag varchar(10),
@userid int = -1
)
as
begin
declare @cnt int
declare @edithistoryid int
set @cnt = 0

declare @newCmpId int
set @newCmpId = 0;

declare @dt datetime
set @dt = GETDATE()

declare @neweid int



if @insupdflag = 'I'
	--check if already company exists
	select @cnt = count(1) from company where upper(name) = upper(@name)

	if @cnt = 0 
	begin
	insert into Company (active,code,[desc],Name) values(@active,@code,@desc,@Name)
	
	SELECT @newCmpId = @@IDENTITY
	
	--insert into edit history
	exec InsEditHistory 'Company', 'Name',@Name,'Company creation',@dt,'Admin','Insertion',@edithistoryid
           
           set @neweid =  @edithistoryid
           
    --exec InsEditHistoryDetails @neweid,null,@Name,'Insertion','Name',null
    --exec InsEditHistoryDetails @edithistoryid,null,@code,'Insertion','Code',null
    --exec InsEditHistoryDetails @edithistoryid,null,@desc,'Insertion','Desc',null
    --exec InsEditHistoryDetails @edithistoryid,null,@active,'Insertion','Active',null

  --  --insert Fleet owner role by default
		--insert into CompanyRoles (Name,[Description],Active,companyid) 
		--values('Fleet Owner','Fleet owner role',1,@newCmpId)
   
	end

else

   if @insupdflag = 'U'

		--check if already a company with the new name exists
		select @cnt = count(1) from company where upper(name) = upper(@name) and id <> @id
	    
		if @cnt = 0 
		begin
		update Company
		set Name = @Name, code = @code, [desc] = @desc, active = @active
		where Id = @Id
		
		
		--insert into edit history
	exec InsEditHistory 'Company', 'Name',@Name,'Company creation',@dt,'Admin','Modification',@edithistoryid
           
           set @neweid =  @edithistoryid
           
    --exec InsEditHistoryDetails @neweid,null,@Name,'Insertion','Name',null
    --exec InsEditHistoryDetails @edithistoryid,null,@code,'Insertion','Code',null
    --exec InsEditHistoryDetails @edithistoryid,null,@desc,'Insertion','Desc',null
    --exec InsEditHistoryDetails @edithistoryid,null,@active,'Insertion','Active',null
		
		end
   else
     delete from Company where Id = @Id
end


GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE  PROCEDURE [dbo].[GetFleetDetails] 
	-- Add the parameters for the stored procedure here
	(@vehicleId int=-1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT v.[Id]
      ,[VehicleRegNo]
      ,vt.[Name] as VehicleType,
      lt.Name AS vehiclelayout,
       st.Name as ServiceType,
       u.FirstName +' '+u.LastName as FleetOwnerName 
      ,c.[Name] as CompanyName
      ,v.[Active]
     FROM [POSDashboard].[dbo].[FleetDetails]v
    inner join Types vt on vt.Id=v.VehicleTypeId
    inner join Types st on st.Id=v.ServiceTypeId
    inner join Types lt on lt.Id = v.layouttypeid
    inner join company c on c.Id=v.CompanyId
    inner join FleetOwner f on f.UserId=v.FleetOwnerId
    inner join Users u on u.Id = f.UserId
	 where  (v.Id= @vehicleId or @vehicleId = -1)
   
    -- Insert statements for procedure here
    
    
--SELECT t.[Id]
--      ,t.[Name] as VehicleType,
--      t.[Name] as ServiceType
--      ,t.[Active]
      
--      ,f.[Id] as FleetName 
--         ,c.[Name] as CompanyName
--  FROM [POSDashboard].[dbo].[Types]t   
--	 inner join company c on c.Id=t.Id
--	 inner join FleetOwner f on f.Id=t.Id
--	 where  (t.Id= @vehicleId or @vehicleId = -1)


END


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBTPOSSheduleUploads]
AS
BEGIN
	
select * from [BTPOSSheduleUploads]
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE[dbo].[InsUpdDelBTPOSSheduleUploads](@Id NUMERIC(10),
              
           @POSID numeric(10),
           @UploadOn varchar(50),
           @UploadedOn varchar(50),
           @Status varchar(50),
           @UploadData varchar(50),
           @Ipconfig varchar(50))
AS
BEGIN
	

INSERT INTO 
[BTPOSSheduleUploads] VALUES
           (@Id,
              
           @POSID,
           @UploadOn,
           @UploadedOn,
           @Status,
           @UploadData,
           @Ipconfig )
   
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE[dbo].[InsUpdDelBTPOSSecheduledUpdates](@Id NUMERIC(10),
              
           @POSID numeric(10),
           @UploadOn varchar(50),
           @UploadedOn varchar(50),
           @Status varchar(50),
           @UploadData varchar(50),
           @Ipconfig varchar(50))
AS
BEGIN
	

INSERT INTO 
[BTPOSSecheduledUpdates] VALUES
           (@Id,
              
           @POSID,
           @UploadOn,
           @UploadedOn,
           @Status,
           @UploadData,
           @Ipconfig )
   
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetBTPOSSecheduledUpdates]
AS
BEGIN
	
select * from BTPOSSecheduledUpdates
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetBTPOSRegistration]
AS
BEGIN
	
select * from BTPOSRegistration
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE[dbo].[InsUpdDelBTPOSRegistration](@Id NUMERIC(10),
              
           @POSID numeric(10),
           @Status VARCHAR(50),
           @FleetOwenerId numeric(10),
           @RegisteredOn Varchar(50),
           @IpConfig varchar(50),
           @RegStatus varchar(50),
           @LincenseNo varchar(50),
           @ActivedOn varchar(50),
           @ExpiryDate varchar(50))
AS
BEGIN
	

INSERT INTO 
[BTPOSRegistration] VALUES
           (@Id,
              
           @POSID,
           @Status,
           @FleetOwenerId,
           @RegisteredOn,
           @IpConfig,
           @RegStatus,
           @LincenseNo,
           @ActivedOn,
           @ExpiryDate )
   
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE[dbo].[InsUpdDelBTPOSRecords](@Id NUMERIC(10),
              
           @BTPOSID numeric(10),
           @IpConfig varchar(50),
           @RecordData varchar(50))
AS
BEGIN
	

INSERT INTO 
[BTPOSRecords] VALUES
           (@Id,
              
           @BTPOSID,
           @Ipconfig,
           @RecordData)
   
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetBTPOSRecords]
AS
BEGIN
	
select * from  BTPOSRecords
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetBTPOSPortSettings]
AS
BEGIN
	
select * from BTPOSPortSettings
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE[dbo].[InsUpdDelBTPOSPortSettings](@Id NUMERIC(10),
              
           @BTPOSId numeric(10),
           @Ipconfig varchar(50))
AS
BEGIN
	

INSERT INTO 
[BTPOSPortSettings] VALUES
           (@Id,
              
           @BTPOSId,
           @Ipconfig)
   
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getBTPOSInventorySales]
as
begin
select * from BTPOSInventorySales
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdDelBTPOSInventorySales](@amount int,@code varchar (50),@Id int,@inventoryId int,@perunit int,@quantity int,@soldon varchar (50),@transactionId int,@transactiontype varchar (50))
as
begin
insert into BTPOSInventorySales values(@amount,@code,@Id,@inventoryId,@perunit,@quantity,@soldon,@transactionId,@transactiontype)
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetBTPOSFaultsCatageries]
AS
BEGIN
	
select * from BTPOSFaultsCatageries
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE[dbo].[InsUpdDelBTPOSFaultsCatageries](@Active NUMERIC(10),
              
           @BTPOSFaultCategory Varchar(30),
           @Desc varchar(50),
           @Id numeric(10),
           @TypeGripId varchar(50))
AS
BEGIN
	

INSERT INTO 
[BTPOSFaultsCatageries] VALUES
           (@Active,
              
          @BTPOSFaultCategory,
           @Desc,
           @Id,
           @TypeGripId )
   
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBTPOSDetails]
AS
BEGIN
	
SELECT b.[Id]
      ,c.[Id] as CompanyId
      ,c.Name as companyname
      ,[POSID]
      ,[StatusId]
      ,t.Name as [status]
      ,[IMEI]
      ,[ipconfig]
      ,b.[active]
      ,u.FirstName + ' '+ u.LastName as fleetowner
      ,u.Id as fleetownerid
  FROM [POSDashboard].[dbo].[BTPOSDetails] b
  left outer join Types t on t.Id = statusid
  left outer join Company c on c.Id = CompanyId
  left outer join Users u on u.Id = FleetOwnerId
  
end


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE[dbo].[InsUpdDelBTPOSDetails](
		  @Id int,
           @CompanyId int,   
           @POSID varchar(20),
           @StatusId int,
           @IMEI varchar(20),
           @ipconfig varchar(20),
           @active int = 1,
           @fleetownerid int,
           @insupdflag varchar(10)
           )
 
AS
BEGIN	
if @insupdflag = 'I' 
INSERT INTO [POSDashboard].[dbo].[BTPOSDetails]
           ([CompanyId]
           ,[POSID]
           ,[StatusId]
           ,[IMEI]
           ,[ipconfig]
           ,[active]
           ,[FleetOwnerId])
     VALUES
           --(--@GroupId
           --@POSID
           --,@StatusId
           --,@IMEI
           --,@ipconfig
           --,@active
           --,@FleetOwnerId)
             (1,
           @POSID
           ,1
           ,@IMEI
           ,@ipconfig
           ,1
           ,1)
else
  if @insupdflag = 'U' 
UPDATE [POSDashboard].[dbo].[BTPOSDetails]
   SET
      [POSID] = @POSID
      ,[CompanyId] = @CompanyId
      ,[StatusId] = @StatusId
      ,[IMEI] = @IMEI
      ,[ipconfig] = @ipconfig
      ,[active] = @active
      ,[FleetOwnerId] = @fleetownerid
 WHERE Id = @Id
 
 else
   delete from BTPOSDetails where Id = @Id

END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[registerbtpos]
	@fleetownercode varchar(10),
	@ipconfig varchar(20),
	@result int out 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	
	declare @fleetownerid int
	declare @posid int
	
	select @fleetownerid = userID from FleetOwner where UPPER(FleetOwnerCode) = UPPER(@fleetownercode)
	select @posid = ID from BTPOSDetails where FleetOwnerId = @fleetownerid and ipconfig = @ipconfig
	
	UPDATE BTPOSDetails
        SET POSID = 'POS'+ UPPER(@fleetownercode)+ cast(@posid as varchar(3))
    FROM BTPOSDetails
    where FleetOwnerId = @fleetownerid and ipconfig = @ipconfig
   
	select @result = COUNT(*) from BTPOSDetails where  POSID = 'POS'+ UPPER(@fleetownercode)+ cast(@posid as varchar(3))

    -- Insert statements for procedure here
	return @result
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsUpdDelVehicleDetails](
	@busId money,
	@busTypeId int,
	@conductorId int,
	@conductorName varchar(50),
	@driverId int,
	@driverName varchar(50),
	@fleetOwnerId int,
	@CompanyName varchar(50),
	@Id int,
	@POSID int,
	@RegNo varchar(50),
	@route varchar(50),
	@Status varchar(50),
	@statusid int,
	@Active int = 1,
	 @insupdflag varchar(10)
)
AS
BEGIN
if @insupdflag = 'I'
INSERT INTO [POSDashboard].[dbo].[VehicleDetails]
           ([busId]
           ,[busTypeId]
           ,[conductorId]
           ,[conductorName]
           ,[driverId]
           ,[driverName]
           ,[fleetOwnerId]
           ,[CompanyName]
           ,[POSID]
           ,[RegNo]
           ,[route]
           ,[Status]
           ,[statusid]
           ,[Active])
     VALUES
           (@busId
           ,@busTypeId
           ,@conductorId
           ,@conductorName
           ,@driverId
           ,@driverName
           ,@fleetOwnerId
           ,@CompanyName
           ,@POSID
           ,@RegNo
           ,@route
           ,@Status
           ,@statusid
           ,@Active
  )         
else
 if @insupdflag = 'U' 
 UPDATE [POSDashboard].[dbo].[VehicleDetails]
   SET [busId] = @busId
      ,[busTypeId] = @busTypeId
      ,[conductorId] = @conductorId
      ,[conductorName] = @conductorName
      ,[driverId] = @driverId
      ,[driverName] = @driverName
      ,[fleetOwnerId] = @fleetOwnerId
      ,[CompanyName] = @CompanyName
      ,[POSID] = @POSID
      ,[RegNo] = @RegNo
      ,[route] = @route
      ,[Status] = Status
      ,[statusid] = @statusid
      ,[Active] = @Active
      WHERE Id = @Id
else
   delete from BTPOSDetails where Id = @Id

END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updatebtpos]
	@fleetownercode varchar(10),
	@units int,
	@result int out 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	
	declare @fleetownerid int
	declare @cmpid int
	
	select @fleetownerid = userID from FleetOwner where UPPER(FleetOwnerCode) = UPPER(@fleetownercode)
	
	select @cmpid = CompanyId from Users where Id = @fleetownerid
	
	UPDATE BTPOSDetails
        SET FleetOwnerId = @fleetownerid
        ,CompanyId = @cmpid
    FROM BTPOSDetails
    INNER JOIN (
        SELECT TOP(@units) ID FROM BTPOSDetails WHERE FleetOwnerId = 1
         ORDER BY ID
    ) AS InnerMyTable ON BTPOSDetails.ID = InnerMyTable.ID
	
	select @result = COUNT(*) from FleetOwner where UPPER(FleetOwnerCode) = UPPER(@fleetownercode)

    -- Insert statements for procedure here
	return @result
END


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetBTPOSAuditDetails]
AS
BEGIN
	
select * from BTPOSAuditDetails
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE[dbo].[InsUpdDelBTPOSAuditDetails](@BTPOSId NUMERIC(10),
              
           @EditHistoryId numeric(10))
AS
BEGIN
	

INSERT INTO 
[BTPOSAuditDetails] VALUES
           (@BTPOSId,
              
           @EditHistoryId)
   
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE[dbo].[InsUpdDelBlocklist](@Id numeric(20)
,
           @ItemId NUMERIC(20),
           @ItemTypeId numeric(30),
           @Formdate varchar(50),
           @Todate varchar(50),
           @Active numeric(30),
           @Desc varchar(50),
           @Reason varchar(50),
           @Blockedby varchar(50),
           @UnBlockedby varchar(50),
           @Blockedon varchar(50),
           @UnBlockedon varchar(50))
AS
BEGIN
	

INSERT INTO 
[Blocklist] VALUES
           (@Id, 
          @ItemId,
           @ItemTypeId,
           @Formdate,
           @Todate,
           @Active,
           @Desc,
           @Reason,
           @Blockedby,
           @UnBlockedby,
           @Blockedon ,
           @UnBlockedon )
   
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBlockList]
AS
BEGIN
	
select * from Blocklist
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdDelregisterform](@UserName varchar(max),
@Password varchar(max),@ConfirmPassword varchar(max),@Emailaddress varchar(max),
@FirstName varchar(max),@LastName varchar(max))
as
begin

INSERT INTO 
[register] VALUES
           (@UserName,
              
          
           @Password,
		     @ConfirmPassword,
			    @Emailaddress,
           @FirstName,
           @LastName
         
         )
   

end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Getregister]
as begin
select * from register
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetReceivingsMaster]
AS
BEGIN
	
select * from ReceivingsMaster
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE[dbo].[InsUpdDelReceivingsMaster](@Id Numeric(20),
           @Date smalldatetime,
           @ReceivedFor varchar(20),
           @Desc varchar(20))
AS
BEGIN
	

INSERT INTO 
[ReceivingsMaster] VALUES
           (@Id, 
           @Date, 
           @ReceivedFor,
           @Desc)
   
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE[dbo].[InsUpdDelReceivings](@Id Numeric(10),
           @Amount VARCHAR(20),
           @MasterId numeric(10),
           @ReceivedBy Varchar(20))
AS
BEGIN
	

INSERT INTO 
[Receivings] VALUES

       (@Id,
       @Amount,
         @MasterId,
           @ReceivedBy)  
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetReceivings]
AS
BEGIN
	
select * from Receivings
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getPaymentReceivings]
as
begin
select * from PaymentReceivings
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdDelPaymentReceivings](@amount int,@code varchar(50),@date varchar(50),@desc int,@Id int,@inventoryId int,@quantity int,@receivedOn varchar(50),@transactionId int,@transactiontype varchar(50))
as
begin
insert into PaymentReceivings values(@amount,@code,@date,@desc,@Id,@inventoryId,@quantity,@receivedOn,@transactionId,@transactiontype)
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE[dbo].[InsUpdDelPaymentCatergory](@Active NUMERIC(10),
              
           @Desc Varchar(30),
           
           @Id numeric(10),
           @PaymentCatergory varchar(30),
           @TypeGripId varchar(50))
AS
BEGIN
	

INSERT INTO 
[PaymentGatewayType] VALUES
           (@Active,
              
          
           @Desc,
           @Id,
           @PaymentCatergory,
           @TypeGripId )
   
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE[dbo].[InsUpdDelPaymentGatewayType](@Active NUMERIC(10),
              
           @Desc Varchar(30),
           
           @Id numeric(10),
           @PaymentGatewayType varchar(30),
           @TypeGripId numeric(20))
AS
BEGIN
	

INSERT INTO 
[PaymentGatewayType] VALUES
           (@Active,
              
          
           @Desc,
           @Id,
           @PaymentGatewayType,
           @TypeGripId )
   
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetPaymentGatewayType]
AS
BEGIN
	
select * from PaymentGatewayType
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getPaymentGatewaySettings]
as
begin
select * from PaymentGatewaySettings
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdDelPaymentGatewaySettings](@enddate datetime,@hashkey datetime,@Id int,@PaymentGatewayTypeId int,@providername varchar(50),@pwd varchar(50),@saltkey datetime,@startdate datetime,@username varchar(50))
as
begin
insert into PaymentGatewaySettings values(@enddate,@hashkey,@Id,@PaymentGatewayTypeId,@providername,@pwd,@saltkey,@startdate,@username)
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetPaymentCatergory]
AS
BEGIN
	
select * from PaymentCatergory
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getPayments]
as
begin
select * from Payment
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[InsUpdDelPayment](@Card varchar(50),@MobilePayment varchar(50),@Cash varchar(50))
as
begin
insert into Payment values(@Card,@MobilePayment,@Cash)
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE[dbo].[InsUpdDelPayablesMaster](@Id numeric,
           @Date smalldatetime,
           @PaidFor VARCHAR,
           @Desc VARCHAR)
AS
BEGIN
	

INSERT INTO 
[PayablesMaster] VALUES
           (@Id
           ,@Date
           ,@PaidFor
           ,@Desc)
   
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPayablesMaster]
AS
BEGIN
	
select * from PayablesMaster
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetObjectAccesses] 	
AS
BEGIN
	select t.name,t.ID accessid, o.Name as objname from Types t
inner join ObjectAccesses oa on oa.AccessId = t.Id
inner join Objects o on o.Id = oa.ObjectId
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getObjects](@objid int = -1)
as
begin
declare @oid int
set @oid = @objid

select  o.Id, o.Name, o.Description, Path,active 
from Objects o
where o.Id = @objid or @objid = -1

select t.name,t.ID from Types t
inner join ObjectAccesses oa on oa.AccessId = t.Id
inner join Objects o on o.Id = oa.ObjectId
where  o.Id = @objid or @objid = -1
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetRoleObjectAccesses] 	
@roleid int = -1
AS
BEGIN
	select t.name,t.ID accessid, o.Name  as objname, r.Name as rolename from Types t
inner join RoleObjectAccesses roa on roa.AccessId = t.Id
inner join Objects o on o.Id = roa.ObjectId
inner join Roles r on r.Id = roa.RoleId
where r.Id = @roleid or @roleid = -1

END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Getmulitiplicationsave]
AS
BEGIN
	
select * from mulitiplicationsave
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE[dbo].[InsUpdDelmulitiplicationsave](@rows int,@columns int, @layoutId int)
AS
BEGIN
	

INSERT INTO 
[mulitiplicationsave] VALUES
           (@rows,
             @columns,
             @layoutId)
   
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[InsUpdDelMenu](@Ticketgeneration varchar(50),@Settings varchar(50),@Reports varchar(50))
as
begin
insert into menu values (@Ticketgeneration,@Settings,@Reports)
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getmenu]
as
begin
select * from menu
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getloginpage]
as
begin
select * from loginpage	
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getLicensePayments]
as
begin
select * from LicensePayments
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdDelLicensePayments](@expiryOn datetime,@Id int,@licenseFor varchar(50),@licenseId int,@licenseType varchar(50),@paidon datetime,@renewedon datetime,@transId varchar (50))
as
begin
insert into LicensePayments (expiryOn,licenseFor,licenseId,licenseType,paidon,renewedon,transId) values(@expiryOn,@licenseFor,@licenseId,@licenseType,@paidon,@renewedon,@transId)
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetLicenceStatus]
AS
BEGIN
	
select * from LicenceStatus
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE[dbo].[InsUpdDelLicenceStatus](@Active NUMERIC(10),
              
           @Desc Varchar(30),
           
           @Id numeric(10),
           @LicenseStatusType varchar(30),
           @TypeGripId varchar(50))
AS
BEGIN
	

INSERT INTO 
[LicenceStatus] VALUES
           (@Active,
           @Desc,
           @Id,
           @LicenseStatusType,
           @TypeGripId )
   
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE[dbo].[InsUpdDelLicenceCatergories](@Active NUMERIC(10),
              
           @Desc Varchar(30),
           
           @Id numeric(10),
           @LicenseCategory varchar(30),
           @TypeGripId varchar(50))
AS
BEGIN
	

INSERT INTO 
[LicenceCatergories] VALUES
           (@Active,
              
          
           @Desc,
           @Id,
           @LicenseCategory,
           @TypeGripId )
   
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Get LicenceCatergories]
AS
BEGIN
	
select * from LicenceCatergories
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetLicenceCatergories]
AS
BEGIN
	
select * from LicenceCatergories
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetInventorySales]
As
BEGIN
SELECT sl.[Id]
      ,sl. ItemName
      ,sl.[Quantity]
      ,sl.PerUnitPrice
      ,sl.[PurchaseDate]
      ,sl.[InVoiceNumber]
  FROM [POSDashboard].[dbo].[InventorySales] sl
  


 


	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	
END



/****** Object:  StoredProcedure [dbo].[InsupddelInventorySales]    Script Date: 04/27/2016 17:49:02 ******/
SET ANSI_NULLS ON

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsupddelInventorySales] (@Id int,@ItemName varchar(50),@Quantity int,@PerUnitPrice int,@PurchaseDate varchar(50),@InVoiceNumber int)
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	INSERT INTO [POSDashboard].[dbo].[InventorySales]
           ([ItemName]
           ,[Quantity]
           ,[PerUnitPrice]
           ,[PurchaseDate]
           ,[InVoiceNumber])
     VALUES
    (@ItemName,@Quantity,@PerUnitPrice,@PurchaseDate,@InVoiceNumber)




END


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdDelInventoryReceivings](@amount int,@code varchar(50),@date varchar(50),@Id int,@inventoryId int,@quantity int,@reason varchar(50),@refundamt int,@returnedOn varchar(50),@transactionId int,@transactiontype varchar(50))
as
begin
insert into InventoryReceivings values(@amount,@code,@date,@Id,@inventoryId,@quantity,@reason,@refundamt,@returnedOn,@transactionId,@transactiontype)
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getInventoryReceivings]
as
begin
select * from InventoryReceivings
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetInventoryPurchases]
as
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id]
      ,[ItemName]
      ,[Quantity]
      ,[PerUnitPrice]
      ,[PurchaseDate]
      ,[PurchaseOrderNumber]
  FROM [POSDashboard].[dbo].[InventoryPurchases]



END


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsupdInventoryPurchases]  (@Id int,@ItemName varchar(50)
           ,@Quantity int
           ,@PerUnitPrice int 
           ,@PurchaseDate datetime
           ,@PurchaseOrderNumber varchar(20))
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	INSERT INTO [POSDashboard].[dbo].[InventoryPurchases]
           ([ItemName]
           ,[Quantity]
           ,[PerUnitPrice]
           ,[PurchaseDate]
           ,[PurchaseOrderNumber])
     VALUES
           (@ItemName
           ,@Quantity
           ,@PerUnitPrice
           ,@PurchaseDate
           ,@PurchaseOrderNumber)

END
/****** Object:  StoredProcedure [dbo].[GetAlerts]    Script Date: 04/28/2016 11:12:57 ******/
SET ANSI_NULLS ON

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdDelInventory](@Active int,@availableQty int,@category varchar(50)
,@code varchar(50),@desc varchar(50),@InventoryId int,@name varchar(50),@PerUnitPrice int,@reorderpoint int,@subcat varchar(50))
as
begin
insert into Inventory values(@Active,@availableQty,@category,@code,@desc,@InventoryId,@name,@PerUnitPrice,@reorderpoint,@subcat)
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getInventory]
as
begin
select * from Inventory
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetInventorySubCategories] 	
AS
BEGIN
	
	SELECT S.[Id]
      ,S.[Name]
      ,S.[Description]
      ,[CategoryId]
      ,t.NAME CATEGORY
      ,S.[Active]
  FROM [POSDashboard].[dbo].[SubCategory] S
  INNER JOIN Types T ON T.ID = S.CATEGORYID
  INNER JOIN TypeGroups TG ON TG.Id = T.TypeGroupId AND TG.ID = 1
   



	
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdTypes](@Id int,@Name varchar(50),@Description varchar(50) = null,@TypeGroupId varchar(50),@Active varchar(30))
as
begin

update types 
set name=@Name
,Active = @Active
,Description = @Description
,TypeGroupId = @TypeGroupId
where Id = @Id

if @@rowcount = 0 
begin
insert into Types(Name,[Description],TypeGroupId,Active) values(@Name,@Description,@TypeGroupId,@Active)
end

end



GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getTypes]

as
begin
SELECT t.Id, t.Name, t.[Description],t.Active, tg.name as TypeGroup, TypeGroupId, listkey, listvalue
	 from [Types] t
	 inner join TypeGroups tg on tg.Id = t.TypeGroupId	

END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTypesByGroupId]
@typegrpid int = -1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT t.Id, t.Name, t.[Description],t.Active, tg.name as TypeGroup, TypeGroupId, listkey, listvalue
	 from [Types] t
	 inner join TypeGroups tg on tg.Id = t.TypeGroupId	 
	  where (TypeGroupId = @typegrpid or @typegrpid = -1)
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSubCategories] 
(@catid int =-1)	
AS
BEGIN
	
	SELECT S.[Id]
      ,S.[Name]
      ,S.[Description]
      ,[CategoryId]
      ,t.NAME CATEGORY
      ,S.[Active]
  FROM [POSDashboard].[dbo].[SubCategory] S
  INNER JOIN Types T ON T.ID = S.CATEGORYID
  INNER JOIN TypeGroups TG ON TG.Id = T.TypeGroupId 
  where (S.CATEGORYID = @catid or @catid = -1)
   	
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getTypeGroups]
as
begin
select * from TypeGroups
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdTypeGroups](@Id int,@Name varchar(50)
,@Description varchar(50) = null,@Active int)
as
begin

update typegroups 
set name=@Name
,Active = @Active
,Description = @Description
where Id = @Id

if @@rowcount = 0 
begin
insert into TypeGroups (Name,[Description],Active) values(@Name,@Description,@Active)
end

end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE[dbo].[InsUpdDelTroubleTicketingStatus](@Active NUMERIC(10),
              
           @Desc Varchar(30),
           
           @Id numeric(10),
           @TtStatusType varchar(30),
           @TypeGripId varchar(50))
AS
BEGIN
	

INSERT INTO 
[TroubleTicketingStatus] VALUES
           (@Active,
              
          
           @Desc,
           @Id,
           @TtStatusType,
           @TypeGripId )
   
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetTroubleTicketingStatus]
AS
BEGIN
	
select * from TroubleTicketingStatus
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetTroubleTicketingSlaType]
AS
BEGIN
	
select * from TroubleTicketingSlaType
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE[dbo].[InsUpdDelTroubleTicketingSlaType](@Active NUMERIC(10),
              
           @Desc Varchar(30),
           
           @Id numeric(10),
           @TTSLAType varchar(30),
           @TypeGripId numeric(20))
AS
BEGIN
	

INSERT INTO 
[TroubleTicketingSlaType] VALUES
           (@Active,
              
          
           @Desc,
           @Id,
           @TTSLAType,
           @TypeGripId)
   
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Get TroubleTicketingSlaType]
AS
BEGIN
	
select * from TroubleTicketingSlaType
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdDelTroubleTicketingHandlers](@handledOn int,@Id int,@status int,@TTId int,@userid int)
as
begin
insert into TroubleTicketingHandlers values(@handledOn,@Id,@status,@TTId,@userid)
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getTroubleTicketingHandlers]
as
begin
select * from TroubleTicketingHandlers
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getTroubleTicketingDevice]
as
begin
select * from TroubleTicketingDevice
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdDelTroubleTicketingDevice](@deviceid int,@Id int,@ticketTypeId int,@TTId int)
as
begin
insert into TroubleTicketingDevice values(@deviceid,@Id,@ticketTypeId,@TTId)
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdDelTroubleTicketingDetails](@addInfo varchar(50),@createdBy varchar(50),@createdOn int,@Id int,@raisedBy varchar(50),@status int,@ticketinfo varchar(50),@ticketTypeId int,@TTId int)
as
begin
insert into TroubleTicketingDetails (addInfo,createdBy,createdOn,raisedBy,status,ticketinfo,ticketTypeId,TTId) values(@addInfo,@createdBy,@createdOn,@raisedBy,@status,@ticketinfo,@ticketTypeId,@TTId)
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getTroubleTicketingDetails]
as
begin
select * from TroubleTicketingDetails
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getTroubleTicketingCategories]
as
begin
select * from TroubleTicketingCategories
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpDelTroubleTicketingCategories](@active int,@desc varchar(50),@Id int,@TTCategory varchar(50),@typegrpid int)
as
begin
insert into TroubleTicketingCategories values(@active,@desc,@Id,@TTCategory,@typegrpid)
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdDelTransactionTypes](@active int,@desc varchar(50),@Id int,@TransactionTypes varchar(50),@typegrpid int)
as
begin
insert into TransactionTypes values(@active,@desc,@Id,@TransactionTypes,@typegrpid)
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getTransactionTypes]
as
begin
select * from TransactionTypes
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getTransactions]
as
begin
select * from Transactions
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdDelTransactions]
(@Id int
,@barcode varchar(50)=''
,@BTPOSid varchar(50)
,@busNumber varchar(50)
,@busId int=''
,@change varchar(50)=''
,@company varchar(50)
,@companyId varchar(50)=''
,@ConductorId varchar(50)=''
,@ConductorName varchar(50)=''
,@Date datetime=''
,@destination varchar(50)=''
,@fare varchar(50)=''
,@greetingMessage varchar(50)
,@luggageType varchar(50)
,@passengerType varchar(50)
,@passengerId varchar(50)
,@paymentId varchar(50)=''
,@printdataId varchar(50)
,@route varchar(50)=''
,@routecode varchar(50)=''
,@routeId varchar(50)
,@source varchar(50)=''
,@time datetime
,@ticketHolderId varchar(50)=''
,@ticketHolderName  varchar(50)
,@TicketNumber  varchar(50)
,@ticketValidityPeriod  varchar(50)=''
,@totalamount int
,@amountpaid int
,@TransactionCode varchar(50)
,@TransactionId varchar(50)=''
,@transactionType varchar(50)
,@userid int
,@ChangeRendered varchar(50)='fgg')

as
begin	
insert into Transactions (barcode,BTPOSid,busNumber,
busId,change,company,companyId,ConductorId,ConductorName,
Date,destination,fare,greetingMessage,luggageType,
passengerType,passengerId,paymentId,printdataId,route,
routecode,routeId,source,time,ticketHolderId,
ticketHolderName,TicketNumber,ticketValidityPeriod,totalamount,amountpaid,
TransactionCode,TransactionId,transactionType,userid,ChangeRendered) values(@barcode,@BTPOSid,@busNumber,
@busId,@change,@company,@companyId,@ConductorId,@ConductorName,
@Date,@destination,@fare,@greetingMessage,@luggageType,
@passengerType,@passengerId,@paymentId,@printdataId,@route,
@routecode,@routeId,@source,@time,@ticketHolderId,
@ticketHolderName,@TicketNumber,@ticketValidityPeriod,@totalamount,@amountpaid,
@TransactionCode,@TransactionId,@transactionType,@userid,@ChangeRendered)
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdDelTransactionMaster](@Id int,@TransCode varchar(50),@Date DateTime,@TransType varchar(50))
as
begin
insert into TransactionMaster values(@Id,@TransCode,@Date,@TransType)
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getTransactionMaster]
as
begin
select * from TransactionMaster
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getTransactionDetails]
as
begin
select * from TransactionDetails
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdDelTransactionDetails](@Id int,@TransId varchar(50),@TotalAmt int,@PaymentId varchar(50),@BTPOSid varchar(50))
as
begin
insert into TransactionDetails values(@Id,@TransId,@TotalAmt,@PaymentId,@BTPOSid)
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getTicketGeneration]
as
begin
select * from TicketGeneration
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdDelTicketGeneration](@Source varchar(50),@Target varchar(50),@NoOfTickets int)
as
begin
insert into TicketGeneration values (@Source,@Target,@NoOfTickets)
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Gettable2]
AS
BEGIN
	
select * from table2
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetInventoryItem]
as 
begin
SELECT I.[Id]
      ,[ItemName]
      ,[Code]
      ,I.[Description]
      ,t.name as Category
      ,t.id as categoryid
      ,s.name as SubCategory
      ,s.id as SubCategoryId
      ,[ReOrderPoint]
  FROM [POSDashboard].[dbo].[InventoryItem]I
 inner join types t on t.id = i.categoryid
 INNER JOIN SubCategory s  ON s.id = I.SubCategoryid
  
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsUpdelStops]
	-- Add the parameters for the stored procedure here
(@Id int,
      @Name varchar(30),
      @Description varchar(30) = null,
      @Code varchar(10),
      @Active int,
      @insupdflag varchar(10))
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	if @insupdflag='I'
INSERT INTO Stops
           (Name,
           [Description],
           Code,
           Active)
           values(@Name,
           @Description,
           @Code,
           @Active)
     
else

  if @insupdflag = 'U'
UPDATE Stops
   SET Name = @Name ,
      [Description] = @Description  ,
      Code = @Code ,
      Active = @Active 
 WHERE id=@id

else
  delete from stops where id = @id

END

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetStops]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Code]
      ,[Active]
  FROM [POSDashboard].[dbo].[Stops]




END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetSMSProviderConfig]
AS
BEGIN
	
select * from SMSProviderConfig
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE[dbo].[InsUpdDelSMSProviderConfig](@Id numeric(20),
           @ProviderName varchar(20),
           @BTPOSGRPID varchar(20),
           @Active varchar(20),
           @UserId numeric(20),
           @Passkey varchar(20))
AS
BEGIN
	

INSERT INTO 
[SMSProviderConfig] VALUES
           (@Id,
           @ProviderName,
           @BTPOSGRPID,
           @Active,
           @UserId,
           @Passkey)
   
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getSMSEmailSubscribers]
as
begin
select * from SMSEmailSubscribers
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdDelSMSEmailSubscribers](@AlertId int,@emailid varchar(50),@enddate datetime,@frequency int,@Id int,@phNo varchar(50),@startdate datetime,@userid int)
as
begin
insert into SMSEmailSubscribers values(@AlertId,@emailid,@enddate,@frequency,@Id,@phNo,@startdate,@userid)
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getSMSEmailConfiguration]
as
begin
select * from SMSEmailConfiguration
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdDelSMSEmailConfiguration](@AlertTypeId int,@enddate datetime,@hashkey datetime,@Id int,@providername varchar(50),@pwd varchar(50),@saltkey datetime,@startdate datetime,@username varchar(50))
as
begin
insert into SMSEmailConfiguration values(@AlertTypeId,@enddate,@hashkey,@Id,@providername,@pwd,@saltkey,@startdate,@username)
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getRoutesConfiguration]
as
begin
select * from RoutesConfiguration
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdDelRoutesConfiguration](@distanceFromDest int,@distanceFromLastStop int,@distanceFromPrevStop int,@distanceFromSource int,@Id int,@routeId int,@stops varchar(50))
as
begin
insert into RoutesConfiguration values(@distanceFromDest,@distanceFromLastStop,@distanceFromPrevStop,@distanceFromSource,@Id,@routeId,@stops)
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[GetRouteFare]
AS
BEGIN
	
SELECT 
      [Id]
      ,[RouteId]
      ,[VehicleType]
      ,[SourceStopId]
      ,[DestinationStopId]
      ,[Distance]
      ,[PerUnitPrice]
      ,[Amount]
      ,[FareType]
      ,[Active]
  FROM [POSDashboard].[dbo].[RouteFare]




end

/****** Object:  StoredProcedure [dbo].[getRouteDetails]    Script Date: 05/02/2016 17:05:58 ******/
SET ANSI_NULLS ON

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[getRouteDetails]
(@routeid int = -1)
as
begin

SELECT r.[Id]
      ,r.routename as routename
	  ,r.code as routecode      
      ,src.name source
      , dest.name dest
  FROM [POSDashboard].[dbo].[Routes] r
inner join stops src on src.id = r.sourceid
inner join stops dest on dest.id = r.destinationid
where r.Id = @routeid or @routeid = -1

SELECT rd.[Id]
      ,r.routename as routename
	  ,r.code as routecode
      ,[RouteId]      
      ,stopid
      ,src.name StopName
      ,src.code StopCode
	  ,[PreviousStopId]
      ,[NextStopId]
      ,prevstops.name prevstop
      ,nextstops.name nextstop
      ,[DistanceFromSource]
      ,[DistanceFromDestination]
      ,[DistanceFromPreviousStop]
      ,[DistanceFromNextStop]     
  FROM [POSDashboard].[dbo].[RouteDetails] rd
  inner join stops src on src.id = rd.stopid
inner join routes r on r.id = rd.routeid
inner join stops prevstops on prevstops.id =previousstopid
inner join stops nextstops on nextstops.id = nextstopid
  where (@routeid = -1 or routeid = @routeid)
end


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[InsUpdDelRouteDetails]    Script Date: 04/13/2016 11:13:24 ******/


CREATE procedure [dbo].[InsUpdDelRouteDetails](@Id int,@RouteId int,@stopId int ,@DistanceFromSource int,@DistanceFromDestination int,@DistanceFromPreviousStop int,@DistanceFromNextStop int,@PreviousStopId int,@NextStopId int)
as
begin
insert into RouteDetails (RouteId,StopId,DistanceFromSource,DistanceFromDestination,DistanceFromPreviousStop,DistanceFromNextStop,PreviousStopId,NextStopId) values(@RouteId,@stopId,@DistanceFromSource,@DistanceFromDestination,@DistanceFromPreviousStop,@DistanceFromNextStop,@PreviousStopId,@NextStopId)
end
select * from RouteDetails

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdDelRoles](@Id int,@Name varchar(50)
,@Description varchar(50) = null,@Active int = 1
,@IsPublic int = 1)
as
begin

update roles 
set Name = @name,
Description = @Description,
Active = @Active,
IsPublic = @IsPublic
where id = @Id

if @@rowcount = 0
begin
insert into Roles (Name,[Description],Active,IsPublic) 
values(@Name,@Description,@Active,@IsPublic)
end

end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getRegistrationBTPOS]
as
begin
select * from RegistrationBTPOS
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdDelRegistrationBTPOS](@code varchar(50),@uniqueId varchar(50),@ipconfig varchar(50),
                                                    @Active int)
as
begin
insert into RegistrationBTPOS values (@code,@uniqueId,@ipconfig,@Active)
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetDashboardDetails]
(@userid int = -1, @roleid int = -1)
as
begin
--
--get btpos details
SELECT b.[Id]
     -- ,[GroupId]
    --  ,c.Name as companyname
      ,[POSID]
      ,[StatusId]
      ,t.Name as [status]
      ,[IMEI]
      ,[ipconfig]
      ,b.[active]
      ,u.FirstName + ' '+ u.LastName as fleetowner
      ,u.Id as fleetownerid
  FROM [POSDashboard].[dbo].[BTPOSDetails] b
  left outer join Types t on t.Id = statusid
  left outer join Company c on c.Id = CompanyId
  left outer join Users u on u.Id = u.companyid
where (u.id = @userid or @userid = -1)

--get license details
--get alerts
select t1.Id,
t1.Date,
t1.Message,
t1.MessageTypeId,
t1.StatusId,
t1.UserId,
t1.Name,
t2.FirstName,
t2.LastName
 from Alerts t1
 inner join Users t2 on t2.Id=t1.UserId
 
--get notifications

select t1.Id,
t1.Date,
t1.Message,
t1.MessageTypeId,
t1.StatusId,
t1.UserId,
t1.Name,
t2.FirstName,
t2.LastName
 from Notifications t1
 inner join Users t2 on t2.Id=t1.UserId

end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdUsers](
@FirstName varchar(40)
,@LastName varchar(40)
,@MiddleName varchar(40) = ''
,@EmpNo varchar(15)
,@Email varchar(40) = ''
,@AdressId int
,@MobileNo varchar(50) = ''
,@RoleId int
,@cmpId int
,@Active int
,@UserName varchar(30)  = ''
,@Password varchar(30)  = ''
,@insupdflag varchar(10)
,@userid int = -1)
 as begin
 
 declare @currid int
 declare @cnt int
 declare @logincnt int
 declare @ulogincnt int
 
 if @insupdflag = 'I'
 begin
 
 select @cnt = COUNT(*)  from Users where UPPER(EmpNo) = @EmpNo
 
 select @logincnt = COUNT(*) from userlogins where upper(logininfo) = UPPER(@username) 
 
 if @cnt > 0
 RAISERROR ('Already user exists',16,1);
 
  
 if @cnt = 0 
 begin
	insert into Users(FirstName,LastName,MiddleName, EmpNo,Email,AddressId,MobileNo,Active,CompanyId)
	values(@FirstName,@LastName,@MiddleName, @EmpNo,@Email,@AdressId,@MobileNo,@Active,@cmpId) 
  
 
    SELECT @currid = @@IDENTITY
 end
  
  if @logincnt > 0
	RAISERROR ('Already user login exists',16,1);
 
   if @logincnt = 0 and @UserName is not null
   begin
	insert into userlogins(logininfo,PassKey,active,userid)values(@UserName,@Password,1,@currid)
   end
end
 else
 
 begin
 
 SELECT @currid = @userid
 
 update Users 
 set FirstName = @FirstName,
 LastName = @LastName,
 MiddleName = @MiddleName,
 Email = @Email,
 MobileNo = @MobileNo, 
 Active = @Active 
 where id = @userid
 
 select @logincnt = COUNT(*) from userlogins where  userid = @userid
 
 
 if @logincnt = 0
  --login is not existing hence insert 
 if @UserName is not null
 insert into userlogins(logininfo,PassKey,active,userid)values(@UserName,@Password,1,@userid)
 
 else
 begin
 --check if updation causes duplicates
 select @ulogincnt = COUNT(*) from userlogins where upper(logininfo) = UPPER(@username) and userid <> @userid
 
 if @ulogincnt = 0
 	update userlogins
	set logininfo = @UserName
	,PassKey = @Password
	,active = @active
	where userid = @currid
else
 RAISERROR ('User login already exists',16,1);
 end

 
 end --end of 'i' check
 
 --if role is fleet owner then insert the code into fleet owner table
 
 declare @fcnt int
 
 if @RoleId = 6
 begin
 
 select @fcnt = COUNT(*) from FleetOwner where UserId = @currid
 
			 if @fcnt = 0 
				INSERT INTO [POSDashboard].[dbo].[FleetOwner]
					   ([UserId]
					   ,[CompanyId]
					   ,[Active]
					   ,[FleetOwnerCode])
				 VALUES
					   (@currid
					   ,1
					   ,1
					   ,@EmpNo)
				else
					UPDATE [POSDashboard].[dbo].[FleetOwner]
						SET 
						[CompanyId] = 1
						,[Active] = 1
						,[FleetOwnerCode] = @EmpNo
					 WHERE [UserId] = @currid
 
 end
 
 
 end
 
--select * from FleetOwner

--select * from Roles

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ValidateCredentials](@logininfo varchar(50) = null, @passkey varchar(50) = null)
as
begin

select logininfo,firstname, lastname,u.Id ,r.Name as RoleName,ur.roleid
from userlogins ul 
inner join users u on 
u.id = ul.userid
left outer join UserRoles ur on ur.UserId=u.Id
left outer join roles r on r.id = ur.roleid
where LoginInfo=@logininfo and [PassKey]=@passkey

end



GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE[dbo].[InsUpdDelZipCode](@Id NUMERIC(20),
           @Code varchar(30),
           @Active varchar(30))
           
AS
BEGIN
	

INSERT INTO 
[ZipCode] VALUES
           (@Id
           ,@Code,
           @Active)
   
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetZipCode]
AS
BEGIN
	
select * from ZipCode
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getVehicleDetails]
as
begin
select * from VehicleDetails
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsupdDelInventoryItem]
(@Id int,
@ItemName varchar(50),
@Code varchar(50),
@Description varchar(50) = null,
@CategoryId int,
@SubCategoryId int,
@ReOrderPoint int)
as 
begin

UPDATE [POSDashboard].[dbo].[InventoryItem]
   SET [ItemName] = @ItemName
      ,[Code] = @Code
      ,[Description] = @Description
      ,[CategoryId] = @CategoryId
      ,[SubCategoryId] = @SubCategoryId
      ,[ReOrderPoint] = @ReOrderPoint
 WHERE Id = @Id

if @@rowcount = 0 
begin
insert into InventoryItem
(ItemName,Code,[Description],CategoryId,SubCategoryId,ReOrderPoint)values
(@ItemName,@Code,@Description,@CategoryId,@SubCategoryId,@ReOrderPoint)
end

end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetFleetBtpos] 
	-- Add the parameters for the stored procedure here
	(@cmpId int=-1, @fleetOwnerId int = -1)
AS
BEGIN
SELECT fb.[Id]
      ,[VehicleId]
      ,[FromDate]
      ,[ToDate]
      ,[BTPOSId]
      ,bt.POSID
      ,fd.VehicleRegNo
  FROM [POSDashboard].[dbo].[FleetBtpos] fb
  inner join fleetdetails fd on fd.id = fb.vehicleid
  inner join BTPOSDetails bt on bt.id = fb.btposid
 where ((fd.companyid = @cmpId or @cmpId = -1)
  and (fd.fleetownerid = @fleetOwnerId or @fleetOwnerId = -1))


END


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetfleetRoutes] 	
(@routeid int =-1, @fleetownerId int = -1, @cmpId int = -1)
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT fr.[Id]
      ,fr.[VehicleId]
      ,fr.[RouteId]
      ,fd.VehicleRegNo
      ,r.RouteName
      ,[EffectiveFrom]
      ,[EffectiveTill]
      ,[RouteName]
  FROM [POSDashboard].[dbo].[FleetRoutes] fr
  inner join FleetDetails fd on fd.Id = fr.VehicleId
  inner join Routes r on r.Id = fr.RouteId
  where ((@routeid = -1 or fr.RouteId = @routeid)
and (fd.CompanyId = @cmpid or @cmpId = -1)
and (fd.fleetownerid = @fleetownerId or @fleetownerId = -1))


END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsupdelFleetDetails]
 (@Id int,
 @VehicleRegNo varchar(15)
           ,@VehicleTypeId int
           ,@FleetOwnerId int
           ,@CompanyId int
           ,@ServiceTypeId int
           ,@VehicleLayoutId int
           ,@Active int
           )
	-- Add the parameters for the stored procedure here
	
AS
BEGIN

update [POSDashboard].[dbo].[FleetDetails]
set
[VehicleRegNo] = @VehicleRegNo 
,[VehicleTypeId] = @VehicleTypeId 
,[FleetOwnerId] = @FleetOwnerId 
,[CompanyId] = @CompanyId 
,[ServiceTypeId] = @ServiceTypeId
,[LayoutTypeId] = @VehicleLayoutId
,[Active] = @Active
where Id = @Id

if @@ROWCOUNT = 0
begin
	INSERT INTO [POSDashboard].[dbo].[FleetDetails]
           ([VehicleRegNo]
           ,[VehicleTypeId]
           ,[FleetOwnerId]
           ,[CompanyId]
           ,[ServiceTypeId]
           ,[LayoutTypeId]
           ,[Active])
     VALUES
           (@VehicleRegNo 
           ,@VehicleTypeId 
           ,@FleetOwnerId 
           ,@CompanyId 
           ,@ServiceTypeId 
           ,@VehicleLayoutId
           ,@Active )

end


END



GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsUpdDelFleetStaff]
@Id int = -1,
@RoleId int,
@UserId int,
@VehicleId int,
@cmpId int,
@FromDate datetime = null,
@ToDate datetime = null,
@insupddelflag varchar
as
begin

declare @cnt  int
set @cnt = -1

if @insupddelflag = 'I'

select @cnt = count(1) from [POSDashboard].[dbo].FleetAvailability 
where vehicleid = @vehicleid 

if @cnt = 0 
begin
INSERT INTO [POSDashboard].[dbo].[FleetAvailability]
           ([VehicleId]
           ,[FromDate]
           ,[ToDate])
     VALUES
           (@VehicleId
           ,@FromDate
           ,@ToDate)
end
else
  if @insupddelflag = 'U'

UPDATE [POSDashboard].[dbo].[FleetAvailability]
   SET [FromDate] = @FromDate
      ,[ToDate] = @ToDate      
 WHERE [VehicleId] = @VehicleId

else
  delete from [POSDashboard].[dbo].[FleetAvailability]
where vehicleid = @vehicleid 


End

/****** Object:  Table [dbo].[FleetOwnerRouteStop]    Script Date: 05/02/2016 16:31:56 ******/
SET ANSI_NULLS ON

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetFleetAvailability]
(@cmpId int=-1, @fleetOwnerId int = -1)
as
begin
SELECT fa.[Id]
      ,fd.VehicleRegNo
      ,[VehicleId]
      ,[FromDate]
      ,[ToDate]
      ,u.firstname + ' ' + u.lastname as FleetOwner
  FROM [POSDashboard].[dbo].[FleetAvailability] FA
  inner join fleetdetails fd on fd.id = FA.vehicleid
  inner join users u on u.id = fd.fleetownerid
 where ((fd.companyid = @cmpId or @cmpId = -1)
  and (fd.fleetownerid = @fleetOwnerId or @fleetOwnerId = -1))

end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[GetFleetOwnerRouteStop]
AS
BEGIN
	
SELECT 
      [Id],
      [FleetOwnerId],
      [RouteId],
      [StopNo],
      [PreviousStop],
      [NextStop],
      [Active],
      [StopId]
   
      
  FROM [POSDashboard].[dbo].[FleetOwnerRouteStop]




end
/****** Object:  StoredProcedure [dbo].[InsUpdDelRouteStops]    Script Date: 05/02/2016 16:31:14 ******/
SET ANSI_NULLS ON

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[InsUpdDelFleetOwnerRouteFare](@Id numeric(30),
                        @RouteId numeric(30),
                        @VehicleType varchar(30),
                        @SourceStopId numeric(30),
                        @DestinationStopId numeric(30),
                        @Distance varchar(30),
                        @PerUnitPrice numeric(30),
                        @Amount numeric(30),
                        @CompanyId numeric(30),
                        @FleetOwnerId numeric(30),
                        @FareType varchar(30),
                        @Active numeric(30)
                       )
                        
as
begin
insert into FleetOwnerRouteFare values(
                          @RouteId,
                          @VehicleType,
                          @SourceStopId,
                          @DestinationStopId,
                          @Distance,
                          @PerUnitPrice,
                          @Amount,
                         @CompanyId,
                         @FleetOwnerId,
                         @FareType,
                         @Active)
                        
end
/****** Object:  Table [dbo].[FleetOwnerRoute]    Script Date: 05/02/2016 17:11:26 ******/
SET ANSI_NULLS ON

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetFleetOwnerRouteFare]
AS
BEGIN
	
SELECT 
      [Id],
      [RouteId],
      [VehicleType],
      [SourceStopId],
      [DestinationStopId],
      [Distance],
      [PerUnitPrice],
      [Amount],
      [CompanyId],
      [FleetOwnerId],
      [FareType],
      [Active]
   
      
  FROM [POSDashboard].[dbo].[FleetOwnerRouteFare]




end
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 05/07/2016 11:08:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[CompanyId] [int] NULL
) ON [PRIMARY]

GO

/****** Object:  StoredProcedure [dbo].[InsUpdDelFleetOwnerRouteFare]    Script Date: 05/02/2016 16:34:55 ******/
SET ANSI_NULLS ON

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[GetFleetOwnerRoute]
AS
BEGIN
	
SELECT 
      [Id],
      [FleetOwnerId],
      [CompanyId],
      [RouteId],
      [From],
      [To],
      [Active]
      
  FROM [POSDashboard].[dbo].[FleetOwnerRoute]




end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ValidateFleetOwnerCode]
	@fleetownercode varchar(10),
	@result int out 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	
	select @result = COUNT(*) from FleetOwner where UPPER(FleetOwnerCode) = UPPER(@fleetownercode)

    -- Insert statements for procedure here
	return @result
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdDelFleetOwner](@Id int,@UserId varchar(50),@BTPOSgroupid varchar(50),@Active varchar(50))
as
begin
insert into FleetOwner values(@Id,@UserId,@BTPOSgroupid,@Active)
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getFleetOwner]
as
begin
select u.FirstName+' '+u.LastName as Name,
c.Name as CompanyName
,FO.FleetOwnerCode
,FO.CompanyId
,U.Id
 from FleetOwner FO
inner join Users u on  u.Id = FO.UserId
inner join Company c on c.Id = FO.companyId

end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getFares]
as
begin
select * from Fares
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdDelFares](@Id int,@FromStop varchar(50),@ToStop varchar(50),@Fare varchar(50),@Active varchar(50),@RouteId varchar(50),@Name varchar(50))
as
begin
insert into Fares values(@Id,@FromStop,@ToStop,@Fare,@Active,@RouteId,@Name)
end



/****** Object:  StoredProcedure [dbo].[Sp_InsTypeGroups]    Script Date: 05/04/2016 11:24:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Sp_InsTypeGroups](@Id int,@Name varchar(50),@Description varchar(50) =null,@Active int)
as
begin
insert into TypeGroups (Name,[Description],Active) values(@Name,@Description,@Active)
end

GO
/****** Object:  StoredProcedure [dbo].[getCompanyRoles]    Script Date: 05/04/2016 11:37:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[getCompanyRoles]
(@cmpId int)
as
begin
select cr.[Id]
,cr.[RoleId]
,cr.[CompanyId] 
,c.Name company
,r.name as rolename
,r.description
from [CompanyRoles] cr
inner join Roles R on R.Id=cr.RoleId
inner join Company c on c.Id=cr.CompanyId
where cr.CompanyId = @cmpId

end
GO

/****** Object:  StoredProcedure [dbo].[GetNotifications]    Script Date: 05/05/2016 18:47:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetNotifications]

as begin 
select t1.Id,
t1.Date,
t1.Message,
t1.MessageTypeId,
t1.StatusId,
t1.UserId,
t1.Name,
t2.FirstName,
t2.LastName
 from Notifications t1
 inner join Users t2 on t2.Id=t1.UserId
end


GO
/****** Object:  StoredProcedure [dbo].[GetAlerts]    Script Date: 05/05/2016 18:47:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetAlerts]

as begin 
select t1.Id,
t1.Date,
t1.Message,
t1.MessageTypeId,
t1.StatusId,
t1.UserId,
t1.Name,
t2.FirstName,
t2.LastName
 from Alerts t1
 inner join Users t2 on t2.Id=t1.UserId
                        
                         
                     
end

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetCategories]
@typegrpid int = -1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT t.Id, t.Name, t.[Description],t.Active,  TypeGroupId, listkey, listvalue
	 from [Types] t 
	  where t.TypeGroupId = 2
	  
	 -- SELECT t.Id, t.Name, t.[Description],t.Active, tg.name as TypeGroup, TypeGroupId, listkey, listvalue
	 --from [Types] t
	 --inner join TypeGroups tg on tg.Id = t.TypeGroupId	 
	 -- where tg.Id=30
	 -- select I.InventoryId,I.Name,I.Code,I.
	 -- [Description],I.AvailableQty,tg.Name as Category,t.TypeGroupId as SubCategoryId,I.PerUnitPrice,I.ReorderPont,I.Active from Inventory I inner join TypeGroups tg on tg.Id=I.InventoryId
  --   inner join Types t on t.Id=I.InventoryId
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[InsUpdDelUserRoles](
@Id int,
@roleid int,
@UserId int,
@CompanyId int = null
)
as
begin


UPDATE [POSDashboard].[dbo].[UserRoles]
   SET [UserId] = @UserId
      ,[RoleId] = @RoleId
      ,[CompanyId] = @CompanyId
 WHERE Id = @Id




if @@rowcount = 0 
begin

INSERT INTO [POSDashboard].[dbo].[UserRoles]
           ([UserId]
           ,[RoleId]
           ,[CompanyId])
     VALUES
           (@UserId
           ,@RoleId
           ,@CompanyId)
end


end

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdDelSubCategory]
(@Id int,@Name varchar(50),@Description varchar(50) = null,@CategoryId int,@Active int)
as
begin

update subcategory 
set name=@Name
,Active = @Active
,Description = @Description
,CategoryId = @CategoryId
where Id = @Id

if @@rowcount = 0 
begin
insert into subcategory(Name,[Description],CategoryId,Active) values(@Name,@Description,@CategoryId,@Active)
end

end

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[InsupdCreateFleetOwner]
	-- Add the parameters for the stored procedure here
	(@Id int,
           @FirstName varchar(30),
           @LastName varchar(30)
           ,@Email varchar(30)
           ,@MobileNo varchar(30)
           ,@CompanyName varchar(30)
           ,@Description varchar(30) = null,
           @insupdflag varchar(10),@CompanyGroupId int=-1)
           
AS 
BEGIN
declare @currid int
 declare @cnt int 
set @cnt = 0
declare @cmpcnt int
set @cmpcnt = 0
 declare @fleetcnt int
set @fleetcnt = 0

declare @cmpid int
set @cmpid = 0
 
 declare @fc varchar(10) 
 set @fc = case when (select COUNT(*) from Users) = 0
                           then '001' 
                           else (select ltrim(rtrim(STR((max(Id)+1)))) from Users ) 
                           end  
 
 
 select @cnt=COUNT (*) from Users where FirstName=@FirstName
 select @cmpcnt=COUNT (*) from Company where UPPER (Name)=@CompanyName
 select @fleetcnt=COUNT (*) from FleetOwner where UPPER (FleetOwnerCode)=@fc

 	
 if @cmpcnt=0
 begin
  insert into Company 
           ([Name]
           ,[Code]
           ,[Desc]
           ,[Active])      
     VALUES
           (@CompanyName,@CompanyName,@Description,1)
           
           SELECT @cmpid = @@IDENTITY
 end
 else
 begin  
   SELECT @cmpid = Id from Company where UPPER (Name)=@CompanyName
   
 end
   
 
 
 if @insupdflag='I' and @cnt>0
 begin
 RAISERROR ('Already user exists',16,1);
 end
 
 if @cnt=0
 begin
 
   insert into Users (FirstName,
   LastName,MiddleName, EmpNo,Email,AddressId,MobileNo,Active,CompanyId)
   values(@FirstName,@LastName,null,'FL00'+@fc,@Email,null,@MobileNo,1,@cmpid) 
          
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	
	
	SELECT @currid = @@IDENTITY
end

	

   
   --insert company role for company and fleet owner role
  exec  InsUpdDelCompanyRoles 1,-1,@cmpid,2,0 
                 
 if @insupdflag='I'and @fleetcnt>0
 begin
	RAISERROR ('Already FleetOwner exists',16,1);
 end
 
 if @fleetcnt=0
 begin
	insert into FleetOwner (UserId,CompanyId,FleetOwnerCode,Active) values(@currid,'','FL00'+@fc,1)
 end

--assign fleet owner role to user
exec [InsUpdDelUserRoles] -1,2,@currid,@cmpid
end



GO






/****** Object:  Table [dbo].[LicensePricing]    Script Date: 05/10/2016 07:02:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LicensePricing](
	[Id] [int] NOT NULL,
	[LicenseId] [int] NOT NULL,
	[TimePeriod] [varchar](50) NULL,
	[MinTimePeriods] [int] NULL,
	[UnitPrice] [decimal](18, 0) NULL,
	[fromdate] [datetime] NULL,
	[todate] [datetime] NULL,
	[Active] [int] NULL CONSTRAINT [DF_LicensePricing_Active]  DEFAULT ((1))
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[LicenseDetails]    Script Date: 05/10/2016 06:45:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LicenseDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LicenseCode] [varchar](10) NULL,
	[LicenseName] [varchar](50) NULL,
	[LicenseCatId] [int] NOT NULL,
	[FeatureName] [varchar](50) NULL,
	[FeatureLabel] [varchar](50) NULL,
	[FeatureValue] [nchar](10) NULL,
	[LabelClass] [varchar](50) NULL,
	[Active] [int] NOT NULL CONSTRAINT [DF_LicenseDetails_Active]  DEFAULT ((1)),
	[fromDate] [datetime] NULL,
	[toDate] [datetime] NULL
) ON [PRIMARY]

GO


/****** Object:  Table [dbo].[RouteStops]    Script Date: 05/16/2016 22:05:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RouteStops](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RouteId] [int] NOT NULL,
	[FromStopId] [int] NOT NULL,
	[ToStopId] [int] NOT NULL
) ON [PRIMARY]


GO

CREATE procedure [dbo].[InsUpdDelRoutes](
@Id int
,@RouteName varchar(50)
,@Description varchar(50) = null
,@Active int
,@Code varchar(10)
,@SourceId int
,@DestinationId int
,@Distance decimal
)
as
begin

declare @routeid int


UPDATE [POSDashboard].[dbo].[Routes]
   SET [RouteName] = @RouteName
      ,[Code] = @Code
      ,[Description] = @Description
      ,[Active] = @Active
      ,[SourceId] = @SourceId
      ,[DestinationId] = @DestinationId
      ,[Distance] = @Distance
 WHERE Id = @Id

if @@rowcount = 0 
begin

INSERT INTO [POSDashboard].[dbo].[Routes]
           ([RouteName]
           ,[Code]
           ,[Description]
           ,[Active]
           ,[SourceId]
           ,[DestinationId]
           ,[Distance])
     VALUES
           (@RouteName
           ,@Code
           ,@Description
           ,@Active
           ,@SourceId
           ,@DestinationId
           ,@Distance)

select @routeid = @@IDENTITY

--insert the source stop
INSERT INTO [POSDashboard].[dbo].[RouteDetails]
           ([RouteId]
           ,[StopId]
           ,[DistanceFromSource]
           ,[DistanceFromDestination]
           ,[DistanceFromPreviousStop]
           ,[DistanceFromNextStop]
           ,[PreviousStopId]
           ,[NextStopId])
     VALUES
           (
			@routeid
           ,@SourceId
           ,@Distance
           ,@Distance
           ,@Distance
           ,@Distance
           ,@SourceId
           ,@DestinationId
          )

--insert the destination stop
INSERT INTO [POSDashboard].[dbo].[RouteDetails]
           ([RouteId]
           ,[StopId]
           ,[DistanceFromSource]
           ,[DistanceFromDestination]
           ,[DistanceFromPreviousStop]
           ,[DistanceFromNextStop]
           ,[PreviousStopId]
           ,[NextStopId])
     VALUES
           (
			@routeid
           ,@DestinationId
           ,@Distance
           ,@Distance
           ,@Distance
           ,@Distance
           ,@SourceId
           ,@DestinationId
          )

          INSERT INTO [POSDashboard].[dbo].[RouteStops]
           ([RouteId]
           ,[FromStopId]
           ,[ToStopId])
     VALUES
           (@routeid
           ,@SourceId
           ,@DestinationId)
     
end
end



/****** Object:  StoredProcedure [dbo].[GetLicenseDetails]    Script Date: 05/11/2016 08:42:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetLicenseDetails]

as begin 
select Id,
LicenseCode,
LicenseName,
LicenseCatId,
FeatureName,
FeatureLabel,
FeatureValue,
LabelClass,
Active,
fromDate,
toDate
 from LicenseDetails
end
GO



/****** Object:  StoredProcedure [dbo].[InsUpdDelLicenseDetails]    Script Date: 05/11/2016 08:43:10 ******/
--SET ANSI_NULLS ON
--GO

--SET QUOTED_IDENTIFIER ON
--GO

--CREATE procedure [dbo].[InsUpdDelLicenseDetails](@Id int,
--@LicenseCode varchar(10),
--@LicenseName Varchar(50),
--@LicenseCatId int,
--@FeatureName varchar(50),
--@FeatureLabel varchar(30),
--@FeatureValue varchar(10),
--@LabelClass varchar(50),
--@Active int,
--@fromDate datetime,
--@toDate datetime)

--as
--begin
--insert into LicenseDetails values(
--@LicenseCode,
--@LicenseName,
--@LicenseCatId,
--@FeatureName,
--@FeatureLabel,
--@FeatureValue,
--@LabelClass,
--@Active,
--@fromDate,
--@toDate
--)



--end



/****** Object:  StoredProcedure [dbo].[Sp_InsTypeGroups]    Script Date: 05/04/2016 11:24:12 ******/
SET ANSI_NULLS ON

GO




/****** Object:  StoredProcedure [dbo].[GetLicensePricing]    Script Date: 05/11/2016 09:34:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetLicensePricing]

as begin 
select Id,
LicenseId,
TimePeriod,
MinTimePeriods,
UnitPrice,
fromdate,
todate,
Active

 from LicensePricing
end

/****** Object:  StoredProcedure [dbo].[InsUpdDelLicensePricing]    Script Date: 05/11/2016 11:19:59 ******/

/****** Object:  StoredProcedure [dbo].[InsUpdDelLicenseDetails]    Script Date: 05/11/2016 11:42:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[InsUpdDelLicensePricing](
@Id int,
@LicenseId varchar(10),
@TimePeriod Varchar(50),
@MinTimePeriods int,
@UnitPrice decimal(18,0),
@fromdate datetime,
@todate datetime,

@Active int
)
--@fromDate datetime=getdate(),
--@toDate datetime=getdate())

as
begin

UPDATE [POSDashboard].[dbo].[LicensePricing]
   SET 
      [LicenseId] = @LicenseId
      ,[TimePeriod] = @TimePeriod
      ,[MinTimePeriods] = @MinTimePeriods
      ,[UnitPrice] = @UnitPrice
      ,[fromdate] = @fromdate
      ,[todate] = @todate
      ,[Active] = @Active
      --,[fromDate] = <fromDate, datetime,>
      --,[toDate] = <toDate, datetime,>
 WHERE Id = @Id

if @@ROWCOUNT = 0
begin
INSERT INTO [POSDashboard].[dbo].[LicensePricing]
           (
           [LicenseId]
           ,[TimePeriod]
           ,[MinTimePeriods]
           ,[UnitPrice]
           ,[fromdate]
           ,[todate]
           ,[Active]
           --,[fromDate]
          -- ,[toDate]
          )
     VALUES
           (

@LicenseId,
@TimePeriod,
@MinTimePeriods,
@UnitPrice,
@fromdate,
@todate,
@Active
--@fromDate,
--@toDate
)
end


end



/****** Object:  StoredProcedure [dbo].[Sp_InsTypeGroups]    Script Date: 05/04/2016 11:24:12 ******/
SET ANSI_NULLS ON

--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--ALTER procedure [dbo].[InsUpdDelLicensePricing](@Id int,
--@LicenseId int,
--@TimePeriod varchar(50),
--@MinTimePeriods int,
--@UnitPrice decimal(18,0),

--@fromdate datetime,
--@todate datetime,
--@Active int)

--as
--begin
--insert into LicensePricing values(
--@LicenseId,
--@TimePeriod,
--@MinTimePeriods,
--@UnitPrice,
--@Active,
--@fromdate,
--@todate,
--@Id
--)



--end

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[InsUpdDelLicenseDetails](
@Id int,
@LicenseCode varchar(10),
@LicenseName Varchar(50),
@LicenseCatId int,
@FeatureName varchar(50),
@FeatureLabel varchar(30),
@FeatureValue varchar(10),
@LabelClass varchar(50),
@Active int
)
--@fromDate datetime=getdate(),
--@toDate datetime=getdate())

as
begin

UPDATE [POSDashboard].[dbo].[LicenseDetails]
   SET [LicenseCode] = @LicenseCode
      ,[LicenseName] = @LicenseName
      ,[LicenseCatId] = @LicenseCatId
      ,[FeatureName] = @FeatureName
      ,[FeatureLabel] = @FeatureLabel
      ,[FeatureValue] = @FeatureValue
      ,[LabelClass] = @LabelClass
      ,[Active] = @Active
      --,[fromDate] = <fromDate, datetime,>
      --,[toDate] = <toDate, datetime,>
 WHERE Id = @Id

if @@ROWCOUNT = 0
begin
INSERT INTO [POSDashboard].[dbo].[LicenseDetails]
           ([LicenseCode]
           ,[LicenseName]
           ,[LicenseCatId]
           ,[FeatureName]
           ,[FeatureLabel]
           ,[FeatureValue]
           ,[LabelClass]
           ,[Active]
           --,[fromDate]
          -- ,[toDate]
          )
     VALUES
           (
@LicenseCode,
@LicenseName,
@LicenseCatId,
@FeatureName,
@FeatureLabel,
@FeatureValue,
@LabelClass,
@Active
--@fromDate,
--@toDate
)
end


end

Go

Create PROCEDURE [dbo].[VehicleConfiguration]	
	@needRoutes int =0,
	@needRoles int =0,		
	@needvehicleRegno int = 0,
	@needvehicleType int = 0,    
    @needServiceType int = 0,
    @needfleetowners int =0,
    @needCompanyName int = 0,
    @needVehicleLayout int = 0, 
    @needHireVehicle int =0,   
    @needbtpos int = 0,
    @cmpId int = -1,
    @fleetownerId int = -1
AS
BEGIN

	
	if @needRoutes  = 1
	select routename,ID,Code from routes	
	
	if @needRoles  = 1 
	select name,ID from Roles
	
	if @needvehicleRegno  = 1
    select VehicleRegNo,Id from FleetDetails
    where ((fleetownerid = @fleetownerId or @fleetownerid =-1)
    and (CompanyId = @cmpId or @cmpId = -1))
    
	--vehicle type data
	if @needvehicleType = 1
	select Name, Id from Types where TypeGroupId = 4
	
	--service type data
	if @needServiceType = 1
	select Name, Id from Types where TypeGroupId = 5
	
	--fleet owners
	if @needfleetowners = 1
	select u.FirstName+' '+u.LastName as Name,
	c.Name as CompanyName
	,FO.FleetOwnerCode
	,FO.CompanyId
	,U.Id
	 from FleetOwner FO
	inner join Users u on  u.Id = FO.UserId
	inner join Company c on c.Id = FO.companyId
    where (FO.companyId = @cmpId or @cmpId =-1)
	
	--companys
	if @needCompanyName = 1
	select Name,Id from Company
	
	--vehicle layout type
	if @needVehicleLayout = 1
	select Name, Id from Types where TypeGroupId = 6
	
	if @needbtpos = 1		
SELECT b.[Id]
      ,b.POSID            
      ,[IMEI]
      ,[ipconfig]
      ,b.[active]
      ,fleetownerid
  FROM [POSDashboard].[dbo].[BTPOSDetails] b
  where (fleetownerid = @fleetownerId or @fleetownerid =-1)

if @needHireVehicle = 1
select VehicleRegNo,Id from FleetDetails
    where ((fleetownerid = @fleetownerId or @fleetownerid =-1) 
    and (servicetypeId = 11))
	
END


--[VehicleConfiguration] 0,1,0,0,0,1,0,0,0,0,-1,0


GO

/****** Object:  StoredProcedure [dbo].[GetTypesByGroupId]    Script Date: 05/16/2016 14:56:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GetLicenseDetailsGrpid]
@LicenseDetailsid int = -1
AS
BEGIN
	
	SET NOCOUNT ON;

    
	SELECT L.Id,L.LicenseCatId,L.FeatureName,
	L.FeatureLabel,L.FeatureValue,L.Active, S.name as SubCategory
	From [LicenseDetails] L
	 inner join SubCategory S on S.Id = L.LicenseCatId	 
	  where (LicenseCatId = @LicenseDetailsid or @LicenseDetailsid = -1)
END

GO 

CREATE PROCEDURE [dbo].[GetFleetStaff]
	-- Add the parameters for the stored procedure here
	(@fleetowner int = -1, @cmpId int = -1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT fs.[Id]
      ,fs.[RoleId]
      ,[UserId]
      ,[FromDate]
      ,[ToDate]
      ,[VehicleId]
      ,FD.VehicleRegNo
      ,u.FirstName + ' ' +u.LastName as UserName
      ,r.Name as rolename
  FROM [POSDashboard].[dbo].[FleetStaff] FS
      inner join FleetDetails FD on FD.Id = FS.vehicleId
      inner join Users u on fs.UserId=u.id
inner join Roles r on r.Id = FS.roleid
where ((FD.FleetOwnerId = @fleetowner or @fleetowner = -1)
 and (FD.CompanyId = @cmpId or @cmpId  = -1))

END

GO 

CREATE PROCEDURE [dbo].[InsUpdDelFleetStaff]
@Id int = -1,
@RoleId int,
@UserId int,
@VehicleId int,
@cmpId int,
@FromDate datetime = null,
@ToDate datetime = null,
@insupddelflag varchar
as
begin

declare @cnt  int
set @cnt = -1

if @insupddelflag = 'I'

select @cnt = count(1) from [POSDashboard].[dbo].[FleetStaff] 
where vehicleid = @vehicleid 
and userid = @userid 
and companyid = @cmpid
and roleid = @roleid

if @cnt = 0 
begin
INSERT INTO [POSDashboard].[dbo].[FleetStaff]
           ([RoleId]
           ,[UserId]
           ,[FromDate]
           ,[ToDate]
           ,[VehicleId]
           ,[CompanyId])
     VALUES
           (@RoleId
           ,@UserId
           ,@FromDate
           ,@ToDate
           ,@VehicleId
           ,@cmpid)
end
else
  if @insupddelflag = 'U'

UPDATE [POSDashboard].[dbo].[FleetStaff]
   SET [RoleId] = @RoleId
      ,[UserId] = @UserId
      ,[FromDate] = @FromDate
      ,[ToDate] = @ToDate
      ,[VehicleId] = @VehicleId
      ,[CompanyId] = @cmpid
 WHERE Id = @Id

else
  delete from [POSDashboard].[dbo].[FleetStaff]
where vehicleid = @vehicleid 
and userid = @userid 
and companyid = @cmpid
and roleid = @roleid

End

GO
/****** Object:  StoredProcedure [dbo].[GetFleetDetails]    Script Date: 05/16/2016 16:59:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetFleebtDetails] 
	-- Add the parameters for the stored procedure here
	(@vehicleId int=-1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT vd.[Id]
      ,[RegNo]
      
      ,[POSID]
      ,[From]
      ,[To]
      ,vd.[Active]
     FROM [POSDashboard].[dbo].[FleetBtpos]fbt
    
  
    
    inner join VehicleDetails vd on vd.Id=fbt.Id
   
	 where  (vd.Id= @vehicleId or @vehicleId = -1)



END


GO
/****** Object:  StoredProcedure [dbo].[GetFleetDetails]    Script Date: 05/16/2016 16:59:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetFleetstDetails] 
	-- Add the parameters for the stored procedure here
	(@vehicleId int=-1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT vd.[Id]
      ,[RegNo]
      ,[UserId]
      ,[RoleId]
      ,[FromDate]
      ,[ToDate]
      
     ,vd.[Active]
     FROM [POSDashboard].[dbo].[FleetStaff]fs    
    inner join VehicleDetails vd on vd.Id=fs.Id   
	 where  (vd.Id= @vehicleId or @vehicleId = -1)



END
       
GO
/****** Object:  Table [dbo].[VehicleLayout]    Script Date: 05/21/2016 23:31:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VehicleLayout](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VehicleLayoutTypeId] [int] NOT NULL,
	[RowNo] [int] NOT NULL,
	[ColNo] [int] NOT NULL,
	[VehicleTypeId] [int] NOT NULL,
	[label] [varchar](10)  NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF   
    

	SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetUserRoles]	
(@companyId int = -1)
AS
BEGIN
	
SELECT distinct users.[Id]
      ,[FirstName]+ ' '+[LastName] username
      ,[RoleId]
      ,r.Name as rolename
      ,c.name as [companyname]
     ,c.Id as companyId
  FROM [POSDashboard].[dbo].[Users]  
  inner join userroles ur on ur.userid = users.id 
  inner join Roles r on r.Id = Ur.RoleId 
  inner join company c on c.id = ur.companyid
  where (c.id = @companyId or   @companyId = -1)    

END


GO

/****** Object:  Table [dbo].[LicenseTypes]    Script Date: 05/22/2016 06:52:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LicenseTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LicenseCatId] [int] NOT NULL,
	[LicenseType] [varchar](50)  NOT NULL,
	[Description] [varchar](500)  NULL,
	[Active] [int] NOT NULL CONSTRAINT [DF_LicenseTypes_Active]  DEFAULT ((1)),
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


Create PROCEDURE [dbo].[GetLicenseTypes]
(@licenseCategoryId int =-1)
AS
BEGIN
	SELECT lt.[Id]
      ,[LicenseCatId]
      ,[LicenseType]
      ,lt.[Description]
      ,t.name as licenseCategory
	  ,lt.[Active]
  FROM [POSDashboard].[dbo].[LicenseTypes] lt
inner join Types t on t.id = licensecatid
  where ([LicenseCatId] = @licenseCategoryId or @licenseCategoryId = -1)
END


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE InsUpdLicenseTypes 
(@Id int = -1
,@LicenseCatId int
,@LicenseType varchar(50)
,@Description varchar(500) = null
,@Active int = 1)	
AS
BEGIN
	UPDATE [POSDashboard].[dbo].[LicenseTypes]
   SET [LicenseCatId] = @LicenseCatId
      ,[LicenseType] = @LicenseType
      ,[Description] = @Description
      ,[Active] = @Active
	WHERE Id = @Id

if @@rowcount = 0

INSERT INTO [POSDashboard].[dbo].[LicenseTypes]
           ([LicenseCatId]
           ,[LicenseType]
           ,[Description]
           ,[Active])
     VALUES
           (@LicenseCatId
           ,@LicenseType
           ,@Description
           ,@Active)

END
GO

Create PROCEDURE [dbo].[InsUpdDelFleetRoutes]
@Id int = -1,
@VehicleId int,
@routeid int,
@FromDate datetime = null,
@ToDate datetime = null,
@insupddelflag varchar
as
begin

declare @cnt  int
set @cnt = -1

if @insupddelflag = 'I'

select @cnt = count(1) from [POSDashboard].[dbo].[FleetRoutes] 
where vehicleid = @vehicleid 
and routeid = @routeid

if @cnt = 0 
begin
INSERT INTO [POSDashboard].[dbo].[FleetRoutes]
           ([VehicleId]
           ,[RouteId]
           ,[EffectiveFrom]
           ,[EffectiveTill])
     VALUES
           (@vehicleid
           ,@routeid
           ,@FromDate
           ,@ToDate)
end
else
  if @insupddelflag = 'U'

UPDATE [POSDashboard].[dbo].[FleetRoutes]
   SET [RouteId] = @routeid      
      ,[EffectiveFrom] = @FromDate
      ,[EffectiveTill] = @ToDate      
 WHERE vehicleid = @vehicleid

else
  delete from [POSDashboard].[dbo].[FleetRoutes]
where vehicleid = @vehicleid and routeid = @routeid

End

GO

CREATE PROCEDURE [dbo].[InsUpdDelFleetBTPOS]
@Id int = -1,
@VehicleId int,
@btposId int,
@FromDate datetime = null,
@ToDate datetime = null,
@insupddelflag varchar
as
begin

declare @cnt  int
set @cnt = -1

if @insupddelflag = 'I'

select @cnt = count(1) from [POSDashboard].[dbo].[FleetBTPOS] 
where vehicleid = @vehicleid 
and  BTPOSId = @btposId

if @cnt = 0 
begin
INSERT INTO [POSDashboard].[dbo].[FleetBtpos]
           ([VehicleId]
           ,[FromDate]
           ,[ToDate]
           ,[BTPOSId])
     VALUES
           (@VehicleId
           ,@FromDate
           ,@ToDate
           ,@btposId)
end
else
  if @insupddelflag = 'U'

UPDATE [POSDashboard].[dbo].[FleetBtpos]
   SET [BTPOSId] = @btposId      
      ,[FromDate] = @FromDate
      ,[ToDate] = @ToDate
     WHERE [VehicleId] = @VehicleId
      
else
  delete from [POSDashboard].[dbo].[FleetBtpos]
where vehicleid = @vehicleid 
and [BTPOSId] = @btposId

End

GO
