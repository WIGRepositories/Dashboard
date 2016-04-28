USE [POSDashboard]
GO
/****** Object:  StoredProcedure [dbo].[InsUpdDelELBlockList]    Script Date: 04/28/2016 10:25:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE[dbo].[InsUpdDeLAlerts](@Id Numeric
,
           @Date varchar(50),
           @Message VARCHAR(50),
           @MessageType varchar(50),
           @MessageTypeId varchar(50),
           @Status varchar(50))
AS
BEGIN
	

INSERT INTO 
[Alerts] VALUES
           (@Id, 
          @Date,
           @Message,
           @MessageType,
           @MessageTypeId,
           @Status)
   
	END
