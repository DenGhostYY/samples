USE [ChumakovLibrary]
GO
/****** Object:  Index [NonClusteredIndex-20210522-115633]    Script Date: 20.06.2021 11:30:08 ******/
DROP INDEX [NonClusteredIndex-20210522-115633] ON [dbo].[Role]
GO
/****** Object:  Index [NonClusteredIndex-20210522-115615]    Script Date: 20.06.2021 11:30:08 ******/
DROP INDEX [NonClusteredIndex-20210522-115615] ON [dbo].[Role]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 20.06.2021 11:30:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Role]') AND type in (N'U'))
DROP TABLE [dbo].[Role]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 20.06.2021 11:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Role_ID] [int] IDENTITY(1,1) NOT NULL,
	[Role_Name] [varchar](20) NOT NULL,
	[LoginServ] [varchar](20) NOT NULL,
	[PasswordServ] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Role_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Role_ID], [Role_Name], [LoginServ], [PasswordServ]) VALUES (1, N'Читатель', N'operator', N'operator')
INSERT [dbo].[Role] ([Role_ID], [Role_Name], [LoginServ], [PasswordServ]) VALUES (2, N'Библиотекарь', N'manager', N'manager')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex-20210522-115615]    Script Date: 20.06.2021 11:30:18 ******/
CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex-20210522-115615] ON [dbo].[Role]
(
	[Role_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex-20210522-115633]    Script Date: 20.06.2021 11:30:18 ******/
CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex-20210522-115633] ON [dbo].[Role]
(
	[LoginServ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
