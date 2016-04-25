
/****** Object:  Table [dbo].[Expenses]    Script Date: 04/25/2016 12:51:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Expenses](
	[amount] [int] NOT NULL,
	[Date] [varchar](50) NOT NULL,
	[desc] [varchar](50) NOT NULL,
	[Id] [varchar](50) NOT NULL,
	[MasterId] [int] NOT NULL,
	[paidBy] [varchar](50) NOT NULL,
	[paidFor] [varchar](50) NOT NULL,
	[transactionId] [int] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


