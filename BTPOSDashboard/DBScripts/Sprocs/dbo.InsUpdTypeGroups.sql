

/****** Object:  StoredProcedure [dbo].[InsUpdTypeGroups]    Script Date: 04/25/2016 15:19:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[InsUpdTypeGroups](@Id int,@Name varchar(50)
,@Description varchar(50) = null,@Active int)
as
begin

update typegroups 
set name=@Name
,Active = @Active
,Description = @Description
where Id = @Id

if @@rowcount = 0 
begin
insert into TypeGroups (Name,[Description],Active) values(@Name,@Description,@Active)
end

end

GO


