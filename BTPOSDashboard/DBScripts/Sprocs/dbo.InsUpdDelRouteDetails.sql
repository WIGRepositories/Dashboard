

/****** Object:  StoredProcedure [dbo].[InsUpdDelRouteDetails]    Script Date: 04/25/2016 15:30:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[InsUpdDelRouteDetails]    Script Date: 04/13/2016 11:13:24 ******/


CREATE procedure [dbo].[InsUpdDelRouteDetails](@Id int,@RouteId varchar(50),@stopname varchar(50),@Description varchar(50),@StopCode varchar(50),@DistanceFromSource int,@DistanceFromDestination int,@DistanceFromPreviousStop int,@DistanceFromNextStop int)
as
begin
insert into RouteDetails (RouteId,stopname,[Description],StopCode,DistanceFromSource,DistanceFromDestination,DistanceFromPreviousStop,DistanceFromNextStop) values(@RouteId,@stopname,@Description,@StopCode,@DistanceFromSource,@DistanceFromDestination,@DistanceFromPreviousStop,@DistanceFromNextStop)
end
select * from RouteDetails

GO


