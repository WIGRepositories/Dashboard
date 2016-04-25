/****** Object:  Table [dbo].[Blocklist]    Script Date: 04/25/2016 12:13:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Blocklist](
	[Id] [numeric](18, 0) NULL,
	[ItemId] [numeric](18, 0) NULL,
	[ItemTypeId] [numeric](18, 0) NULL,
	[Formdate] [nchar](10) NULL,
	[Todate] [nchar](10) NULL,
	[Active] [numeric](18, 0) NULL,
	[Desc] [nchar](10) NULL,
	[Reason] [nchar](10) NULL,
	[Blockedby] [nchar](10) NULL,
	[UnBlockedby] [nchar](10) NULL,
	[Blockedon] [nchar](10) NULL,
	[UnBlockedon] [nchar](10) NULL
) ON [PRIMARY]

GO


