

/****** Object:  Table [dbo].[ObjectAccesses]    Script Date: 04/25/2016 13:16:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ObjectAccesses](
	[Id] [int] NOT NULL,
	[ObjectId] [int] NOT NULL,
	[AccessId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


