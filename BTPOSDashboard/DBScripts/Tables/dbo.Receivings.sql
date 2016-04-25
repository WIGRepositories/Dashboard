

/****** Object:  Table [dbo].[Receivings]    Script Date: 04/25/2016 13:11:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Receivings](
	[Id] [numeric](18, 0) NULL,
	[Amount] [nchar](10) NULL,
	[MasterId] [numeric](18, 0) NULL,
	[ReceivedBy] [nchar](10) NULL
) ON [PRIMARY]

GO


