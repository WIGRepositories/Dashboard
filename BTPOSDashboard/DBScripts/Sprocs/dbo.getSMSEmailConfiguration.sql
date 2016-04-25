

/****** Object:  StoredProcedure [dbo].[getSMSEmailConfiguration]    Script Date: 04/25/2016 15:52:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[getSMSEmailConfiguration]
as
begin
select * from SMSEmailConfiguration
end

GO


