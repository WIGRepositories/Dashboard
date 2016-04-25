
/****** Object:  StoredProcedure [dbo].[InsUpdDelELBTPOSRegistration]    Script Date: 04/25/2016 16:09:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE[dbo].[InsUpdDelELBTPOSRegistration](@Id NUMERIC(10),
              
           @POSID numeric(10),
           @Status VARCHAR(50),
           @FleetOwenerId numeric(10),
           @RegisteredOn Varchar(50),
           @IpConfig varchar(50),
           @RegStatus varchar(50),
           @LincenseNo varchar(50),
           @ActivedOn varchar(50),
           @ExpiryDate varchar(50))
AS
BEGIN
	

INSERT INTO 
[BTPOSRegistration] VALUES
           (@Id,
              
           @POSID,
           @Status,
           @FleetOwenerId,
           @RegisteredOn,
           @IpConfig,
           @RegStatus,
           @LincenseNo,
           @ActivedOn,
           @ExpiryDate )
   
	END

GO


