USE [ChumakovLibrary]
GO
/****** Object:  StoredProcedure [dbo].[deleteGenreBook]    Script Date: 20.06.2021 11:30:08 ******/
DROP PROCEDURE [dbo].[deleteGenreBook]
GO
/****** Object:  StoredProcedure [dbo].[deleteGenreBook]    Script Date: 20.06.2021 11:30:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[deleteGenreBook]
	@Book_ID int,
	@Genre_ID int
AS
BEGIN
	delete from GenreBook
	where Book_ID = @Book_ID
		and Genre_ID = @Genre_ID
END
GO
