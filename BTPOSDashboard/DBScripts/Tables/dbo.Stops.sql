

/****** Object:  Table [dbo].[Stops]    Script Date: 04/25/2016 13:00:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Stops](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[Description] [varchar](30) NULL,
	[Code] [varchar](10) NOT NULL,
	[Active] [int] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


