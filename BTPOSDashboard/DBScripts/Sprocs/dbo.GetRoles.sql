

/****** Object:  StoredProcedure [dbo].[GetRoles]    Script Date: 04/25/2016 15:50:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE  procedure [dbo].[GetRoles]
(@companyId int = -1)
as
begin
select Roles.Id, Roles.Name, Description, Roles.Active, companyid,c.Name Company
from Roles
inner join company c on c.id = roles.companyid
where (companyId = @companyId or @companyId = -1)
end



GO


