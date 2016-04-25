
/****** Object:  Table [dbo].[Routes]    Script Date: 04/25/2016 13:04:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Routes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Route] [varchar](50) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Active] [varchar](50) NOT NULL,
	[BTPOSGroupId] [varchar](50) NOT NULL,
	[Source] [varchar](50) NOT NULL,
	[Destination] [varchar](50) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


