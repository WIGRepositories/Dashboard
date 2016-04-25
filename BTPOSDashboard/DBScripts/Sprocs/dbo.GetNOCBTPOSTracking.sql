

/****** Object:  StoredProcedure [dbo].[GetNOCBTPOSTracking]    Script Date: 04/25/2016 15:40:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GetNOCBTPOSTracking]
AS
BEGIN
	
select * from NOCBTPOSTracking
end

GO


