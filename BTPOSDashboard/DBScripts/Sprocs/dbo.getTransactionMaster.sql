

/****** Object:  StoredProcedure [dbo].[getTransactionMaster]    Script Date: 04/25/2016 15:57:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[getTransactionMaster]
as
begin
select * from TransactionMaster
end

GO


