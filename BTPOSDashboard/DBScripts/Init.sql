----insert default data
INSERT INTO [POSDashboard].[dbo].[Company]([Name],[Code],[Desc],[Active])
VALUES ('INTERBUS','INTERBUS','INTERBUS company',1)


INSERT INTO [POSDashboard].[dbo].[Users]
           ([FirstName]
           ,[LastName]
           ,[UserTypeId]
           ,[EmpNo]
           ,[Email]
           ,[AddressId]
           ,[MobileNo]
           ,[RoleId]
           ,[Active]
           ,[MiddleName]
           ,[CompanyId])
     VALUES
           ('Admin','Admin',null,'EMP001',null,null,null,1,1,null,1)

INSERT INTO [POSDashboard].[dbo].[Roles]
           ([Name]
           ,[Description]
           ,[Active]
           ,[CompanyId]
		   ,[IsPublic])
     VALUES
           ('Admin',null,1,1,0)

INSERT INTO [POSDashboard].[dbo].[Roles]
           ([Name]
           ,[Description]
           ,[Active]
           ,[CompanyId]
		   ,[IsPublic])
     VALUES
           ('Fleet Owner',null,1,1,1)

INSERT INTO [POSDashboard].[dbo].[UserRoles]
           ([UserId]
           ,[RoleId]
           ,[CompanyId])
     VALUES
           (1,1,1)

INSERT INTO [POSDashboard].[dbo].[UserLogins]
           ([LoginInfo]
           ,[PassKey]
           ,[UserId]
           ,[salt]
           ,[Active])
     VALUES
           ('admin','admin',1,null,1)

INSERT INTO [POSDashboard].[dbo].[CompanyRoles]
           ([CompanyId],[RoleId],[Active])
           VALUES(1,1,1)

		   Set IDENTITY_INSERT  [TypeGroups] ON

INSERT INTO [POSDashboard].[dbo].[TypeGroups]
           (ID,[Name],[Description],[Active])
     VALUES
           (1,'BT POS Status','BT POS Status',1)

INSERT INTO [POSDashboard].[dbo].[TypeGroups]
           (ID,[Name],[Description],[Active])
     VALUES
           (2,'Categories','Categories',1)

Set IDENTITY_INSERT  [TypeGroups] OFF
----btpos status
Set IDENTITY_INSERT  [Types] ON
INSERT INTO [POSDashboard].[dbo].[Types]
           (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue])
     VALUES
           (1,'New',null,1,1,null,null)

INSERT INTO [POSDashboard].[dbo].[Types]
           (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue])
     VALUES
           (2,'Active',null,1,1,null,null)

INSERT INTO [POSDashboard].[dbo].[Types]
           (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue])
     VALUES
           (3,'InActive',null,1,1,null,null)

INSERT INTO [POSDashboard].[dbo].[Types]
           (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue])
     VALUES
           (4,'To be activated',null,1,1,null,null)


---categories

INSERT INTO [POSDashboard].[dbo].[Types]
           (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue])
     VALUES
           (5,'Inventory Category',null,1,2,null,null)

INSERT INTO [POSDashboard].[dbo].[Types]
           (Id,[Name],[Description],[Active],[TypeGroupId],[listkey],[listvalue])
     VALUES
           (6,'License Category',null,1,2,null,null)

Set IDENTITY_INSERT  [Types] OFF

----sub category btpos
Set IDENTITY_INSERT  [SubCategory] ON

INSERT INTO [POSDashboard].[dbo].[SubCategory]
           (Id,[Name]
           ,[Description]
           ,[CategoryId]
           ,[Active])
     VALUES
           (1,'BT POS',null,5,1)

Set IDENTITY_INSERT  [SubCategory] OFF

----inventory item btpos
Set IDENTITY_INSERT  [InventoryItem] ON

INSERT INTO [POSDashboard].[dbo].[InventoryItem]
           (Id,[ItemName]
           ,[Code]
           ,[Description]
           ,[CategoryId]
           ,[SubCategoryId]
           ,[ReOrderPoint])
     VALUES
           (1,'BT POS 8110','BTPOS 8110',null,5,1,0)

Set IDENTITY_INSERT  [InventoryItem] OFF
Set IDENTITY_INSERT  [InventoryItem] ON