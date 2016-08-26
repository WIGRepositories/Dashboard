

/****** Object:  StoredProcedure [dbo].[GetNotifications]    Script Date: 04/28/2016 10:48:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetNotifications]
AS
BEGIN
	
select * from Notifications
end

GO


