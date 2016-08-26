

/****** Object:  StoredProcedure [dbo].[InsUpdDelTransactionDetails]    Script Date: 04/25/2016 15:26:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[InsUpdDelTransactionDetails](@Id int,@TransId varchar(50),@TotalAmt int,@PaymentId varchar(50),@BTPOSid varchar(50))
as
begin
insert into TransactionDetails values(@Id,@TransId,@TotalAmt,@PaymentId,@BTPOSid)
end

GO


