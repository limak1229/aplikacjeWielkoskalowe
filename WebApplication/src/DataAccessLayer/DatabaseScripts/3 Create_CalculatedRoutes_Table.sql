USE [AplikacjeWielkoskalowe]
GO

/****** Object:  Table [dbo].[CalculatedRoutes]    Script Date: 09.05.2017 19:39:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CalculatedRoutes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Token] [uniqueidentifier] NOT NULL,
	[DataVersion] [nchar](10) NOT NULL,
	[Data] [text] NOT NULL,
	[CreatedDate] [date] NOT NULL,
 CONSTRAINT [PK_CalculatedRoutes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[CalculatedRoutes] ADD  CONSTRAINT [DF_CalculatedRoutes_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO


