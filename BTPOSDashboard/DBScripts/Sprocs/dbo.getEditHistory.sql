

/****** Object:  StoredProcedure [dbo].[getEditHistory]    Script Date: 04/25/2016 15:21:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[getEditHistory]
as
begin
select * from EditHistory
end

GO


