
/****** Object:  StoredProcedure [dbo].[GetLicenceStatus]    Script Date: 04/25/2016 15:27:03 ******/
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


