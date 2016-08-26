

/****** Object:  StoredProcedure [dbo].[GetRoleObjectAccesses]    Script Date: 04/25/2016 15:49:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetRoleObjectAccesses] 	
@roleid int = -1
AS
BEGIN
	select t.name,t.ID accessid, o.Name  as objname, r.Name as rolename from Types t
inner join RoleObjectAccesses roa on roa.AccessId = t.Id
inner join Objects o on o.Id = roa.ObjectId
inner join Roles r on r.Id = roa.RoleId
where r.Id = @roleid or @roleid = -1

END

GO


