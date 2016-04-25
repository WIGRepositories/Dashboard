

/****** Object:  Table [dbo].[RouteDetails]    Script Date: 04/25/2016 13:06:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[RouteDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RouteId] [varchar](50) NOT NULL,
	[stopname] [varchar](50) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[StopCode] [varchar](50) NOT NULL,
	[DistanceFromSource] [int] NOT NULL,
	[DistanceFromDestination] [int] NOT NULL,
	[DistanceFromPreviousStop] [int] NOT NULL,
	[DistanceFromNextStop] [int] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


