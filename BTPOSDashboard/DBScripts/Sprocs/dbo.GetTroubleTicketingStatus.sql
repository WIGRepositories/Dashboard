

/****** Object:  StoredProcedure [dbo].[GetTroubleTicketingStatus]    Script Date: 04/25/2016 16:01:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GetTroubleTicketingStatus]
AS
BEGIN
	
select * from TroubleTicketingStatus
end

GO


