

/****** Object:  Table [dbo].[SMSProviderConfig]    Script Date: 04/25/2016 13:01:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SMSProviderConfig](
	[Id] [numeric](18, 0) NULL,
	[ProviderName] [nchar](10) NULL,
	[BTPOSGRPID] [nchar](10) NULL,
	[Active] [nchar](10) NULL,
	[UserId] [numeric](18, 0) NULL,
	[Passkey] [nchar](10) NULL
) ON [PRIMARY]

GO


