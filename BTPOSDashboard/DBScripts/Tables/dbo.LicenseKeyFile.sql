
/****** Object:  Table [dbo].[LicenseKeyFile]    Script Date: 04/25/2016 13:08:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[LicenseKeyFile](
	[Id] [int] NOT NULL,
	[LicenseType] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[desc] [varchar](50) NOT NULL,
	[active] [int] NOT NULL,
	[key] [varchar](50) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


