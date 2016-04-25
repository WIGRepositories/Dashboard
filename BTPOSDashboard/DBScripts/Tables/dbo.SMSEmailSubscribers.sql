

/****** Object:  Table [dbo].[SMSEmailSubscribers]    Script Date: 04/25/2016 13:02:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SMSEmailSubscribers](
	[AlertId] [int] NOT NULL,
	[emailid] [varchar](50) NOT NULL,
	[enddate] [datetime] NOT NULL,
	[frequency] [int] NOT NULL,
	[Id] [int] NOT NULL,
	[phNo] [varchar](50) NOT NULL,
	[startdate] [datetime] NOT NULL,
	[userid] [int] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


