

/****** Object:  StoredProcedure [dbo].[getSMSEmailSubscribers]    Script Date: 04/25/2016 15:53:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[getSMSEmailSubscribers]
as
begin
select * from SMSEmailSubscribers
end

GO


