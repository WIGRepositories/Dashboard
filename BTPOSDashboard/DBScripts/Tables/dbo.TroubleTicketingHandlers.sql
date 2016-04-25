

/****** Object:  Table [dbo].[TroubleTicketingHandlers]    Script Date: 04/25/2016 12:52:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TroubleTicketingHandlers](
	[handledOn] [int] NOT NULL,
	[Id] [int] NOT NULL,
	[status] [int] NOT NULL,
	[TTId] [int] NOT NULL,
	[userid] [int] NOT NULL
) ON [PRIMARY]

GO


