

/****** Object:  StoredProcedure [dbo].[GetInventorySales]    Script Date: 04/25/2016 15:25:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetInventorySales]
As
BEGIN
SELECT [Id]
      ,[ItemName]
      ,[Quantity]
      ,[PerUnitPrice]
      ,[PurchaseDate]
      ,[InVoiceNumber]
  FROM [POSDashboard].[dbo].[InventorySales]



	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	
END


GO


