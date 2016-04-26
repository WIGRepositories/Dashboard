

/****** Object:  StoredProcedure [dbo].[GetLicenceCatergories]    Script Date: 04/25/2016 15:26:39 ******/
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


