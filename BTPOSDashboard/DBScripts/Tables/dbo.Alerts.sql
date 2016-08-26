/****** Object:  Table [dbo].[Alerts]    Script Date: 05/05/2016 18:38:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Alerts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Message] [varchar](50) NOT NULL,
	[MessageTypeId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Alerts] ADD  CONSTRAINT [DF_AlertNotifications_UserId]  DEFAULT ((1)) FOR [UserId]
GO
