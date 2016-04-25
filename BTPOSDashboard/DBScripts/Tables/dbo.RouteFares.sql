
/****** Object:  Table [dbo].[RouteFares]    Script Date: 04/25/2016 13:05:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RouteFares](
	[active] [int] NOT NULL,
	[fareCodeId] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[routeId] [int] NOT NULL
) ON [PRIMARY]

GO


