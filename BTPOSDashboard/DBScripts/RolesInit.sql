------insert default data

----INTERBUS administrator: Responsible for managing INTERBUS application, 
----users, Fleet companies, groups, rights and roles, policy and backups, 
----updates, 

--INTERBUS Finance Administrator: Responsible for the billing function of 
--Access Fees, Support fees, License fees, Annual fees, Registration fees,
--Purchase of BT POS, etc.,

--Technical Support Engineer: Does not configure INTERBUS server but 
--troubleshoots and configures BT POS for clients. Also can blacklist and 
--activate BT POS devices 

--Helpdesk and Support Technician: Takes customer complaints and logs into--system as Trouble Tickets for Technical support engineer to fix 
--problems. 

--Sales Consultant: Also has access to Billing module to affect payments 
--and receipting for fees and purchases of BT POS.

--Fleet owner: INTERBUS client who registers with INTERBUS and who 
--procures BT POS terminals and manages fleet.

--Supervisor: Configured by fleet owner. Manages and operates BT POS 
--terminals. He should be trained on the BT POS usage and features.

--Manager: Configured by fleet owner. Manages and operates BT POS 
--terminals. He should be trained on the BT POS usage and features.

--Fleet owner: INTERBUS client who registers with INTERBUS and who
--procures BT POS terminals and manages fleet. Initially should add users 
--and feet with specific roles to his fleet. Has access to raise Trouble 
--Ticket with Interbus Team.

--Fleet owner Supervisor: (On Spot Inspector) Authorized and configured by 
--the fleet owner and manages and operates BT POS terminals. Authorizes 
--Routes, BT POS and Front Office sales transactions inspections and 
--checks, approves transfers to other BTPOS and refunds to passengers

--Fleet owner Manager: Configured by fleet owner. Manages and operates BT 
--POS terminals, Configures routes, users and authorizes vouchers, 
--transfers, BT POS and Ticket front office Cash-In or Cash-Out, advanced 
--customer queries and refunds, Reports and .

--Fleet Conductor: Configured by fleet owner. Operates individual assigned
--BT POS terminals in registered Bus to sale tickets to passengers. Cannot
--configure BTPOS or change Settings, cannot authorize refunds, cash outs 
--or transfers.

--Fleet Ticket Salesperson Front Office: Configured by fleet owner for 
--Commercial website system login for his fleet. Manages passenger’s 
--complaints operates BT POS terminals and Commercial website system to 
--mainly do front office tickets sale online at bus station or office 
--outlet, customer queries and routes updates in system, sale online 
--tickets, resolve offers, vouchers, discounts, tariffs, routes 
--availability, fleet time table queries, etc.

   

--INTERBUS Finance Administrator: Responsible for the billing function of 
--Access Fees, Support fees, License fees, Annual fees, Registration fees, 
--Purchase of BT POS, etc.,

--INTERBUS Technical Support Engineer: Does not configure INTERBUS server 
--but troubleshoots and configures POS devices for clients. Also can
--blacklist and activate BT POS devices 

--INTERBUS Helpdesk and Support Technician: INTERBUS shall take customer 
--complaint and logs into system as Trouble Tickets for Technical support
--engineer or Sales Consultant to fix problems. Has access to NOC 
--Dashboard and only role that can close TT after successful clearing by 
--Technician or Consultant.

--INTERBUS Sales Consultant: Also has access to Billing module to affect 
--payments and receipting for fees and purchases of BT POS.



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



INSERT INTO [POSDashboard].[dbo].[CompanyRoles]
           ([CompanyId],[RoleId],[Active])
           VALUES(1,1,1)



