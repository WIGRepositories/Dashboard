

/****** Object:  StoredProcedure [dbo].[getPayments]    Script Date: 04/25/2016 15:44:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[getPayments]
as
begin
select * from Payment
end

GO


