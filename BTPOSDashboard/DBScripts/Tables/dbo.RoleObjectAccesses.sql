

/****** Object:  Table [dbo].[RoleObjectAccesses]    Script Date: 04/25/2016 13:08:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RoleObjectAccesses](
	[Id] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[ObjectId] [int] NOT NULL,
	[AccessId] [int] NOT NULL
) ON [PRIMARY]

GO


