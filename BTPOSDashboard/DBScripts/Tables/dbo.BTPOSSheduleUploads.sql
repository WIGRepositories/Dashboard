

/****** Object:  Table [dbo].[BTPOSSheduleUploads]    Script Date: 04/25/2016 12:49:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BTPOSSheduleUploads](
	[Id] [numeric](18, 0) NULL,
	[POSID] [numeric](18, 0) NULL,
	[UploadOn] [nchar](10) NULL,
	[UploadedOn] [nchar](10) NULL,
	[Status] [nchar](10) NULL,
	[UploadData] [nchar](10) NULL,
	[Ipconfig] [nchar](10) NULL
) ON [PRIMARY]

GO


