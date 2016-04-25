

/****** Object:  Table [dbo].[TroubleTicketingStatus]    Script Date: 04/25/2016 12:50:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TroubleTicketingStatus](
	[Active] [numeric](18, 0) NULL,
	[Desc] [nchar](10) NULL,
	[Id] [numeric](18, 0) NULL,
	[TtStatusTpe] [nchar](10) NULL,
	[TypeGripId] [numeric](18, 0) NULL
) ON [PRIMARY]

GO


