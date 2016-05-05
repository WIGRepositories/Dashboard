USE [POSDashboard]
GO

/****** Object:  StoredProcedure [dbo].[Get Notifications]    Script Date: 04/28/2016 10:48:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Get Notifications]
AS
BEGIN
	
select * from Notifications
end

GO


