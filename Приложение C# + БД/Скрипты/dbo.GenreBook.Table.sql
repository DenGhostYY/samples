USE [ChumakovLibrary]
GO
ALTER TABLE [dbo].[GenreBook] DROP CONSTRAINT [FK_GenreBook_Genre]
GO
ALTER TABLE [dbo].[GenreBook] DROP CONSTRAINT [FK_GenreBook_Book]
GO
/****** Object:  Table [dbo].[GenreBook]    Script Date: 20.06.2021 11:30:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GenreBook]') AND type in (N'U'))
DROP TABLE [dbo].[GenreBook]
GO
/****** Object:  Table [dbo].[GenreBook]    Script Date: 20.06.2021 11:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GenreBook](
	[GenreBook_ID] [int] IDENTITY(1,1) NOT NULL,
	[Genre_ID] [int] NOT NULL,
	[Book_ID] [int] NOT NULL,
 CONSTRAINT [PK_GenreBook] PRIMARY KEY CLUSTERED 
(
	[GenreBook_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[GenreBook] ON 

INSERT [dbo].[GenreBook] ([GenreBook_ID], [Genre_ID], [Book_ID]) VALUES (4, 10, 18)
SET IDENTITY_INSERT [dbo].[GenreBook] OFF
GO
ALTER TABLE [dbo].[GenreBook]  WITH CHECK ADD  CONSTRAINT [FK_GenreBook_Book] FOREIGN KEY([Book_ID])
REFERENCES [dbo].[Book] ([Book_ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[GenreBook] CHECK CONSTRAINT [FK_GenreBook_Book]
GO
ALTER TABLE [dbo].[GenreBook]  WITH CHECK ADD  CONSTRAINT [FK_GenreBook_Genre] FOREIGN KEY([Genre_ID])
REFERENCES [dbo].[Genre] ([Genre_ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[GenreBook] CHECK CONSTRAINT [FK_GenreBook_Genre]
GO
