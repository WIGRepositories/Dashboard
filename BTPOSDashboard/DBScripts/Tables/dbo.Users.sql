

/****** Object:  Table [dbo].[Users]    Script Date: 04/25/2016 12:41:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](40) NOT NULL,
	[LastName] [varchar](40) NOT NULL,
	[UserTypeId] [int] NOT NULL,
	[EmpNo] [varchar](50) NOT NULL,
	[Email] [varchar](40) NULL,
	[AddressId] [int] NULL,
	[MobileNo] [varchar](15) NULL,
	[RoleId] [int] NULL,
	[Active] [int] NOT NULL,
	[MiddleName] [varchar](50) NULL,
	[CompanyId] [int] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_UserTypeId]  DEFAULT ((1)) FOR [UserTypeId]
GO

ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Active]  DEFAULT ((1)) FOR [Active]
GO

ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_CompanyId]  DEFAULT ((1)) FOR [CompanyId]
GO


