USE [Dashboard]
GO

/****** Object:  Table [dbo].[SMSEmailConfiguration]    Script Date: 04/25/2016 13:02:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SMSEmailConfiguration](
	[AlertTypeId] [int] NOT NULL,
	[enddate] [datetime] NOT NULL,
	[hashkey] [datetime] NOT NULL,
	[Id] [int] NOT NULL,
	[providername] [varchar](50) NOT NULL,
	[pwd] [varchar](50) NOT NULL,
	[saltkey] [datetime] NOT NULL,
	[startdate] [datetime] NOT NULL,
	[username] [varchar](50) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


