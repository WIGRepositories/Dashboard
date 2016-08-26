

/****** Object:  StoredProcedure [dbo].[GetUsertypeId]    Script Date: 04/25/2016 16:02:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[GetUsertypeId] (@UserTypeId int=-1)
as begin 
select * from Users
where UserTypeId=@UserTypeId or @UserTypeId=-1
end

GO


