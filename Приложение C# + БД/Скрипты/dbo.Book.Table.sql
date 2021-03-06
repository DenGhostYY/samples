USE [ChumakovLibrary]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 20.06.2021 11:30:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Book]') AND type in (N'U'))
DROP TABLE [dbo].[Book]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 20.06.2021 11:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[Book_ID] [int] IDENTITY(1,1) NOT NULL,
	[Book_Name] [varchar](70) NOT NULL,
	[Authors]  AS ([dbo].[AuthorsOfBook]([Book_ID])),
	[Genres]  AS ([dbo].[GenresOfBook]([Book_ID])),
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[Book_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([Book_ID], [Book_Name]) VALUES (1, N'Сборник задач и упражений по математическому анализу')
INSERT [dbo].[Book] ([Book_ID], [Book_Name]) VALUES (2, N'Мертвые души')
INSERT [dbo].[Book] ([Book_ID], [Book_Name]) VALUES (3, N'Приключения Оливера Твиста')
INSERT [dbo].[Book] ([Book_ID], [Book_Name]) VALUES (4, N'Шинель')
INSERT [dbo].[Book] ([Book_ID], [Book_Name]) VALUES (5, N'Мастер и Маргарита')
INSERT [dbo].[Book] ([Book_ID], [Book_Name]) VALUES (6, N'Собачье сердце')
INSERT [dbo].[Book] ([Book_ID], [Book_Name]) VALUES (7, N'Двенадцать стульев')
INSERT [dbo].[Book] ([Book_ID], [Book_Name]) VALUES (8, N'Золотой теленок')
INSERT [dbo].[Book] ([Book_ID], [Book_Name]) VALUES (9, N'Преступление и наказание')
INSERT [dbo].[Book] ([Book_ID], [Book_Name]) VALUES (10, N'Униженные и оскорбленные')
INSERT [dbo].[Book] ([Book_ID], [Book_Name]) VALUES (11, N'Капитанская дочка')
INSERT [dbo].[Book] ([Book_ID], [Book_Name]) VALUES (12, N'Евгений Онегин')
INSERT [dbo].[Book] ([Book_ID], [Book_Name]) VALUES (13, N'Герой нашего времени')
INSERT [dbo].[Book] ([Book_ID], [Book_Name]) VALUES (14, N'Мцыри')
INSERT [dbo].[Book] ([Book_ID], [Book_Name]) VALUES (18, N'Война и мир')
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
