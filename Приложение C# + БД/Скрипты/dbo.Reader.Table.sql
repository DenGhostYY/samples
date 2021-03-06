USE [ChumakovLibrary]
GO
ALTER TABLE [dbo].[Reader] DROP CONSTRAINT [DF_Reader_Password]
GO
ALTER TABLE [dbo].[Reader] DROP CONSTRAINT [DF_Reader_Reader_ID]
GO
/****** Object:  Index [NonClusteredIndex-20210522-120849]    Script Date: 20.06.2021 11:30:08 ******/
DROP INDEX [NonClusteredIndex-20210522-120849] ON [dbo].[Reader]
GO
/****** Object:  Index [NonClusteredIndex-20210522-120829]    Script Date: 20.06.2021 11:30:08 ******/
DROP INDEX [NonClusteredIndex-20210522-120829] ON [dbo].[Reader]
GO
/****** Object:  Table [dbo].[Reader]    Script Date: 20.06.2021 11:30:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reader]') AND type in (N'U'))
DROP TABLE [dbo].[Reader]
GO
/****** Object:  Table [dbo].[Reader]    Script Date: 20.06.2021 11:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reader](
	[Reader_ID] [uniqueidentifier] NOT NULL,
	[Reader_Surname] [varchar](50) NOT NULL,
	[Reader_Name] [varchar](50) NOT NULL,
	[Reader_Otch] [varchar](50) NULL,
	[NumberTicket] [int] NOT NULL,
	[Login] [varchar](20) NOT NULL,
	[Password] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Reader] PRIMARY KEY CLUSTERED 
(
	[Reader_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Reader] ([Reader_ID], [Reader_Surname], [Reader_Name], [Reader_Otch], [NumberTicket], [Login], [Password]) VALUES (N'4546a416-1d80-460b-b845-b8bc1aa8359a', N'Сидоров', N'Василий', N'Петрович', 4, N'vasya', N'vasya')
INSERT [dbo].[Reader] ([Reader_ID], [Reader_Surname], [Reader_Name], [Reader_Otch], [NumberTicket], [Login], [Password]) VALUES (N'60340a94-63b3-440c-9562-bea67c9bd233', N'Чумаков', N'Денис', N'Павлович', 1, N'denis', N'denis')
INSERT [dbo].[Reader] ([Reader_ID], [Reader_Surname], [Reader_Name], [Reader_Otch], [NumberTicket], [Login], [Password]) VALUES (N'a9831d98-48dc-4aca-9463-c4f88f7f3d05', N'Дундева', N'Елена', N'Викторона', 5, N'elena', N'elena')
INSERT [dbo].[Reader] ([Reader_ID], [Reader_Surname], [Reader_Name], [Reader_Otch], [NumberTicket], [Login], [Password]) VALUES (N'c81392a7-c80a-4300-bb1d-e472aa94f83e', N'Иванов', N'Иван', N'Иванович', 2, N'ivan', N'ivan')
INSERT [dbo].[Reader] ([Reader_ID], [Reader_Surname], [Reader_Name], [Reader_Otch], [NumberTicket], [Login], [Password]) VALUES (N'cb44cea5-4ee5-40d4-a7e3-f1f77daa3b05', N'Гаррисон', N'Стюарт', NULL, 3, N'stuart', N'stuart')
GO
/****** Object:  Index [NonClusteredIndex-20210522-120829]    Script Date: 20.06.2021 11:30:18 ******/
CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex-20210522-120829] ON [dbo].[Reader]
(
	[NumberTicket] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex-20210522-120849]    Script Date: 20.06.2021 11:30:18 ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20210522-120849] ON [dbo].[Reader]
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Reader] ADD  CONSTRAINT [DF_Reader_Reader_ID]  DEFAULT (newid()) FOR [Reader_ID]
GO
ALTER TABLE [dbo].[Reader] ADD  CONSTRAINT [DF_Reader_Password]  DEFAULT ((123)) FOR [Password]
GO
