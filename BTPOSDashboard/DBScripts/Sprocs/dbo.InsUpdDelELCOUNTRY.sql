
/****** Object:  StoredProcedure [dbo].[InsUpdDelELCOUNTRY]    Script Date: 04/25/2016 16:11:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE[dbo].[InsUpdDelELCOUNTRY](@Id NUMERIC(10),
           @Name VARCHAR(50),   
           @Code VARCHAR(50),
           @Active VARCHAR(50))
AS
BEGIN
	

INSERT INTO 
[COUNTRY] VALUES
           (@Id,
           @Name,
           @Code
           ,@Active)
   
	END

GO


