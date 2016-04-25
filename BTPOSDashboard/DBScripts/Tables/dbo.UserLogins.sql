

/****** Object:  Table [dbo].[UserLogins]    Script Date: 04/25/2016 12:44:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[UserLogins](
	[LoginInfo] [nvarchar](50) NOT NULL,
	[PassKey] [nvarchar](50) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[salt] [varchar](50) NULL,
	[Active] [int] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[UserLogins] ADD  CONSTRAINT [DF_UserLogins_Active]  DEFAULT ((1)) FOR [Active]
GO


