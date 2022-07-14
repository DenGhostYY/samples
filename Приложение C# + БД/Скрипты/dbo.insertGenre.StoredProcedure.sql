USE [ChumakovLibrary]
GO
/****** Object:  StoredProcedure [dbo].[insertGenre]    Script Date: 20.06.2021 11:30:08 ******/
DROP PROCEDURE [dbo].[insertGenre]
GO
/****** Object:  StoredProcedure [dbo].[insertGenre]    Script Date: 20.06.2021 11:30:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertGenre]
	@GenreName varchar(70)
AS
BEGIN
	insert into Genre(Genre_Name) values(@GenreName)
END
GO
