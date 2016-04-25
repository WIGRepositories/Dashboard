

/****** Object:  StoredProcedure [dbo].[getTransactionDetails]    Script Date: 04/25/2016 15:57:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[getTransactionDetails]
as
begin
select * from TransactionDetails
end

GO


