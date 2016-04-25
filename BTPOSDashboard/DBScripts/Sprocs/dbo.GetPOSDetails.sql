

/****** Object:  StoredProcedure [dbo].[GetPOSDetails]    Script Date: 04/25/2016 15:45:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetPOSDetails]
AS
BEGIN

SELECT t.[Id]
      ,[POSId]
      ,[Status]
      ,g.GroupName
      ,g.Id
      ,[Location]
  FROM [POSDashboard].[dbo].[POSTerminal] t
  inner join dbo.Groups g on g.Id = t.GroupId

END

GO


