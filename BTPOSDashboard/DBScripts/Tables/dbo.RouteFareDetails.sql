
/****** Object:  Table [dbo].[RouteFareDetails]    Script Date: 04/25/2016 13:05:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[RouteFareDetails](
	[Id] [int] NOT NULL,
	[RouteId] [varchar](50) NOT NULL,
	[FleetOwnerId] [int] NOT NULL,
	[Source] [varchar](50) NOT NULL,
	[Destination] [nvarchar](50) NOT NULL,
	[Stop] [nvarchar](50) NOT NULL,
	[Kilometers] [int] NOT NULL,
	[Fare] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


