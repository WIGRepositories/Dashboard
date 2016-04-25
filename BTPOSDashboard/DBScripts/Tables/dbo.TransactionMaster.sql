
/****** Object:  Table [dbo].[TransactionMaster]    Script Date: 04/25/2016 12:56:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TransactionMaster](
	[Id] [int] NOT NULL,
	[TransCode] [varchar](50) NOT NULL,
	[Date] [datetime] NOT NULL,
	[TransType] [varchar](50) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


