
/****** Object:  Table [dbo].[Company]    Script Date: 04/25/2016 12:49:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Company](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Desc] [varchar](50) NULL,
	[Active] [int] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


