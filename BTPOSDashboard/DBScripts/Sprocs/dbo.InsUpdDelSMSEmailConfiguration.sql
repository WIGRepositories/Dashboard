
/****** Object:  StoredProcedure [dbo].[InsUpdDelSMSEmailConfiguration]    Script Date: 04/25/2016 15:27:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[InsUpdDelSMSEmailConfiguration](@AlertTypeId int,@enddate datetime,@hashkey datetime,@Id int,@providername varchar(50),@pwd varchar(50),@saltkey datetime,@startdate datetime,@username varchar(50))
as
begin
insert into SMSEmailConfiguration values(@AlertTypeId,@enddate,@hashkey,@Id,@providername,@pwd,@saltkey,@startdate,@username)
end

GO


