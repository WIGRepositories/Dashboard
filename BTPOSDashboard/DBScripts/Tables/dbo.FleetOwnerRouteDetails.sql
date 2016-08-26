

/****** Object:  Table [dbo].[FleetOwnerRouteDetails]    Script Date: 04/25/2016 12:55:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FleetOwnerRouteDetails](
	[FleetOwnerId] [int] NOT NULL,
	[RouteId] [varchar](50) NOT NULL,
	[Stop1] [nvarchar](50) NOT NULL,
	[PreviousStop] [nvarchar](50) NOT NULL,
	[NextStop] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


