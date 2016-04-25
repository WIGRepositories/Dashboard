

/****** Object:  StoredProcedure [dbo].[getTroubleTicketingCategories]    Script Date: 04/25/2016 15:59:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[getTroubleTicketingCategories]
as
begin
select * from TroubleTicketingCategories
end

GO


