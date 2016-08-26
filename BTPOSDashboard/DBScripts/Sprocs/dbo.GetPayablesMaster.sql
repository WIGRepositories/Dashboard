

/****** Object:  StoredProcedure [dbo].[GetPayablesMaster]    Script Date: 04/25/2016 15:42:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetPayablesMaster]
AS
BEGIN
	
select * from PayablesMaster
end

GO


