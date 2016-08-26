

/****** Object:  StoredProcedure [dbo].[GetSubCategories]    Script Date: 04/25/2016 15:56:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetSubCategories] 
(@catid int =-1)	
AS
BEGIN
	
	SELECT S.[Id]
      ,S.[Name]
      ,S.[Description]
      ,[CategoryId]
      ,t.NAME CATEGORY
      ,S.[Active]
  FROM [POSDashboard].[dbo].[SubCategory] S
  INNER JOIN Types T ON T.ID = S.CATEGORYID
  INNER JOIN TypeGroups TG ON TG.Id = T.TypeGroupId 
  where (S.CATEGORYID = @catid or @catid = -1)
   	
END

GO


