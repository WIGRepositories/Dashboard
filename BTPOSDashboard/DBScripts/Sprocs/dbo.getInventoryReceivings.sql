

/****** Object:  StoredProcedure [dbo].[getInventoryReceivings]    Script Date: 04/25/2016 15:25:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[getInventoryReceivings]
as
begin
select * from InventoryReceivings
end

GO


