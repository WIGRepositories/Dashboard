

/****** Object:  StoredProcedure [dbo].[InsUpdDelELAlertsNotifications]    Script Date: 04/25/2016 16:07:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE[dbo].[InsUpdDelELAlertsNotifications]
@Id int

           
AS
BEGIN
	

Delete from AlertsNotifications where Id=@Id
   
	END

GO


