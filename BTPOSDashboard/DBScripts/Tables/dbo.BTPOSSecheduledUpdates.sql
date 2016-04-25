

/****** Object:  Table [dbo].[BTPOSSecheduledUpdates]    Script Date: 04/25/2016 12:42:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BTPOSSecheduledUpdates](
	[Id] [numeric](18, 0) NULL,
	[POSID] [numeric](18, 0) NULL,
	[UploadOn] [nchar](10) NULL,
	[UploadedOn] [nchar](10) NULL,
	[Status] [nchar](10) NULL,
	[UploadData] [nchar](10) NULL,
	[IpConfig] [nchar](10) NULL
) ON [PRIMARY]

GO


