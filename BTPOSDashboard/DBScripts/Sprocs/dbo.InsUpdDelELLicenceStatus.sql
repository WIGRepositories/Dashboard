
/****** Object:  StoredProcedure [dbo].[InsUpdDelELLicenceStatus]    Script Date: 04/25/2016 16:11:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE[dbo].[InsUpdDelELLicenceStatus](@Active NUMERIC(10),
              
           @Desc Varchar(30),
           
           @Id numeric(10),
           @LicenseStatusType varchar(30),
           @TypeGripId varchar(50))
AS
BEGIN
	

INSERT INTO 
[LicenceStatus] VALUES
           (@Active,
           @Desc,
           @Id,
           @LicenseStatusType,
           @TypeGripId )
   
	END

GO


