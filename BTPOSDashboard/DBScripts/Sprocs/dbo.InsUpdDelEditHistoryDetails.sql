

/****** Object:  StoredProcedure [dbo].[InsUpdDelEditHistoryDetails]    Script Date: 04/25/2016 16:06:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[InsUpdDelEditHistoryDetails](@EditHistoryId int,@FromValue varchar(50),@ToValue varchar(50),@ChangeType varchar(50),@Field1 varchar(50),@Field2 varchar(50))
as
begin
insert into EditHistoryDetails values(@EditHistoryId,@FromValue,@ToValue,@ChangeType,@Field1,@Field2)
end

GO


