

/****** Object:  StoredProcedure [dbo].[InsUpdDelELBTPOSFaultsCatageries]    Script Date: 04/25/2016 16:08:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE[dbo].[InsUpdDelELBTPOSFaultsCatageries](@Active NUMERIC(10),
              
           @BTPOSFaultCategory Varchar(30),
           @Desc varchar(50),
           @Id numeric(10),
           @TypeGripId varchar(50))
AS
BEGIN
	

INSERT INTO 
[BTPOSFaultsCatageries] VALUES
           (@Active,
              
          @BTPOSFaultCategory,
           @Desc,
           @Id,
           @TypeGripId )
   
	END

GO


