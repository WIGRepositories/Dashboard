

/****** Object:  Table [dbo].[FleetOwner]    Script Date: 04/25/2016 12:52:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FleetOwner](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[GroupId] [int] NULL,
	[Active] [int] NOT NULL,
	[FleetOwnerCode] [varchar](10) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


