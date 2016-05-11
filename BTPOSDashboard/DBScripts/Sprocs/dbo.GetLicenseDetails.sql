

/****** Object:  StoredProcedure [dbo].[GetLicenseDetails]    Script Date: 05/11/2016 11:39:10 ******/
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


