

/****** Object:  StoredProcedure [dbo].[GetReceivings]    Script Date: 04/25/2016 15:46:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetReceivings]
AS
BEGIN
	
select * from Receivings
end

GO


