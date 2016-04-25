

/****** Object:  StoredProcedure [dbo].[InsUpdDelELBTPOSRecords]    Script Date: 04/25/2016 16:09:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE[dbo].[InsUpdDelELBTPOSRecords](@Id NUMERIC(10),
              
           @BTPOSID numeric(10),
           @IpConfig varchar(50),
           @RecordData varchar(50))
AS
BEGIN
	

INSERT INTO 
[BTPOSRecords] VALUES
           (@Id,
              
           @BTPOSID,
           @Ipconfig,
           @RecordData)
   
	END

GO


