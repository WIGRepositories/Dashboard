-- create companies
INSERT INTO [POSDashboard].[dbo].[Company]([Name],[Code],[Desc],[Active])
VALUES ('WEBINGATE','WEBINGATE','WEBINGATE company',1)

INSERT INTO [POSDashboard].[dbo].[Company]([Name],[Code],[Desc],[Active])
VALUES ('ZUPCO','ZUPCO','ZUPCO company',1)

--create 6 users (3 for each company, 1 superviosr each)
INSERT INTO [POSDashboard].[dbo].[Users]
([FirstName] ,[LastName],[EmpNo] ,[Email],[AddressId],[MobileNo],[Active],[MiddleName],[CompanyId],[ManagerId])
 VALUES('INTERBUS Supervisor','S','EMP2','Lokesh@gmail.com',123,973484551,1,'Loku',1,1)

 INSERT INTO [POSDashboard].[dbo].[Users]
([FirstName] ,[LastName],[EmpNo] ,[Email],[AddressId],[MobileNo],[Active],[MiddleName],[CompanyId],[ManagerId])
 VALUES('INTERBUS User','M','EMP3','Lokesh@gmail.com',123,973484551,1,'Loku',1,1)

 --webingate users
 --4
INSERT INTO [POSDashboard].[dbo].[Users]
([FirstName] ,[LastName],[EmpNo] ,[Email],[AddressId],[MobileNo],[Active],[MiddleName],[CompanyId],[ManagerId])
 VALUES('WEBINGATE FO','WF','Webuser1','Lokesh@gmail.com',123,973484551,1,'Loku',2,null)

 --5
  INSERT INTO [POSDashboard].[dbo].[Users]
([FirstName] ,[LastName],[EmpNo] ,[Email],[AddressId],[MobileNo],[Active],[MiddleName],[CompanyId],[ManagerId])
 VALUES('WDriver','D','Webuser2','sri@gmail.com',1236,9799551,1,'sri',2,4)

 --6
 INSERT INTO [POSDashboard].[dbo].[Users]
([FirstName] ,[LastName],[EmpNo] ,[Email],[AddressId],[MobileNo],[Active],[MiddleName],[CompanyId],[ManagerId])
 VALUES('WConductor','C','Webuser3','Siva@gmail.com',12,973484521,1,'siva',2,4)

 --7
 INSERT INTO [POSDashboard].[dbo].[Users]
([FirstName] ,[LastName],[EmpNo] ,[Email],[AddressId],[MobileNo],[Active],[MiddleName],[CompanyId],[ManagerId])
 VALUES('WSupervisor','S','Webuser4','Vinay@gmail.com',1234,973444551,1,'Vinu',2,4)

 --zupco users
 --8
 INSERT INTO [POSDashboard].[dbo].[Users]
([FirstName] ,[LastName],[EmpNo] ,[Email],[AddressId],[MobileNo],[Active],[MiddleName],[CompanyId],[ManagerId])
 VALUES('ZUPCO FO','F','Zupuser1','Sai@gmail.com',123,973484551,1,'Sai',3,null)

 --9
  INSERT INTO [POSDashboard].[dbo].[Users]
([FirstName] ,[LastName],[EmpNo] ,[Email],[AddressId],[MobileNo],[Active],[MiddleName],[CompanyId],[ManagerId])
 VALUES('ZDriver','D','Zupuser2','sri@gmail.com',1236,9799551,1,'sri',3,8)

 --10
 INSERT INTO [POSDashboard].[dbo].[Users]
([FirstName] ,[LastName],[EmpNo] ,[Email],[AddressId],[MobileNo],[Active],[MiddleName],[CompanyId],[ManagerId])
 VALUES('ZConductor','C','Zupuser3','Siva@gmail.com',12,973484521,1,'siva',3,8)

 --11
 INSERT INTO [POSDashboard].[dbo].[Users]
