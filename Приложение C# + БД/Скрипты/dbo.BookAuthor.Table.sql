USE [ChumakovLibrary]
GO
ALTER TABLE [dbo].[BookAuthor] DROP CONSTRAINT [FK_BookAuthor_Book]
GO
ALTER TABLE [dbo].[BookAuthor] DROP CONSTRAINT [FK_BookAuthor_Author]
GO
/****** Object:  Table [dbo].[BookAuthor]    Script Date: 20.06.2021 11:30:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BookAuthor]') AND type in (N'U'))
DROP TABLE [dbo].[BookAuthor]
GO
/****** Object:  Table [dbo].[BookAuthor]    Script Date: 20.06.2021 11:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookAuthor](
	[BookAuthor_ID] [int] IDENTITY(1,1) NOT NULL,
	[Book_ID] [int] NOT NULL,
	[Author_ID] [int] NOT NULL,
 CONSTRAINT [PK_BookAuthor] PRIMARY KEY CLUSTERED 
(
	[BookAuthor_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BookAuthor] ON 

INSERT [dbo].[BookAuthor] ([BookAuthor_ID], [Book_ID], [Author_ID]) VALUES (1, 1, 1)
INSERT [dbo].[BookAuthor] ([BookAuthor_ID], [Book_ID], [Author_ID]) VALUES (2, 2, 2)
INSERT [dbo].[BookAuthor] ([BookAuthor_ID], [Book_ID], [Author_ID]) VALUES (3, 3, 3)
INSERT [dbo].[BookAuthor] ([BookAuthor_ID], [Book_ID], [Author_ID]) VALUES (4, 4, 2)
INSERT [dbo].[BookAuthor] ([BookAuthor_ID], [Book_ID], [Author_ID]) VALUES (5, 5, 4)
INSERT [dbo].[BookAuthor] ([BookAuthor_ID], [Book_ID], [Author_ID]) VALUES (6, 6, 4)
INSERT [dbo].[BookAuthor] ([BookAuthor_ID], [Book_ID], [Author_ID]) VALUES (7, 7, 6)
INSERT [dbo].[BookAuthor] ([BookAuthor_ID], [Book_ID], [Author_ID]) VALUES (8, 7, 7)
INSERT [dbo].[BookAuthor] ([BookAuthor_ID], [Book_ID], [Author_ID]) VALUES (9, 8, 6)
INSERT [dbo].[BookAuthor] ([BookAuthor_ID], [Book_ID], [Author_ID]) VALUES (10, 8, 7)
INSERT [dbo].[BookAuthor] ([BookAuthor_ID], [Book_ID], [Author_ID]) VALUES (11, 9, 5)
INSERT [dbo].[BookAuthor] ([BookAuthor_ID], [Book_ID], [Author_ID]) VALUES (12, 10, 5)
INSERT [dbo].[BookAuthor] ([BookAuthor_ID], [Book_ID], [Author_ID]) VALUES (13, 11, 8)
INSERT [dbo].[BookAuthor] ([BookAuthor_ID], [Book_ID], [Author_ID]) VALUES (14, 12, 8)
INSERT [dbo].[BookAuthor] ([BookAuthor_ID], [Book_ID], [Author_ID]) VALUES (18, 13, 16)
INSERT [dbo].[BookAuthor] ([BookAuthor_ID], [Book_ID], [Author_ID]) VALUES (19, 14, 16)
INSERT [dbo].[BookAuthor] ([BookAuthor_ID], [Book_ID], [Author_ID]) VALUES (30, 18, 18)
SET IDENTITY_INSERT [dbo].[BookAuthor] OFF
GO
ALTER TABLE [dbo].[BookAuthor]  WITH CHECK ADD  CONSTRAINT [FK_BookAuthor_Author] FOREIGN KEY([Author_ID])
REFERENCES [dbo].[Author] ([Author_ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[BookAuthor] CHECK CONSTRAINT [FK_BookAuthor_Author]
GO
ALTER TABLE [dbo].[BookAuthor]  WITH CHECK ADD  CONSTRAINT [FK_BookAuthor_Book] FOREIGN KEY([Book_ID])
REFERENCES [dbo].[Book] ([Book_ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[BookAuthor] CHECK CONSTRAINT [FK_BookAuthor_Book]
GO
