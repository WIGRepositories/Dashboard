

/****** Object:  StoredProcedure [dbo].[InsUpdDelRoles]    Script Date: 04/25/2016 15:31:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[InsUpdDelRoles](@Id int,@Name varchar(50)
,@Description varchar(50) = null,@Active varchar(50)
,@companyId int)
as
begin

update roles 
set Name = @name,
Description = @Description,
CompanyId = @companyId
where id = @Id

if @@rowcount = 0
begin
insert into Roles (Name,[Description],Active,companyid) 
values(@Name,@Description,@Active,@companyId)
end

end

GO


