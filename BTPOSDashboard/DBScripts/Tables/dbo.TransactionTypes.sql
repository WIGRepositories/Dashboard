
/****** Object:  Table [dbo].[TransactionTypes]    Script Date: 04/25/2016 12:55:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TransactionTypes](
	[active] [int] NOT NULL,
	[desc] [varchar](50) NOT NULL,
	[Id] [int] NOT NULL,
	[TransactionTypes] [varchar](50) NOT NULL,
	[typegrpid] [int] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


