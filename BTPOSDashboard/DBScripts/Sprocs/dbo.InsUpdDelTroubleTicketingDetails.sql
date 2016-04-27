

/****** Object:  StoredProcedure [dbo].[InsUpdDelTroubleTicketingDetails]    Script Date: 04/25/2016 15:24:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[InsUpdDelTroubleTicketingDetails](@addInfo varchar(50),@createdBy varchar(50),@createdOn int,@Id int,@raisedBy varchar(50),@status int,@ticketinfo varchar(50),@ticketTypeId int,@TTId int)
as
begin
insert into TroubleTicketingDetails (addInfo,createdBy,createdOn,raisedBy,status,ticketinfo,ticketTypeId,TTId) values(@addInfo,@createdBy,@createdOn,@raisedBy,@status,@ticketinfo,@ticketTypeId,@TTId)
end

GO


