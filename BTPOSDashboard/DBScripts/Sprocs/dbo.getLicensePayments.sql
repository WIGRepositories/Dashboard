
/****** Object:  StoredProcedure [dbo].[getLicensePayments]    Script Date: 04/25/2016 15:27:28 ******/
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


