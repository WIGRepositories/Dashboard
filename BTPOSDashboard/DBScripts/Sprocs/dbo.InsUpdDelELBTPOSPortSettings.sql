
/****** Object:  StoredProcedure [dbo].[InsUpdDelELBTPOSPortSettings]    Script Date: 04/25/2016 16:08:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE[dbo].[InsUpdDelELBTPOSPortSettings](@Id NUMERIC(10),
              
           @BTPOSId numeric(10),
           @Ipconfig varchar(50))
AS
BEGIN
	

INSERT INTO 
[BTPOSPortSettings] VALUES
           (@Id,
              
           @BTPOSId,
           @Ipconfig)
   
	END

GO


