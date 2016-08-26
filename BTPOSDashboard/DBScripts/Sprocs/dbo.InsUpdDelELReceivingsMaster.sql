

/****** Object:  StoredProcedure [dbo].[InsUpdDelELReceivingsMaster]    Script Date: 04/25/2016 15:44:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE[dbo].[InsUpdDelELReceivingsMaster](@Id Numeric(20),
           @Date smalldatetime,
           @ReceivedFor varchar(20),
           @Desc varchar(20))
AS
BEGIN
	

INSERT INTO 
[ReceivingsMaster] VALUES
           (@Id, 
           @Date, 
           @ReceivedFor,
           @Desc)
   
	END

GO


