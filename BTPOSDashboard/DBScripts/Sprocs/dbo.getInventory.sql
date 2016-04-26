

/****** Object:  StoredProcedure [dbo].[getInventory]    Script Date: 04/25/2016 15:24:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[getInventory]
as
begin
select * from Inventory
end

GO