([FirstName] ,[LastName],[EmpNo] ,[Email],[AddressId],[MobileNo],[Active],[MiddleName],[CompanyId],[ManagerId])
 VALUES('ZSupervisor','S','Zupuser4','Vinay@gmail.com',1234,973444551,1,'Vinu',3,8)

--create 2 fleet owners
INSERT INTO [POSDashboard].[dbo].[FleetOwner]
           ([UserId],[CompanyId],[Active],[FleetOwnerCode])
     VALUES
           (4 ,2 ,1,'FL001')

INSERT INTO [POSDashboard].[dbo].[FleetOwner]
           ([UserId],[CompanyId],[Active],[FleetOwnerCode])
     VALUES
           (8 ,3 ,1,'FL002')

--assign roles to company
INSERT INTO [POSDashboard].[dbo].[CompanyRoles]([CompanyId],[RoleId],[Active]) VALUES (2,6,1)
INSERT INTO [POSDashboard].[dbo].[CompanyRoles]([CompanyId],[RoleId],[Active]) VALUES (2,7,1)
INSERT INTO [POSDashboard].[dbo].[CompanyRoles]([CompanyId],[RoleId],[Active]) VALUES (2,8,1)
INSERT INTO [POSDashboard].[dbo].[CompanyRoles]([CompanyId],[RoleId],[Active]) VALUES (2,9,1)
INSERT INTO [POSDashboard].[dbo].[CompanyRoles]([CompanyId],[RoleId],[Active]) VALUES (2,10,1)
INSERT INTO [POSDashboard].[dbo].[CompanyRoles]([CompanyId],[RoleId],[Active]) VALUES (2,12,1)
INSERT INTO [POSDashboard].[dbo].[CompanyRoles]([CompanyId],[RoleId],[Active]) VALUES (2,13,1)

INSERT INTO [POSDashboard].[dbo].[CompanyRoles]([CompanyId],[RoleId],[Active]) VALUES (3,6,1)
INSERT INTO [POSDashboard].[dbo].[CompanyRoles]([CompanyId],[RoleId],[Active]) VALUES (3,7,1)
INSERT INTO [POSDashboard].[dbo].[CompanyRoles]([CompanyId],[RoleId],[Active]) VALUES (3,8,1)
INSERT INTO [POSDashboard].[dbo].[CompanyRoles]([CompanyId],[RoleId],[Active]) VALUES (3,9,1)
INSERT INTO [POSDashboard].[dbo].[CompanyRoles]([CompanyId],[RoleId],[Active]) VALUES (3,10,1)
INSERT INTO [POSDashboard].[dbo].[CompanyRoles]([CompanyId],[RoleId],[Active]) VALUES (3,12,1)
INSERT INTO [POSDashboard].[dbo].[CompanyRoles]([CompanyId],[RoleId],[Active]) VALUES (3,13,1)

--assign roles to users
INSERT INTO [POSDashboard].[dbo].[UserRoles]([UserId],[RoleId],[CompanyId])
VALUES(2,2,1)
INSERT INTO [POSDashboard].[dbo].[UserRoles]([UserId],[RoleId],[CompanyId])
VALUES(3,4,1)

--make  2 users as fleet owners
INSERT INTO [POSDashboard].[dbo].[UserRoles]([UserId],[RoleId],[CompanyId])
VALUES(4,6,2)

INSERT INTO [POSDashboard].[dbo].[UserRoles]([UserId],[RoleId],[CompanyId])
VALUES(8,6,3)

--make 1 user as conductor
--make 1 user as dirver
--make 1 user as supervisor
INSERT INTO [POSDashboard].[dbo].[UserRoles]([UserId],[RoleId],[CompanyId])
VALUES(5,9,2)

INSERT INTO [POSDashboard].[dbo].[UserRoles]([UserId],[RoleId],[CompanyId])
VALUES(6,13,2)

INSERT INTO [POSDashboard].[dbo].[UserRoles]([UserId],[RoleId],[CompanyId])
VALUES(7,7,2)

