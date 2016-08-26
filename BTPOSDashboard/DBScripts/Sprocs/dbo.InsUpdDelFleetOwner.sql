

/****** Object:  StoredProcedure [dbo].[InsUpdDelFleetOwner]    Script Date: 04/25/2016 15:39:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[InsUpdDelFleetOwner](@Id int,@UserId varchar(50),@BTPOSgroupid varchar(50),@Active varchar(50))
as
begin
insert into FleetOwner values(@Id,@UserId,@BTPOSgroupid,@Active)
end

GO


