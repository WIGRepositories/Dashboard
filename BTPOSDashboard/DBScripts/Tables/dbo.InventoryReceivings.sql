
/****** Object:  Table [dbo].[InventoryReceivings]    Script Date: 04/25/2016 13:06:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[InventoryReceivings](
	[amount] [int] NOT NULL,
	[code] [varchar](50) NOT NULL,
	[date] [varchar](50) NOT NULL,
	[Id] [int] NOT NULL,
	[inventoryId] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[reason] [varchar](50) NOT NULL,
	[refundamt] [int] NOT NULL,
	[returnedOn] [varchar](50) NOT NULL,
	[transactionId] [int] NOT NULL,
	[transactiontype] [varchar](50) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


