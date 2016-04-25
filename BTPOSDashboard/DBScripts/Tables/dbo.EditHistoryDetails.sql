
/****** Object:  Table [dbo].[EditHistoryDetails]    Script Date: 04/25/2016 12:51:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[EditHistoryDetails](
	[EditHistoryId] [int] NULL,
	[FromValue] [varchar](50) NULL,
	[ToValue] [varchar](50) NULL,
	[ChangeType] [varchar](50) NULL,
	[Field1] [varchar](50) NULL,
	[Field2] [varchar](50) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


