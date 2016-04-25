

/****** Object:  StoredProcedure [dbo].[getTransactions]    Script Date: 04/25/2016 15:58:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[getTransactions]
as
begin
select * from Transactions
end

GO


