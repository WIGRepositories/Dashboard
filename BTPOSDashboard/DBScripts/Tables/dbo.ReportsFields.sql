
/****** Object:  Table [dbo].[ReportsFields]    Script Date: 04/25/2016 13:08:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ReportsFields](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[ReportType] [varchar](50) NOT NULL,
	[FromDate] [datetime] NOT NULL,
	[ToDate] [datetime] NOT NULL,
	[active] [int] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


