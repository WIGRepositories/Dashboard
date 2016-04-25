

/****** Object:  Table [dbo].[POSTerminal]    Script Date: 04/25/2016 13:11:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[POSTerminal](
	[Id] [int] NULL,
	[POSId] [varchar](10) NULL,
	[Status] [int] NULL,
	[GroupId] [int] NULL,
	[Location] [varchar](100) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


