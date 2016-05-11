

/****** Object:  StoredProcedure [dbo].[InsUpdDelLicensePricing]    Script Date: 05/11/2016 16:13:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[InsUpdDelLicensePricing](
@Id int,
@LicenseId int,
@TimePeriod Varchar(50),
@MinTimePeriods int,
@UnitPrice decimal(18,0),
--@fromdate datetime,
--@todate datetime,

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
      --,[fromdate] = @fromdate
      --,[todate] = @todate
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
           --,[fromdate]
           --,[todate]
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
--@fromdate,
--@todate,
@Active
--@fromDate,
--@toDate
)
end


end



/****** Object:  StoredProcedure [dbo].[Sp_InsTypeGroups]    Script Date: 05/04/2016 11:24:12 ******/
SET ANSI_NULLS ON
select * from LicenseDetails
GO


