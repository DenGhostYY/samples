USE [ChumakovLibrary]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 20.06.2021 11:30:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Genre]') AND type in (N'U'))
DROP TABLE [dbo].[Genre]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 20.06.2021 11:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[Genre_ID] [int] IDENTITY(1,1) NOT NULL,
	[Genre_Name] [varchar](70) NOT NULL,
 CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED 
(
	[Genre_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Genre] ON 

INSERT [dbo].[Genre] ([Genre_ID], [Genre_Name]) VALUES (1, N'Трагедия')
INSERT [dbo].[Genre] ([Genre_ID], [Genre_Name]) VALUES (4, N'Комедия')
INSERT [dbo].[Genre] ([Genre_ID], [Genre_Name]) VALUES (7, N'Детектив')
INSERT [dbo].[Genre] ([Genre_ID], [Genre_Name]) VALUES (10, N'Эпопея')
SET IDENTITY_INSERT [dbo].[Genre] OFF
GO
