

/****** Object:  StoredProcedure [dbo].[getFleetOwner]    Script Date: 04/25/2016 15:23:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[getFleetOwner]
as
begin
select * from FleetOwner
end

GO


