USE [POSDashboard]
GO

/****** Object:  StoredProcedure [dbo].[InsUpdDelTypes]    Script Date: 04/25/2016 15:22:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[InsUpdDelTypes](@Id int,@Name varchar(50),@Description varchar(50),@TypeGroupId int,@Active varchar(50))
as
begin
insert into [Types] (Name,[Description],TypeGroupId,Active) values (@Name,@Description,@TypeGroupId,@Active)
end

GO


