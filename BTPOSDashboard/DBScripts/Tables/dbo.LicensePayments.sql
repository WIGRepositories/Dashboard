

/****** Object:  Table [dbo].[LicensePayments]    Script Date: 04/25/2016 13:09:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[LicensePayments](
	[expiryOn] [datetime] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[licenseFor] [varchar](50) NOT NULL,
	[licenseId] [int] NOT NULL,
	[licenseType] [varchar](50) NOT NULL,
	[paidon] [datetime] NOT NULL,
	[renewedon] [datetime] NOT NULL,
	[transId] [varchar](50) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


