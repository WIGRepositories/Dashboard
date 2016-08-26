-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[InsupdCreateFleetOwner]
	-- Add the parameters for the stored procedure here
	(@Id int,
           @FirstName varchar(30),
           @LastName varchar(30)
           ,@Email varchar(30)
           ,@MobileNo varchar(30)
           ,@CompanyName varchar(30)
           ,@Description varchar(30) = null,
           @insupdflag varchar(10),@CompanyGroupId int=-1)
           
AS 
BEGIN
declare @currid int
 declare @cnt int 
set @cnt = 0
declare @cmpcnt int
set @cmpcnt = 0
 declare @fleetcnt int
set @fleetcnt = 0

declare @cmpid int
set @cmpid = 0
 
 declare @fc varchar(10) 
 set @fc = case when (select COUNT(*) from Users) = 0
                           then '001' 
                           else (select ltrim(rtrim(STR((max(Id)+1)))) from Users ) 
                           end  
 
 
 select @cnt=COUNT (*) from Users where FirstName=@FirstName
 select @cmpcnt=COUNT (*) from Company where UPPER (Name)=@CompanyName
 select @fleetcnt=COUNT (*) from FleetOwner where UPPER (FleetOwnerCode)=@fc

 	
 if @cmpcnt=0
 begin
  insert into Company 
           ([Name]
           ,[Code]
           ,[Desc]
           ,[Active])      
     VALUES
           (@CompanyName,@CompanyName,@Description,1)
           
           SELECT @cmpid = @@IDENTITY
 end
 else
 begin  
   SELECT @cmpid = Id from Company where UPPER (Name)=@CompanyName
   
 end
   
 
 
 if @insupdflag='I' and @cnt>0
 begin
 RAISERROR ('Already user exists',16,1);
 end
 
 if @cnt=0
 begin
 
   insert into Users (FirstName,
   LastName,MiddleName, UserTypeId,EmpNo,Email,AddressId,MobileNo,[RoleId],Active,CompanyId)
   values(@FirstName,@LastName,null,1,'FL00'+@fc,@Email,null,@MobileNo,6,1,@cmpid) 
          
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	
	
	SELECT @currid = @@IDENTITY
end

	

   
   --insert company role for company and fleet owner role
  exec  InsUpdDelCompanyRoles 1,-1,@cmpid,2 
                 
 if @insupdflag='I'and @fleetcnt>0
 begin
	RAISERROR ('Already FleetOwner exists',16,1);
 end
 
 if @fleetcnt=0
 begin
	insert into FleetOwner (UserId,GroupId,FleetOwnerCode,Active) values(@currid,'','FL00'+@fc,1)
 end

--assign fleet owner role to user
exec [InsUpdDelUserRoles] -1,2,@currid,@cmpid
end


GO


