

/****** Object:  Table [dbo].[VehicleDetails]    Script Date: 04/25/2016 12:39:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VehicleDetails](
	[busId] [money] NOT NULL,
	[busTypeId] [int] NOT NULL,
	[conductorId] [int] NOT NULL,
	[conductorName] [varchar](50) NOT NULL,
	[driverId] [int] NOT NULL,
	[driverName] [varchar](50) NOT NULL,
	[fleetOwnerId] [int] NOT NULL,
	[CompanyName] [varchar](50) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[POSID] [int] NOT NULL,
	[RegNo] [varchar](50) NOT NULL,
	[route] [varchar](50) NOT NULL,
	[Status] [varchar](50) NOT NULL,
	[statusid] [int] NOT NULL,
	[Active] [int] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


