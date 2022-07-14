USE [ChumakovLibrary]
GO
/****** Object:  StoredProcedure [dbo].[deleteGenre]    Script Date: 20.06.2021 11:30:08 ******/
DROP PROCEDURE [dbo].[deleteGenre]
GO
/****** Object:  StoredProcedure [dbo].[deleteGenre]    Script Date: 20.06.2021 11:30:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[deleteGenre]
	@Genre_ID int
AS
BEGIN
	delete from GenreBook
	where Genre_ID = @Genre_ID

	delete from Genre
	where Genre_ID = @Genre_ID
END
GO
