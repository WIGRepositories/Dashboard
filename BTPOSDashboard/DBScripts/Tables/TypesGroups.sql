
/****** Object:  Table [dbo].[TypeGroups]    Script Date: 04/25/2016 12:49:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TypeGroups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NULL,
	[Active] [int] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


