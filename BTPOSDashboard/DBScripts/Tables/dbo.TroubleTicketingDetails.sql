

/****** Object:  Table [dbo].[TroubleTicketingDetails]    Script Date: 04/25/2016 12:53:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TroubleTicketingDetails](
	[addInfo] [varchar](50) NOT NULL,
	[createdBy] [varchar](50) NOT NULL,
	[createdOn] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[raisedBy] [varchar](50) NOT NULL,
	[status] [varchar](50) NOT NULL,
	[ticketinfo] [varchar](50) NOT NULL,
	[ticketTypeId] [int] NOT NULL,
	[TTId] [int] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


