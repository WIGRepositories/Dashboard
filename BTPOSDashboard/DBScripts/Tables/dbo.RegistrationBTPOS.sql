

/****** Object:  Table [dbo].[RegistrationBTPOS]    Script Date: 04/25/2016 13:09:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[RegistrationBTPOS](
	[code] [varchar](50) NOT NULL,
	[uniqueId] [varchar](50) NOT NULL,
	[ipconfig] [varchar](50) NOT NULL,
	[Active] [int] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


