

/****** Object:  Table [dbo].[Fares]    Script Date: 04/25/2016 12:52:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Fares](
	[Id] [int] NULL,
	[FromStop] [varchar](50) NULL,
	[ToStop] [varchar](50) NULL,
	[Fare] [varchar](50) NULL,
	[Active] [varchar](50) NULL,
	[RouteId] [varchar](50) NULL,
	[Name] [varchar](50) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


