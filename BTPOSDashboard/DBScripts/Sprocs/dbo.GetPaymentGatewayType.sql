

/****** Object:  StoredProcedure [dbo].[GetPaymentGatewayType]    Script Date: 04/25/2016 15:44:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GetPaymentGatewayType]
AS
BEGIN
	
select * from PaymentGatewayType
end

GO


