

/****** Object:  Table [dbo].[TicketGeneration]    Script Date: 04/25/2016 12:58:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TicketGeneration](
	[Source] [varchar](50) NOT NULL,
	[Target] [varchar](50) NOT NULL,
	[NoOfTickets] [int] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


