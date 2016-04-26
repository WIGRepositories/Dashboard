

/****** Object:  StoredProcedure [dbo].[InsUpdDelEditHistory]    Script Date: 04/25/2016 16:06:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[InsUpdDelEditHistory](@Field varchar(50),@SubItem varchar(50),@Comment varchar(50),@Date datetime,@ChangedBy varchar(50),@ChangedType varchar(50))
as
begin
insert into EditHistory values(@Field,@SubItem,@Comment,@Date,@ChangedBy,@ChangedType)
end

GO


