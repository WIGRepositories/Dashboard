

/****** Object:  StoredProcedure [dbo].[InsUpdTypes]    Script Date: 04/25/2016 15:19:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[InsUpdTypes](@Id int,@Name varchar(50),@Description varchar(50) = null,@TypeGroupId varchar(50),@Active varchar(30))
as
begin

update types 
set name=@Name
,Active = @Active
,Description = @Description
,TypeGroupId = @TypeGroupId
where Id = @Id

if @@rowcount = 0 
begin
insert into Types(Name,[Description],TypeGroupId,Active) values(@Name,@Description,@TypeGroupId,@Active)
end

end

select * from types

GO


