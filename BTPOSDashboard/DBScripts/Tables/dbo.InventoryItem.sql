

/****** Object:  Table [dbo].[InventoryItem]    Script Date: 04/25/2016 13:05:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[InventoryItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [varchar](50) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Description] [varchar](50) NULL,
	[Category] [varchar](50) NOT NULL,
	[SubCategory] [varchar](50) NOT NULL,
	[ReOrderPoint] [int] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


