

/****** Object:  StoredProcedure [dbo].[InsUpdDelSMSEmailSubscribers]    Script Date: 04/25/2016 15:27:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[InsUpdDelSMSEmailSubscribers](@AlertId int,@emailid varchar(50),@enddate datetime,@frequency int,@Id int,@phNo varchar(50),@startdate datetime,@userid int)
as
begin
insert into SMSEmailSubscribers values(@AlertId,@emailid,@enddate,@frequency,@Id,@phNo,@startdate,@userid)
end

GO


