USE [ChumakovLibrary]
GO
ALTER TABLE [dbo].[Exemp] DROP CONSTRAINT [FK_Exemp_Book]
GO
/****** Object:  Index [NonClusteredIndex-20210520-162736]    Script Date: 20.06.2021 11:30:08 ******/
DROP INDEX [NonClusteredIndex-20210520-162736] ON [dbo].[Exemp]
GO
/****** Object:  Table [dbo].[Exemp]    Script Date: 20.06.2021 11:30:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Exemp]') AND type in (N'U'))
DROP TABLE [dbo].[Exemp]
GO
/****** Object:  Table [dbo].[Exemp]    Script Date: 20.06.2021 11:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exemp](
	[Exemp_ID] [int] IDENTITY(1,1) NOT NULL,
	[Book_ID] [int] NOT NULL,
	[Exemp_Number] [int] NOT NULL,
 CONSTRAINT [PK_Exemp] PRIMARY KEY CLUSTERED 
(
	[Exemp_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Exemp] ON 

INSERT [dbo].[Exemp] ([Exemp_ID], [Book_ID], [Exemp_Number]) VALUES (1, 1, 1)
INSERT [dbo].[Exemp] ([Exemp_ID], [Book_ID], [Exemp_Number]) VALUES (2, 1, 2)
INSERT [dbo].[Exemp] ([Exemp_ID], [Book_ID], [Exemp_Number]) VALUES (3, 3, 3)
INSERT [dbo].[Exemp] ([Exemp_ID], [Book_ID], [Exemp_Number]) VALUES (4, 2, 4)
INSERT [dbo].[Exemp] ([Exemp_ID], [Book_ID], [Exemp_Number]) VALUES (6, 2, 5)
INSERT [dbo].[Exemp] ([Exemp_ID], [Book_ID], [Exemp_Number]) VALUES (7, 6, 6)
INSERT [dbo].[Exemp] ([Exemp_ID], [Book_ID], [Exemp_Number]) VALUES (8, 2, 7)
INSERT [dbo].[Exemp] ([Exemp_ID], [Book_ID], [Exemp_Number]) VALUES (9, 7, 8)
INSERT [dbo].[Exemp] ([Exemp_ID], [Book_ID], [Exemp_Number]) VALUES (11, 5, 10)
INSERT [dbo].[Exemp] ([Exemp_ID], [Book_ID], [Exemp_Number]) VALUES (12, 8, 11)
INSERT [dbo].[Exemp] ([Exemp_ID], [Book_ID], [Exemp_Number]) VALUES (13, 9, 12)
INSERT [dbo].[Exemp] ([Exemp_ID], [Book_ID], [Exemp_Number]) VALUES (14, 10, 13)
INSERT [dbo].[Exemp] ([Exemp_ID], [Book_ID], [Exemp_Number]) VALUES (15, 11, 14)
INSERT [dbo].[Exemp] ([Exemp_ID], [Book_ID], [Exemp_Number]) VALUES (16, 12, 15)
INSERT [dbo].[Exemp] ([Exemp_ID], [Book_ID], [Exemp_Number]) VALUES (17, 13, 16)
INSERT [dbo].[Exemp] ([Exemp_ID], [Book_ID], [Exemp_Number]) VALUES (18, 14, 17)
INSERT [dbo].[Exemp] ([Exemp_ID], [Book_ID], [Exemp_Number]) VALUES (19, 9, 18)
INSERT [dbo].[Exemp] ([Exemp_ID], [Book_ID], [Exemp_Number]) VALUES (20, 14, 19)
INSERT [dbo].[Exemp] ([Exemp_ID], [Book_ID], [Exemp_Number]) VALUES (21, 6, 20)
INSERT [dbo].[Exemp] ([Exemp_ID], [Book_ID], [Exemp_Number]) VALUES (22, 11, 21)
INSERT [dbo].[Exemp] ([Exemp_ID], [Book_ID], [Exemp_Number]) VALUES (25, 4, 9)
INSERT [dbo].[Exemp] ([Exemp_ID], [Book_ID], [Exemp_Number]) VALUES (26, 18, 22)
SET IDENTITY_INSERT [dbo].[Exemp] OFF
GO
/****** Object:  Index [NonClusteredIndex-20210520-162736]    Script Date: 20.06.2021 11:30:18 ******/
CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex-20210520-162736] ON [dbo].[Exemp]
(
	[Exemp_Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Exemp]  WITH CHECK ADD  CONSTRAINT [FK_Exemp_Book] FOREIGN KEY([Book_ID])
REFERENCES [dbo].[Book] ([Book_ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Exemp] CHECK CONSTRAINT [FK_Exemp_Book]
GO
