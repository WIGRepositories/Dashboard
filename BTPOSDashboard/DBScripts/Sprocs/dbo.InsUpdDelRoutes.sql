

/****** Object:  StoredProcedure [dbo].[InsUpdDelRoutes]    Script Date: 04/25/2016 15:28:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[InsUpdDelRoutes](@Id int,@Route varchar(50),@Description varchar(50),@Active varchar(50),@Code varchar(50),@BTPOSGroupId varchar(50),@Source varchar(50),@Destination varchar(50))
as
begin
insert into Routes ([Route],[Description],Active,Code,BTPOSGroupId,Source,Destination) values(@Route,@Description,@Active,@Code,@BTPOSGroupId,@Source,@Destination)
end

GO


