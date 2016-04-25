

/****** Object:  StoredProcedure [dbo].[getCompanies]    Script Date: 04/25/2016 15:20:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE procedure [dbo].[getCompanies]
(@userid int =-1)
as
begin
SELECT distinct c.[active]
      ,[code]
      ,[desc]
      ,c.[Id]
      ,[Name]
  FROM [POSDashboard].[dbo].[Company] c
  inner join Users u on  u.companyId = c.id
  where (u.id = @userid or @userid = -1)
  
end

--delete from CompanyGroups
--select * from company

--[getCompanies] 1
GO


