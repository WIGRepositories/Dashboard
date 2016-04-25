

/****** Object:  StoredProcedure [dbo].[getRouteDetails]    Script Date: 04/25/2016 15:50:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[getRouteDetails]
as
begin
SELECT [Id]
      ,[RouteId]
      ,[stopname]
      ,[Description]
      ,[StopCode]
      ,[DistanceFromSource]
      ,[DistanceFromDestination]
      ,[DistanceFromPreviousStop]
      ,[DistanceFromNextStop]
  FROM [POSDashboard].[dbo].[RouteDetails]
end

GO


