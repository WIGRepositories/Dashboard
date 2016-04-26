

/****** Object:  StoredProcedure [dbo].[getExpenses]    Script Date: 04/25/2016 15:22:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[getExpenses]
as
begin
select * from Expenses
end

GO


