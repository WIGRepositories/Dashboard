

/****** Object:  StoredProcedure [dbo].[GetBTPOSRegistration]    Script Date: 04/25/2016 15:16:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GetBTPOSRegistration]
AS
BEGIN
	
select * from BTPOSRegistration
end

GO


