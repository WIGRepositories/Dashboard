

/****** Object:  StoredProcedure [dbo].[GetUsers]    Script Date: 04/25/2016 16:02:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetUsers]
(@cmpId int = -1)
AS
BEGIN

SELECT users.[Id]
      ,[FirstName]
      ,[LastName]
      ,[UserTypeId]
      ,[EmpNo]
      ,[Email]
      ,[AddressId]
      ,[MobileNo]
      ,[RoleId]
      ,users.[Active]
      ,[MiddleName]
      ,ul.logininfo as UserName
      ,ul.passkey as [Password]
      ,t.Name as UserType
      ,r.Name as [Role]
      ,c.name as [Company]
  FROM [POSDashboard].[dbo].[Users] 
  inner join company c on (users.companyid = c.id)
  left outer join dbo.userlogins ul on ul.userid = Users.id
  left outer join Roles r on r.Id = Users.RoleId
  left outer join Types t on t.Id = Users.UserTypeId
  where  (c.Id= @cmpid or @cmpid = -1)
end


GO


