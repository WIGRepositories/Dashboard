

/****** Object:  StoredProcedure [dbo].[GetTroubleTicketingSlaType]    Script Date: 04/25/2016 16:00:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GetTroubleTicketingSlaType]
AS
BEGIN
	
select * from TroubleTicketingSlaType
end

GO


