

/****** Object:  StoredProcedure [dbo].[GetPaymentCatergory]    Script Date: 04/25/2016 15:42:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GetPaymentCatergory]
AS
BEGIN
	
select * from PaymentCatergory
end

GO


