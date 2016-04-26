

/****** Object:  StoredProcedure [dbo].[GetZipCode]    Script Date: 04/25/2016 16:03:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GetZipCode]
AS
BEGIN
	
select * from ZipCode
end

GO


