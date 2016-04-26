

/****** Object:  StoredProcedure [dbo].[InsUpdDelRouteFares]    Script Date: 04/25/2016 15:29:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[InsUpdDelRouteFares](@active int,@fareCodeId int,@Id int,@routeId int)
as
begin
insert into RouteFares (active,fareCodeId,routeId) values(@active,@fareCodeId,@routeId)
end

GO


