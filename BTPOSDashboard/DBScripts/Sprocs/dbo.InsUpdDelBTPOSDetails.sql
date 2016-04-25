

/****** Object:  StoredProcedure [dbo].[InsUpdDelBTPOSDetails]    Script Date: 04/25/2016 16:04:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE[dbo].[InsUpdDelBTPOSDetails](
		  @Id int,
           @GroupId int,   
           @POSID varchar(20),
           @StatusId int,
           @IMEI varchar(20),
           @ipconfig varchar(20),
           @active int = 1,
           @fleetownerid int,
           @insupdflag varchar(10)
           )
 
AS
BEGIN	
if @insupdflag = 'I' 
INSERT INTO [POSDashboard].[dbo].[BTPOSDetails]
           (
           [CompanyId]
           ,[POSID]
           ,[StatusId]
           ,[IMEI]
           ,[ipconfig]
           ,[active]
           ,[FleetOwnerId])
     VALUES
           --(--@GroupId
           --@POSID
           --,@StatusId
           --,@IMEI
           --,@ipconfig
           --,@active
           --,@FleetOwnerId)
             (1,
           @POSID
           ,1
           ,@IMEI
           ,@ipconfig
           ,1
           ,1)
else
  if @insupdflag = 'U' 
UPDATE [POSDashboard].[dbo].[BTPOSDetails]
   SET --[GroupId] = @GroupId
      [POSID] = @POSID
      ,[StatusId] = @StatusId
      ,[IMEI] = @IMEI
      ,[ipconfig] = @ipconfig
      ,[active] = @active
      ,[FleetOwnerId] = @fleetownerid
 WHERE Id = @Id
 
 else
   delete from BTPOSDetails where Id = @Id

END
select * from BTPOSDetails
GO


