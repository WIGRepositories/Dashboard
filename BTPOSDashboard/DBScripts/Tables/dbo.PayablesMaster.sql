

/****** Object:  Table [dbo].[PayablesMaster]    Script Date: 04/25/2016 13:15:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PayablesMaster](
	[Id] [numeric](18, 0) NULL,
	[Date] [smalldatetime] NULL,
	[PaidFor] [nchar](10) NULL,
	[Desc] [nchar](10) NULL
) ON [PRIMARY]

GO


