

/****** Object:  Table [dbo].[RoutesConfiguration]    Script Date: 04/25/2016 13:03:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[RoutesConfiguration](
	[distanceFromDest] [int] NOT NULL,
	[distanceFromLastStop] [int] NOT NULL,
	[distanceFromPrevStop] [int] NOT NULL,
	[distanceFromSource] [int] NOT NULL,
	[Id] [int] NOT NULL,
	[routeId] [int] NOT NULL,
	[stops] [varchar](50) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


