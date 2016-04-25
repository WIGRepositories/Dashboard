

/****** Object:  Table [dbo].[TransactionDetails]    Script Date: 04/25/2016 12:56:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TransactionDetails](
	[Id] [int] NULL,
	[TransId] [varchar](50) NULL,
	[TotalAmt] [int] NULL,
	[PaymentId] [varchar](50) NULL,
	[BTPOSid] [varchar](50) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


