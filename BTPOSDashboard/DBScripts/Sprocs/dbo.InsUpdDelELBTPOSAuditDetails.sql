

/****** Object:  StoredProcedure [dbo].[InsUpdDelELBTPOSAuditDetails]    Script Date: 04/25/2016 16:08:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE[dbo].[InsUpdDelELBTPOSAuditDetails](@BTPOSId NUMERIC(10),
              
           @EditHistoryId numeric(10))
AS
BEGIN
	

INSERT INTO 
[BTPOSAuditDetails] VALUES
           (@BTPOSId,
              
           @EditHistoryId)
   
	END

GO


