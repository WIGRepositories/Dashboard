

/****** Object:  StoredProcedure [dbo].[GetSMSProviderConfig]    Script Date: 04/25/2016 15:53:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GetSMSProviderConfig]
AS
BEGIN
	
select * from SMSProviderConfig
end

GO


