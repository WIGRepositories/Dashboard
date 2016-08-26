

/****** Object:  StoredProcedure [dbo].[InsUpdDelELregisterform]    Script Date: 04/25/2016 15:43:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[InsUpdDelELregisterform](@UserName varchar(max),
@Password varchar(max),@ConfirmPassword varchar(max),@Emailaddress varchar(max),
@FirstName varchar(max),@LastName varchar(max))
as
begin

INSERT INTO 
[register] VALUES
           (@UserName,
              
          
           @Password,
		     @ConfirmPassword,
			    @Emailaddress,
           @FirstName,
           @LastName
         
         )
   

end

GO


