

/****** Object:  StoredProcedure [dbo].[GetStops]    Script Date: 04/25/2016 15:55:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetStops]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Code]
      ,[Active]
  FROM [POSDashboard].[dbo].[Stops]




END

GO


