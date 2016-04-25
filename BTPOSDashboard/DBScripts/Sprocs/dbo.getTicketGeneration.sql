

/****** Object:  StoredProcedure [dbo].[getTicketGeneration]    Script Date: 04/25/2016 15:57:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[getTicketGeneration]
as
begin
select * from TicketGeneration
end

GO


