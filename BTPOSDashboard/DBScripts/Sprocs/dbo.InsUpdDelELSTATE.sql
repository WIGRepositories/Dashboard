

/****** Object:  StoredProcedure [dbo].[InsUpdDelELSTATE]    Script Date: 04/25/2016 15:42:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE[dbo].[InsUpdDelELSTATE](@Id NUMERIC(10),
           @Name VARCHAR(20),
           @Count VARCHAR(20),
           @Code VARCHAR(20),
           @Active varchar(20))
AS
BEGIN
	

INSERT INTO 
[STATE] VALUES
           (@ID,
           @Name,
           @Count,
           @Code,
           @Active)
	END

GO


