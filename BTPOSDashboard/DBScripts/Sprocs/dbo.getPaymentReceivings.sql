

/****** Object:  StoredProcedure [dbo].[getPaymentReceivings]    Script Date: 04/25/2016 15:44:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[getPaymentReceivings]
as
begin
select * from PaymentReceivings
end

GO


