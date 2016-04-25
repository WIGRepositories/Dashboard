
/****** Object:  Table [dbo].[LicenceStatus]    Script Date: 04/25/2016 13:08:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LicenceStatus](
	[Active] [numeric](18, 0) NULL,
	[Desc] [nchar](10) NULL,
	[Id] [numeric](18, 0) NULL,
	[LicenseStatusType] [nchar](10) NULL,
	[TypeGripidId] [nchar](10) NULL
) ON [PRIMARY]

GO


