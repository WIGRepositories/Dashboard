
/****** Object:  StoredProcedure [dbo].[InsUpdUsers]    Script Date: 04/25/2016 15:18:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[InsUpdUsers](
@FirstName varchar(40)
,@LastName varchar(40)
,@MiddleName varchar(40) = ''
,@UserTypeId int
,@EmpNo varchar(15)
,@Email varchar(40) = ''
,@AdressId int
,@MobileNo varchar(50) = ''
,@RoleId int
,@cmpId int
,@Active int
,@UserName varchar(30)  = ''
,@Password varchar(30)  = ''
,@insupdflag varchar(10)
,@userid int = -1)
 as begin
 
 declare @currid int
 declare @cnt int
 declare @logincnt int
 declare @ulogincnt int
 
 if @insupdflag = 'I'
 begin
 
 select @cnt = COUNT(*)  from Users where UPPER(EmpNo) = @EmpNo
 
 select @logincnt = COUNT(*) from userlogins where upper(logininfo) = UPPER(@username) 
 
 if @cnt > 0
 RAISERROR ('Already user exists',16,1);
 
  
 if @cnt = 0 
 begin
	insert into Users(FirstName,LastName,MiddleName, UserTypeId,EmpNo,Email,AddressId,MobileNo,[RoleId],Active,CompanyId)
	values(@FirstName,@LastName,@MiddleName, @UserTypeId,@EmpNo,@Email,@AdressId,@MobileNo,@RoleId,@Active,@cmpId) 
  
 
    SELECT @currid = @@IDENTITY
 end
  
  if @logincnt > 0
	RAISERROR ('Already user login exists',16,1);
 
   if @logincnt = 0 and @UserName is not null
   begin
	insert into userlogins(logininfo,PassKey,active,userid)values(@UserName,@Password,1,@currid)
   end
end
 else
 
 begin
 
 SELECT @currid = @userid
 
 update Users 
 set FirstName = @FirstName,
 LastName = @LastName,
 MiddleName = @MiddleName,
 Email = @Email,
 MobileNo = @MobileNo,
 RoleId = @RoleId,
 UserTypeId=@UserTypeId,
 Active = @Active 
 where id = @userid
 
 select @logincnt = COUNT(*) from userlogins where  userid = @userid
 
 
 if @logincnt = 0
  --login is not existing hence insert 
 if @UserName is not null
 insert into userlogins(logininfo,PassKey,active,userid)values(@UserName,@Password,1,@userid)
 
 else
 begin
 --check if updation causes duplicates
 select @ulogincnt = COUNT(*) from userlogins where upper(logininfo) = UPPER(@username) and userid <> @userid
 
 if @ulogincnt = 0
 	update userlogins
	set logininfo = @UserName
	,PassKey = @Password
	,active = @active
	where userid = @currid
else
 RAISERROR ('User login already exists',16,1);
 end

 
 end --end of 'i' check
 
 --if role is fleet owner then insert the code into fleet owner table
 
 declare @fcnt int
 
 if @RoleId = 2 
 begin
 
 select @fcnt = COUNT(*) from FleetOwner where UserId = @currid
 
			 if @fcnt = 0 
				INSERT INTO [POSDashboard].[dbo].[FleetOwner]
					   ([UserId]
					   ,[GroupId]
					   ,[Active]
					   ,[FleetOwnerCode])
				 VALUES
					   (@currid
					   ,1
					   ,1
					   ,@EmpNo)
				else
					UPDATE [POSDashboard].[dbo].[FleetOwner]
						SET 
						[GroupId] = 1
						,[Active] = 1
						,[FleetOwnerCode] = @EmpNo
					 WHERE [UserId] = @currid
 
 end
 
 
 end
 
--select * from FleetOwner

--select * from Roles

GO


