

/****** Object:  StoredProcedure [dbo].[GetBTPOSAuditDetails]    Script Date: 04/25/2016 15:13:04 ******/
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


