

/****** Object:  StoredProcedure [dbo].[getPaymentGatewaySettings]    Script Date: 04/25/2016 15:43:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[getPaymentGatewaySettings]
as
begin
select * from PaymentGatewaySettings
end

GO


