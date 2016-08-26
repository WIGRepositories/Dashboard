

/****** Object:  StoredProcedure [dbo].[InsUpdDelVehicleDetails]    Script Date: 04/25/2016 15:22:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsUpdDelVehicleDetails](
	@busId money,
	@busTypeId int,
	@conductorId int,
	@conductorName varchar(50),
	@driverId int,
	@driverName varchar(50),
	@fleetOwnerId int,
	@CompanyName varchar(50),
	@Id int,
	@POSID int,
	@RegNo varchar(50),
	@route varchar(50),
	@Status varchar(50),
	@statusid int,
	@Active int = 1,
	 @insupdflag varchar(10)
)
AS
BEGIN
if @insupdflag = 'I'
INSERT INTO [POSDashboard].[dbo].[VehicleDetails]
           ([busId]
           ,[busTypeId]
           ,[conductorId]
           ,[conductorName]
           ,[driverId]
           ,[driverName]
           ,[fleetOwnerId]
           ,[CompanyName]
           ,[POSID]
           ,[RegNo]
           ,[route]
           ,[Status]
           ,[statusid]
           ,[Active])
     VALUES
           (@busId
           ,@busTypeId
           ,@conductorId
           ,@conductorName
           ,@driverId
           ,@driverName
           ,@fleetOwnerId
           ,@CompanyName
           ,@POSID
           ,@RegNo
           ,@route
           ,@Status
           ,@statusid
           ,@Active
  )         
else
 if @insupdflag = 'U' 
 UPDATE [POSDashboard].[dbo].[VehicleDetails]
   SET [busId] = @busId
      ,[busTypeId] = @busTypeId
      ,[conductorId] = @conductorId
      ,[conductorName] = @conductorName
      ,[driverId] = @driverId
      ,[driverName] = @driverName
      ,[fleetOwnerId] = @fleetOwnerId
      ,[CompanyName] = @CompanyName
      ,[POSID] = @POSID
      ,[RegNo] = @RegNo
      ,[route] = @route
      ,[Status] = Status
      ,[statusid] = @statusid
      ,[Active] = @Active
      WHERE Id = @Id
else
   delete from BTPOSDetails where Id = @Id

END

GO


