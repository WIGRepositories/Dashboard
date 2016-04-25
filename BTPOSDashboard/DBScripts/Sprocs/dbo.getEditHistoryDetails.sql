

/****** Object:  StoredProcedure [dbo].[getEditHistoryDetails]    Script Date: 04/25/2016 15:22:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[getEditHistoryDetails]
as
begin
select * from EditHistoryDetails
end

GO


