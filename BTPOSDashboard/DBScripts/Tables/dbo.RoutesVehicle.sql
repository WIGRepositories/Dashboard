

/****** Object:  Table [dbo].[RoutesVehicle]    Script Date: 04/25/2016 13:03:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RoutesVehicle](
	[Id] [int] NOT NULL,
	[VehicleId] [nvarchar](50) NOT NULL,
	[RouteId] [nvarchar](50) NOT NULL,
	[EffectiveFrom] [nvarchar](50) NOT NULL,
	[EffectiveTill] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO


