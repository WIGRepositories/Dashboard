

/****** Object:  StoredProcedure [dbo].[GetLicensePricing]    Script Date: 05/11/2016 11:40:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetLicensePricing]

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
GO


