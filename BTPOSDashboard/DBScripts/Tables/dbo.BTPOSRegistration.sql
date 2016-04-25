
/****** Object:  Table [dbo].[BTPOSRegistration]    Script Date: 04/25/2016 12:41:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BTPOSRegistration](
	[Id] [numeric](18, 0) NULL,
	[POSID] [numeric](18, 0) NULL,
	[Status] [nchar](10) NULL,
	[FleetOwenerId] [numeric](18, 0) NULL,
	[RegisteredOn] [nchar](10) NULL,
	[IpConfig] [nchar](10) NULL,
	[RegStatus] [nchar](10) NULL,
	[LincenseNo] [nchar](10) NULL,
	[ActivatedOn] [nchar](10) NULL,
	[ExpiryDate] [nchar](10) NULL
) ON [PRIMARY]

GO


