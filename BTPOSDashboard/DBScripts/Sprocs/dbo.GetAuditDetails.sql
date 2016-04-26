

/****** Object:  StoredProcedure [dbo].[GetAuditDetails]    Script Date: 04/25/2016 15:11:02 ******/
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


