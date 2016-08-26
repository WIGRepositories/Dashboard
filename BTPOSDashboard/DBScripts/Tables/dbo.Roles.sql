

/****** Object:  Table [dbo].[Roles]    Script Date: 04/25/2016 13:07:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [nvarchar](50) NULL,
	[Active] [varchar](50) NOT NULL,
	[CompanyId] [int] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [DF_Roles_Active]  DEFAULT ((1)) FOR [Active]
GO


