

/****** Object:  StoredProcedure [dbo].[InsUpdDelELPayablesMaster]    Script Date: 04/25/2016 16:13:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE[dbo].[InsUpdDelELPayablesMaster](@Id numeric,
           @Date smalldatetime,
           @PaidFor VARCHAR,
           @Desc VARCHAR)
AS
BEGIN
	

INSERT INTO 
[PayablesMaster] VALUES
           (@Id
           ,@Date
           ,@PaidFor
           ,@Desc)
   
	END

GO


