

/****** Object:  StoredProcedure [dbo].[GetBTPOSDetails]    Script Date: 04/25/2016 15:13:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetBTPOSDetails]
AS
BEGIN
	
SELECT b.[Id]
     -- ,[GroupId]
    --  ,c.Name as companyname
      ,[POSID]
      ,[StatusId]
      ,t.Name as [status]
      ,[IMEI]
      ,[ipconfig]
      ,b.[active]
      ,u.FirstName + ' '+ u.LastName as fleetowner
      ,u.Id as fleetownerid
  FROM [POSDashboard].[dbo].[BTPOSDetails] b
  left outer join Types t on t.Id = statusid
  --left outer join CompanyGroups c on c.Id = GroupId
  left outer join Users u on u.Id = FleetOwnerId
  
end

GO


