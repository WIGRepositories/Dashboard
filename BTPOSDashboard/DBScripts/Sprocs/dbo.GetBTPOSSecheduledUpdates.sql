

/****** Object:  StoredProcedure [dbo].[GetBTPOSSecheduledUpdates]    Script Date: 04/25/2016 15:17:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GetBTPOSSecheduledUpdates]
AS
BEGIN
	
select * from BTPOSSecheduledUpdates
end

GO


