

/****** Object:  StoredProcedure [dbo].[GetReceivingsMaster]    Script Date: 04/25/2016 15:47:06 ******/
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


