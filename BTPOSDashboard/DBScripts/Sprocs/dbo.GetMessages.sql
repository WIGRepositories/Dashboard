

/****** Object:  StoredProcedure [dbo].[GetMessages]    Script Date: 04/25/2016 15:29:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetMessages]
(@MessageType int)
  
AS
BEGIN

SELECT [Id]
      ,[Date]
      ,[Message]
      ,[MessageType]
  FROM [POSDashboard].[dbo].[AlertsNotifications]
  WHERE MessageType =@MessageType
 RETURN
END

GO


