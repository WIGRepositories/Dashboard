

/****** Object:  StoredProcedure [dbo].[GetBTPOSFaultsCatageries]    Script Date: 04/25/2016 15:14:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GetBTPOSFaultsCatageries]
AS
BEGIN
	
select * from BTPOSFaultsCatageries
end

GO


