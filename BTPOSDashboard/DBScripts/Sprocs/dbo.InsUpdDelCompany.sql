set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

/****** Object:  StoredProcedure [dbo].[InsUpdDelCompany]    Script Date: 05/04/2016 17:22:18 ******/

CREATE procedure [dbo].[InsUpdDelCompany](
@active int,
@code varchar(50),
@desc varchar(50) = '',
@Id int,
@Name varchar(50),
@insupdflag varchar(10),
@userid int = -1
)
as
begin
declare @cnt int
declare @edithistoryid int
set @cnt = 0

declare @newCmpId int
set @newCmpId = 0;

declare @dt datetime
set @dt = GETDATE()

declare @neweid int



if @insupdflag = 'I'
begin
	--check if already company exists
	select @cnt = count(1) from company where upper(name) = upper(@name)

	if @cnt = 0 
	begin
		
	insert into Company (active,code,[desc],Name) values(@active,@code,@desc,@Name)
	
	SELECT @newCmpId = @@IDENTITY
	
	--insert into edit history
	exec InsEditHistory 'Company', 'Name',@Name,'Company creation',@dt,'Admin','Insertion',@edithistoryid
           
           set @neweid =  @edithistoryid
           
    --exec InsEditHistoryDetails @neweid,null,@Name,'Insertion','Name',null
    --exec InsEditHistoryDetails @edithistoryid,null,@code,'Insertion','Code',null
    --exec InsEditHistoryDetails @edithistoryid,null,@desc,'Insertion','Desc',null
    --exec InsEditHistoryDetails @edithistoryid,null,@active,'Insertion','Active',null

  --  --insert Fleet owner role by default
		--insert into CompanyRoles (Name,[Description],Active,companyid) 
		--values('Fleet Owner','Fleet owner role',1,@newCmpId)
   
	end
end	
	else
begin
	
   if @insupdflag = 'U'
     begin
		--check if already a company with the new name exists
		select @cnt = count(1) from company where upper(name) = upper(@name) and id <> @id
	    
		if @cnt = 0 
		begin
		update Company
		set Name = @Name, code = @code, [desc] = @desc, active = @active
		where Id = @Id
		
		
		--insert into edit history
	exec InsEditHistory 'Company', 'Name',@Name,'Company creation',@dt,'Admin','Modification',@edithistoryid
           
           set @neweid =  @edithistoryid
           
    --exec InsEditHistoryDetails @neweid,null,@Name,'Insertion','Name',null
    --exec InsEditHistoryDetails @edithistoryid,null,@code,'Insertion','Code',null
    --exec InsEditHistoryDetails @edithistoryid,null,@desc,'Insertion','Desc',null
    --exec InsEditHistoryDetails @edithistoryid,null,@active,'Insertion','Active',null
		
		end
	end

else
     delete from Company where Id = @Id



end

end
