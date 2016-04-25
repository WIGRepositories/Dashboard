

/****** Object:  StoredProcedure [dbo].[InsUpdDelObjects]    Script Date: 04/25/2016 15:35:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[InsUpdDelObjects](@Id int,
@Name varchar(50),
@Description varchar(100) = '',
@Path Varchar(500),
@Active int = 1)
as
begin
insert into Object (Name,Description,Path ,Active) values(@Name,@Description, @Path, @Active)
end

GO


