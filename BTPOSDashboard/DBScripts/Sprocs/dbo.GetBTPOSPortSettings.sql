
/****** Object:  StoredProcedure [dbo].[GetBTPOSPortSettings]    Script Date: 04/25/2016 15:15:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GetBTPOSPortSettings]
AS
BEGIN
	
select * from BTPOSPortSettings
end

GO


