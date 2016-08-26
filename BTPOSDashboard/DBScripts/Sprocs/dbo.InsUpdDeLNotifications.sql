

/****** Object:  StoredProcedure [dbo].[InsUpdDLNotifications]    Script Date: 04/28/2016 10:44:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE[dbo].[InsUpdDLNotifications](@Id Numeric
,
           @Date varchar(50),
           @Message VARCHAR(50),
           @MessageType varchar(50),
           @MessageTypeId varchar(50),
           @Status varchar(50))
AS
BEGIN
	

INSERT INTO 
[Notifications] VALUES
           (@Id, 
          @Date,
           @Message,
           @MessageType,
           @MessageTypeId,
           @Status)
   
	END

GO


