

/****** Object:  StoredProcedure [dbo].[getTransactionTypes]    Script Date: 04/25/2016 15:58:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[getTransactionTypes]
as
begin
select * from TransactionTypes
end

GO


