
/****** Object:  StoredProcedure [dbo].[GetBlockList]    Script Date: 04/25/2016 15:12:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetBlockList]
AS
BEGIN
	
select * from Blocklist
end

GO


