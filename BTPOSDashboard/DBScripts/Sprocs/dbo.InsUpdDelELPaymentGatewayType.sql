

/****** Object:  StoredProcedure [dbo].[InsUpdDelELPaymentGatewayType]    Script Date: 04/25/2016 15:44:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE[dbo].[InsUpdDelELPaymentGatewayType](@Active NUMERIC(10),
              
           @Desc Varchar(30),
           
           @Id numeric(10),
           @PaymentGatewayType varchar(30),
           @TypeGripId numeric(20))
AS
BEGIN
	

INSERT INTO 
[PaymentGatewayType] VALUES
           (@Active,
              
          
           @Desc,
           @Id,
           @PaymentGatewayType,
           @TypeGripId )
   
	END

GO