--make 1 user as conductor
--make 1 user as dirver
--make 1 user as supervisor
INSERT INTO [POSDashboard].[dbo].[UserRoles]([UserId],[RoleId],[CompanyId])
VALUES(9,9,3)


INSERT INTO [POSDashboard].[dbo].[UserRoles]([UserId],[RoleId],[CompanyId])
VALUES(10,13,3)

INSERT INTO [POSDashboard].[dbo].[UserRoles]([UserId],[RoleId],[CompanyId])
VALUES(11,7,3)


--create some stops
INSERT INTO [POSDashboard].[dbo].[Stops]([Name],[Description],[Code],[Active])
     VALUES('Hyderabad','Hyderabad','HYD',1)

INSERT INTO [POSDashboard].[dbo].[Stops]([Name],[Description],[Code],[Active])
     VALUES('Dilsuknagar','Dilsuknagar','DSNR',1)

INSERT INTO [POSDashboard].[dbo].[Stops]([Name],[Description],[Code],[Active])
     VALUES('Suryapet','Suryapet','SRPT',1)

INSERT INTO [POSDashboard].[dbo].[Stops]([Name],[Description],[Code],[Active])
     VALUES('Kodad','Kodad','KDD',1)

INSERT INTO [POSDashboard].[dbo].[Stops]([Name],[Description],[Code],[Active])
     VALUES('Choutuppal','Choutuppal','CHPL',1)

INSERT INTO [POSDashboard].[dbo].[Stops]([Name],[Description],[Code],[Active])
     VALUES('Guntur','Guntur','GNTR',1)

--create 2-3 routes using above stops
--1
INSERT INTO [POSDashboard].[dbo].[Routes]
           ([RouteName],[Code]           ,[Description]           ,[Active]           ,[SourceId]           ,[DestinationId]           ,[Distance])
     VALUES('HYD-GNTR','R1','R1',1,1,6,300)

--2
INSERT INTO [POSDashboard].[dbo].[Routes]          
		 ([RouteName]           ,[Code]           ,[Description]           ,[Active]           ,[SourceId]           ,[DestinationId]           ,[Distance])
     VALUES
           ('GNTR-HYD','R2','R2',1,6,1,300)

--3
INSERT INTO [POSDashboard].[dbo].[Routes]
           ([RouteName]
           ,[Code]
           ,[Description]
           ,[Active]
           ,[SourceId]
           ,[DestinationId]
           ,[Distance])
     VALUES
           ('HYD-KDD','R3','R3',1,1,4,300)
 --4                     
INSERT INTO [POSDashboard].[dbo].[Routes]
           ([RouteName]
           ,[Code]
           ,[Description]
           ,[Active]
           ,[SourceId]
           ,[DestinationId]
           ,[Distance])
     VALUES
           ('KDD-HYD','R4','R4',1,4,1,300)

--assign the above routes to fleet owners
--[InsUpdDelFleetOwnerRoutes] @Id,@RouteId,@cmpId,@fleetOwnerId,@FromDate,@ToDate,@insupddelflag 
--webingate 
exec [InsUpdDelFleetOwnerRoutes]  -1, 1,2,1,null, null,'I'
exec [InsUpdDelFleetOwnerRoutes]  -1, 2,2,1,null, null,'I'

--zupco
exec [InsUpdDelFleetOwnerRoutes]  -1, 2,3,2,null, null,'I'
exec [InsUpdDelFleetOwnerRoutes]  -1, 3,3,2,null, null,'I'

--create atleast 3 vehciles for fleet owner (1 and 2) 
--insert 6 vehicles
----fleet owner 1
INSERT INTO [POSDashboard].[dbo].[FleetDetails]
 ([VehicleRegNo],[VehicleTypeId],[FleetOwnerId],[CompanyId],[ServiceTypeId],[Active],[LayoutTypeId],[EngineNo],[FuelUsed],[MonthAndYrOfMfr],[ChasisNo],[SeatingCapacity],[DateOfRegistration])
 VALUES
  ('AP4952',10,1, 2,12,1,27,'CMP1',10,null,'Cpm21',56,null)

