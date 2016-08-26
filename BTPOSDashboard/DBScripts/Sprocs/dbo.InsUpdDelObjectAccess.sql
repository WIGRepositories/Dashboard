

/****** Object:  StoredProcedure [dbo].[InsUpdDelObjectAccess]    Script Date: 04/25/2016 15:35:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[InsUpdDelObjectAccess](@Id int,
@ObjectId int,
@AccessId int,@Name varchar(50))

as
begin
insert into ObjectAccess (ObjectId,AccessId,Name) values(@ObjectId,@AccessId,@Name)
end

GO


