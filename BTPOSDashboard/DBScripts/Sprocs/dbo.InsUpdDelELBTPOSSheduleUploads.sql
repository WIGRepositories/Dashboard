
/****** Object:  StoredProcedure [dbo].[InsUpdDelELBTPOSSheduleUploads]    Script Date: 04/25/2016 16:10:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE[dbo].[InsUpdDelELBTPOSSheduleUploads](@Id NUMERIC(10),
              
           @POSID numeric(10),
           @UploadOn varchar(50),
           @UploadedOn varchar(50),
           @Status varchar(50),
           @UploadData varchar(50),
           @Ipconfig varchar(50))
AS
BEGIN
	

INSERT INTO 
[BTPOSSheduleUploads] VALUES
           (@Id,
              
           @POSID,
           @UploadOn,
           @UploadedOn,
           @Status,
           @UploadData,
           @Ipconfig )
   
	END

GO


