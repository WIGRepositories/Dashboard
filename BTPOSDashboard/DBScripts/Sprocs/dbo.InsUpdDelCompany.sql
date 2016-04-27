
/****** Object:  StoredProcedure [dbo].[InsUpdDelCompanyGroups]    Script Date: 04/25/2016 16:05:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[InsUpdDelCompany](
@active int,
@code varchar(50),
@desc varchar(50) = '',
@Id int,
@Name varchar(50),
@insupdflag varchar(10)
)
as
begin
declare @cnt int
set @cnt = 0

declare @newCmpId int
set @newCmpId = 0;



if @insupdflag = 'I'
	--check if already company exists
	select @cnt = count(1) from company where upper(name) = upper(@name)

	if @cnt = 0 
	begin
	insert into Company (active,code,[desc],Name) values(@active,@code,@desc,@Name)
	
	SELECT @newCmpId = @@IDENTITY

    --  --insert Fleet owner role by default
		--insert into CompanyRoles (Name,[Description],Active,companyid) 
		--values('Fleet Owner','Fleet owner role',1,@newCmpId)
   
	end

else

   if @insupdflag = 'U'

		--check if already a company with the new name exists
		select @cnt = count(1) from company where upper(name) = upper(@name) and id <> @id
	    
		if @cnt = 0 
		begin
		update Company
		set Name = @Name, code = @code, [desc] = @desc, active = @active
		where Id = @Id
		end
   else
     delete from Company where Id = @Id
end


GO


