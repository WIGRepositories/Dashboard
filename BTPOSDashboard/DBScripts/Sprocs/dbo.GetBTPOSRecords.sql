

/****** Object:  StoredProcedure [dbo].[GetBTPOSRecords]    Script Date: 04/25/2016 15:15:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GetBTPOSRecords]
AS
BEGIN
	
select * from  BTPOSRecords
end

GO


