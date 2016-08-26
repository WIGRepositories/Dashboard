
/****** Object:  Table [dbo].[Payment]    Script Date: 04/25/2016 13:14:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Payment](
	[Card] [varchar](50) NOT NULL,
	[MobilePayment] [varchar](50) NOT NULL,
	[Cash] [varchar](50) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


