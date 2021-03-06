USE [ChumakovLibrary]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 20.06.2021 11:30:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Author]') AND type in (N'U'))
DROP TABLE [dbo].[Author]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 20.06.2021 11:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[Author_ID] [int] IDENTITY(1,1) NOT NULL,
	[Author_Surname] [varchar](50) NOT NULL,
	[Author_Name] [varchar](50) NOT NULL,
	[Author_Otch] [varchar](50) NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[Author_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Author] ON 

INSERT [dbo].[Author] ([Author_ID], [Author_Surname], [Author_Name], [Author_Otch]) VALUES (1, N'Демидович', N'Борис', N'Павлович')
INSERT [dbo].[Author] ([Author_ID], [Author_Surname], [Author_Name], [Author_Otch]) VALUES (2, N'Гоголь', N'Николай', N'Васильевич')
INSERT [dbo].[Author] ([Author_ID], [Author_Surname], [Author_Name], [Author_Otch]) VALUES (3, N'Диккенс', N'Чарльз', NULL)
INSERT [dbo].[Author] ([Author_ID], [Author_Surname], [Author_Name], [Author_Otch]) VALUES (4, N'Булгаков', N'Михаил', N'Афанасьевич')
INSERT [dbo].[Author] ([Author_ID], [Author_Surname], [Author_Name], [Author_Otch]) VALUES (5, N'Достоевский', N'Федор', N'Михайлович')
INSERT [dbo].[Author] ([Author_ID], [Author_Surname], [Author_Name], [Author_Otch]) VALUES (6, N'Ильф', N'Илья', NULL)
INSERT [dbo].[Author] ([Author_ID], [Author_Surname], [Author_Name], [Author_Otch]) VALUES (7, N'Петров', N'Евгений', NULL)
INSERT [dbo].[Author] ([Author_ID], [Author_Surname], [Author_Name], [Author_Otch]) VALUES (8, N'Пушкин', N'Александр', N'Сергеевич')
INSERT [dbo].[Author] ([Author_ID], [Author_Surname], [Author_Name], [Author_Otch]) VALUES (16, N'Лермонтов', N'Михаил', N'Юрьевич')
INSERT [dbo].[Author] ([Author_ID], [Author_Surname], [Author_Name], [Author_Otch]) VALUES (18, N'Толстой', N'Лев', N'Николаевич')
SET IDENTITY_INSERT [dbo].[Author] OFF
GO
