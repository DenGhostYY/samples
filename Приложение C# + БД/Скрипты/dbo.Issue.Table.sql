USE [ChumakovLibrary]
GO
ALTER TABLE [dbo].[Issue] DROP CONSTRAINT [FK_Issue_Reader]
GO
ALTER TABLE [dbo].[Issue] DROP CONSTRAINT [FK_Issue_Exemp]
GO
ALTER TABLE [dbo].[Issue] DROP CONSTRAINT [DF_Issue_Term]
GO
/****** Object:  Table [dbo].[Issue]    Script Date: 20.06.2021 11:30:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Issue]') AND type in (N'U'))
DROP TABLE [dbo].[Issue]
GO
/****** Object:  Table [dbo].[Issue]    Script Date: 20.06.2021 11:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Issue](
	[Issue_ID] [int] IDENTITY(1,1) NOT NULL,
	[Reader_ID] [uniqueidentifier] NOT NULL,
	[Exemp_ID] [int] NOT NULL,
	[Dat_Issue] [date] NOT NULL,
	[Dat_Return] [date] NULL,
	[Term] [int] NOT NULL,
 CONSTRAINT [PK_Issue] PRIMARY KEY CLUSTERED 
(
	[Issue_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Issue] ON 

INSERT [dbo].[Issue] ([Issue_ID], [Reader_ID], [Exemp_ID], [Dat_Issue], [Dat_Return], [Term]) VALUES (1, N'60340a94-63b3-440c-9562-bea67c9bd233', 6, CAST(N'2020-10-01' AS Date), CAST(N'2020-10-19' AS Date), 20)
INSERT [dbo].[Issue] ([Issue_ID], [Reader_ID], [Exemp_ID], [Dat_Issue], [Dat_Return], [Term]) VALUES (3, N'cb44cea5-4ee5-40d4-a7e3-f1f77daa3b05', 7, CAST(N'2020-10-04' AS Date), CAST(N'2020-10-08' AS Date), 20)
INSERT [dbo].[Issue] ([Issue_ID], [Reader_ID], [Exemp_ID], [Dat_Issue], [Dat_Return], [Term]) VALUES (4, N'4546a416-1d80-460b-b845-b8bc1aa8359a', 15, CAST(N'2020-10-07' AS Date), CAST(N'2020-10-08' AS Date), 20)
INSERT [dbo].[Issue] ([Issue_ID], [Reader_ID], [Exemp_ID], [Dat_Issue], [Dat_Return], [Term]) VALUES (5, N'60340a94-63b3-440c-9562-bea67c9bd233', 16, CAST(N'2020-11-25' AS Date), CAST(N'2021-06-20' AS Date), 20)
INSERT [dbo].[Issue] ([Issue_ID], [Reader_ID], [Exemp_ID], [Dat_Issue], [Dat_Return], [Term]) VALUES (6, N'cb44cea5-4ee5-40d4-a7e3-f1f77daa3b05', 4, CAST(N'2020-11-28' AS Date), NULL, 20)
INSERT [dbo].[Issue] ([Issue_ID], [Reader_ID], [Exemp_ID], [Dat_Issue], [Dat_Return], [Term]) VALUES (7, N'4546a416-1d80-460b-b845-b8bc1aa8359a', 8, CAST(N'2020-12-07' AS Date), NULL, 20)
INSERT [dbo].[Issue] ([Issue_ID], [Reader_ID], [Exemp_ID], [Dat_Issue], [Dat_Return], [Term]) VALUES (10, N'a9831d98-48dc-4aca-9463-c4f88f7f3d05', 26, CAST(N'2021-06-15' AS Date), NULL, 20)
SET IDENTITY_INSERT [dbo].[Issue] OFF
GO
ALTER TABLE [dbo].[Issue] ADD  CONSTRAINT [DF_Issue_Term]  DEFAULT ((20)) FOR [Term]
GO
ALTER TABLE [dbo].[Issue]  WITH CHECK ADD  CONSTRAINT [FK_Issue_Exemp] FOREIGN KEY([Exemp_ID])
REFERENCES [dbo].[Exemp] ([Exemp_ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Issue] CHECK CONSTRAINT [FK_Issue_Exemp]
GO
ALTER TABLE [dbo].[Issue]  WITH CHECK ADD  CONSTRAINT [FK_Issue_Reader] FOREIGN KEY([Reader_ID])
REFERENCES [dbo].[Reader] ([Reader_ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Issue] CHECK CONSTRAINT [FK_Issue_Reader]
GO
