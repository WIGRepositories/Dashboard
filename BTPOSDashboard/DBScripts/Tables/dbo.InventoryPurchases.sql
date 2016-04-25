
/****** Object:  Table [dbo].[InventoryPurchases]    Script Date: 04/25/2016 13:06:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[InventoryPurchases](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [varchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[PerUnitPrice] [int] NOT NULL,
	[PurchaseDate] [varchar](50) NOT NULL,
	[PurchaseOrderNumber] [int] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