INSERT INTO [POSDashboard].[dbo].[FleetDetails]
([VehicleRegNo],[VehicleTypeId],[FleetOwnerId],[CompanyId],[ServiceTypeId],[Active],[LayoutTypeId],[EngineNo],[FuelUsed],[MonthAndYrOfMfr],[ChasisNo],[SeatingCapacity],[DateOfRegistration])
 VALUES
 ('TS9911',9,1, 2,12,1,27,'CMP2',10,null,'Cpm22',54,null)

 INSERT INTO [POSDashboard].[dbo].[FleetDetails]
([VehicleRegNo],[VehicleTypeId],[FleetOwnerId],[CompanyId],[ServiceTypeId],[Active],[LayoutTypeId],[EngineNo],[FuelUsed],[MonthAndYrOfMfr],[ChasisNo],[SeatingCapacity],[DateOfRegistration])
 VALUES
 ('TS4952',10,1, 2,12,1,27,'CMP3',10,null,'Cpm23',32,null)

----fleet owner 2
 INSERT INTO [POSDashboard].[dbo].[FleetDetails]
 ([VehicleRegNo],[VehicleTypeId],[FleetOwnerId],[CompanyId],[ServiceTypeId],[Active],[LayoutTypeId],[EngineNo],[FuelUsed],[MonthAndYrOfMfr],[ChasisNo],[SeatingCapacity],[DateOfRegistration])
 VALUES
  ('AP4952',10,2, 3,12,1,27,'ZpuP1',10,null,'Zup21',56,null)

INSERT INTO [POSDashboard].[dbo].[FleetDetails]
([VehicleRegNo],[VehicleTypeId],[FleetOwnerId],[CompanyId],[ServiceTypeId],[Active],[LayoutTypeId],[EngineNo],[FuelUsed],[MonthAndYrOfMfr],[ChasisNo],[SeatingCapacity],[DateOfRegistration])
 VALUES
 ('TS9911',10,2, 3,12,1,27,'Zup2',10,null,'Zup22',46,null)

 INSERT INTO [POSDashboard].[dbo].[FleetDetails]
([VehicleRegNo],[VehicleTypeId],[FleetOwnerId],[CompanyId],[ServiceTypeId],[Active],[LayoutTypeId],[EngineNo],[FuelUsed],[MonthAndYrOfMfr],[ChasisNo],[SeatingCapacity],[DateOfRegistration])
 VALUES
 ('TS4952',9,2, 3,12,1,27,'Zup3',10,null,'Zup23',33,null)

--fleet - route combination
INSERT INTO [POSDashboard].[dbo].[FleetRoutes]([VehicleId],[RouteId],[EffectiveFrom] ,[EffectiveTill])
     VALUES(1 ,1,null,null)

	 INSERT INTO [POSDashboard].[dbo].[FleetRoutes]([VehicleId],[RouteId],[EffectiveFrom] ,[EffectiveTill])
     VALUES(2 ,2,null,null)

	 INSERT INTO [POSDashboard].[dbo].[FleetRoutes]([VehicleId],[RouteId],[EffectiveFrom] ,[EffectiveTill])
     VALUES(3 ,1,null,null)


	 INSERT INTO [POSDashboard].[dbo].[FleetRoutes]([VehicleId],[RouteId],[EffectiveFrom] ,[EffectiveTill])
     VALUES(4 ,2,null,null)


	 INSERT INTO [POSDashboard].[dbo].[FleetRoutes]([VehicleId],[RouteId],[EffectiveFrom] ,[EffectiveTill])
     VALUES(5 ,2,null,null)


	 INSERT INTO [POSDashboard].[dbo].[FleetRoutes]([VehicleId],[RouteId],[EffectiveFrom] ,[EffectiveTill])
     VALUES(6 ,3,null,null)
GO


--create some bt pos

--assign bt pos to fleet



