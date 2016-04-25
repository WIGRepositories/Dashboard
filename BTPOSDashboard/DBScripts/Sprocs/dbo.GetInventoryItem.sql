

/****** Object:  StoredProcedure [dbo].[GetInventoryItem]    Script Date: 04/25/2016 15:24:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetInventoryItem]
as 
begin
SELECT I.[Id]
      ,[ItemName]
      ,[Code]
      ,I.[Description]
      ,[Category]
      ,[SubCategory]
      ,[ReOrderPoint]
  FROM [POSDashboard].[dbo].[InventoryItem]I

 INNER JOIN SubCategory s  ON s.Name = I.SubCategory
  
end

GO


