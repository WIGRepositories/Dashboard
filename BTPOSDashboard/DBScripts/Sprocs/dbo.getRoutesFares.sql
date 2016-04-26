

/****** Object:  StoredProcedure [dbo].[getRoutesFares]    Script Date: 04/25/2016 15:52:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[getRoutesFares]
as
begin
select * from RoutesFares
end

GO


