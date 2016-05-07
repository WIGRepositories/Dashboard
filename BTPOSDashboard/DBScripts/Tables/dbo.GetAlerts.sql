USE [POSDashboard]
GO

/****** Object:  StoredProcedure [dbo].[Get Alerts]    Script Date: 04/28/2016 10:48:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[Get Alerts]
AS
BEGIN
	
select * from Alerts
end

GO


