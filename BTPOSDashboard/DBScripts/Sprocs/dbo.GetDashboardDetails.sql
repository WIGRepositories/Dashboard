

/****** Object:  StoredProcedure [dbo].[GetDashboardDetails]    Script Date: 04/25/2016 15:21:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetDashboardDetails]
as
begin
--
--select p.Id ,Name as GroupName, POSId, IMEI 
--from BTPOSDetails p
--inner join CompanyGroups c on c.Id = p.GroupId

select * from CompanyGroups

select * from Users
end

GO


