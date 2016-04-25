

/****** Object:  Table [dbo].[BTPOSInventorySales]    Script Date: 04/25/2016 12:38:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[BTPOSInventorySales](
	[amount] [int] NOT NULL,
	[code] [varchar](50) NOT NULL,
	[Id] [int] NOT NULL,
	[inventoryId] [int] NOT NULL,
	[perunit] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[soldon] [varchar](50) NOT NULL,
	[transactionId] [int] NOT NULL,
	[transactiontype] [varchar](50) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


