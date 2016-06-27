-- create companies
INSERT INTO [POSDashboard].[dbo].[Company]([Name],[Code],[Desc],[Active])
VALUES ('WEBINGATE','WEBINGATE','WEBINGATE company',1)

INSERT INTO [POSDashboard].[dbo].[Company]([Name],[Code],[Desc],[Active])
VALUES ('ZUPCO','ZUPCO','ZUPCO company',1)

--create 6 users (3 for each company, 1 superviosr each)

--create 2 fleet owners

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

--assign users
--make  2 users as fleet owners
--make 1 user as conductor
--make 1 user as dirver

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

INSERT INTO [POSDashboard].[dbo].[Routes]
           ([RouteName],[Code]           ,[Description]           ,[Active]           ,[SourceId]           ,[DestinationId]           ,[Distance])
     VALUES('HYD-GNTR','R1','R1',1,1,6,300)


INSERT INTO [POSDashboard].[dbo].[Routes]          
		 ([RouteName]           ,[Code]           ,[Description]           ,[Active]           ,[SourceId]           ,[DestinationId]           ,[Distance])
     VALUES
           ('GNTR-HYD','R2','R2',1,6,1,300)


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

--create atleast 3 vehciles for fleet owner

--fleet - route combination

--create some bt pos

--assign bt pos to fleet

--

