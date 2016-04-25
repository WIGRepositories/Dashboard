
/****** Object:  Table [dbo].[SubCategory]    Script Date: 04/25/2016 12:59:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SubCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](150) NULL,
	[CategoryId] [int] NOT NULL,
	[Active] [int] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SubCategory] ADD  CONSTRAINT [DF_SubCategory_Active]  DEFAULT ((1)) FOR [Active]
GO


