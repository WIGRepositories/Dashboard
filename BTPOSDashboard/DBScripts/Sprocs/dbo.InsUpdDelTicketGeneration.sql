

/****** Object:  StoredProcedure [dbo].[InsUpdDelTicketGeneration]    Script Date: 04/25/2016 15:26:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[InsUpdDelTicketGeneration](@Source varchar(50),@Target varchar(50),@NoOfTickets int)
as
begin
insert into TicketGeneration values (@Source,@Target,@NoOfTickets)
end

GO


