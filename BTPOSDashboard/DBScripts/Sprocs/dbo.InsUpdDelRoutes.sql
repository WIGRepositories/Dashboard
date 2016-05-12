

/****** Object:  StoredProcedure [dbo].[InsUpdDelRoutes]    Script Date: 04/25/2016 15:28:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[InsUpdDelRoutes](
@Id int
,@RouteName varchar(50)
,@Description varchar(50) = null
,@Active int
,@Code varchar(10)
,@SourceId int
,@DestinationId int
,@Distance decimal
)
as
begin

UPDATE [POSDashboard].[dbo].[Routes]
   SET [RouteName] = @RouteName
      ,[Code] = @Code
      ,[Description] = @Description
      ,[Active] = @Active
      ,[SourceId] = @SourceId
      ,[DestinationId] = @DestinationId
      ,[Distance] = @Distance
 WHERE Id = @Id

if @@rowcount = 0 
begin

INSERT INTO [POSDashboard].[dbo].[Routes]
           ([RouteName]
           ,[Code]
           ,[Description]
           ,[Active]
           ,[SourceId]
           ,[DestinationId]
           ,[Distance])
     VALUES
           (@RouteName
           ,@Code
           ,@Description
           ,@Active
           ,@SourceId
           ,@DestinationId
           ,@Distance)


end

END

GO


