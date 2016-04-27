

/****** Object:  StoredProcedure [dbo].[InsUpdelStops]    Script Date: 04/25/2016 15:21:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsUpdelStops]
	-- Add the parameters for the stored procedure here
(@Id int,
      @Name varchar(30),
      @Description varchar(30),
      @Code varchar(10),
      @Active int,
      @insupdflag varchar(10))
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	if @insupdflag='I'
INSERT INTO Stops
           (Name,
           [Description],
           Code,
           Active)
           values(@Name,
           @Description,
           @Code,
           @Active)
     
else

  if @insupdflag = 'U'
UPDATE Stops
   SET Name = @Name ,
      [Description] = @Description  ,
      Code = @Code ,
      Active = @Active 
 WHERE id=@id

else
  delete from stops where id = @id

END

GO


