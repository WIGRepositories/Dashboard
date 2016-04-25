

/****** Object:  StoredProcedure [dbo].[GetPayables]    Script Date: 04/25/2016 15:42:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetPayables]
AS
BEGIN
	
select * from Payables
end

GO


