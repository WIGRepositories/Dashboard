

/****** Object:  StoredProcedure [dbo].[getRouteFares]    Script Date: 04/25/2016 15:51:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[getRouteFares]
as
begin
select * from RouteFares
end

GO


