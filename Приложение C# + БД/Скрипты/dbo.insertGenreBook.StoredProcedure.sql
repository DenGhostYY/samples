USE [ChumakovLibrary]
GO
/****** Object:  StoredProcedure [dbo].[insertGenreBook]    Script Date: 20.06.2021 11:30:08 ******/
DROP PROCEDURE [dbo].[insertGenreBook]
GO
/****** Object:  StoredProcedure [dbo].[insertGenreBook]    Script Date: 20.06.2021 11:30:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertGenreBook]
	@Book_ID int,
	@Genre_ID int
AS
BEGIN
	insert into GenreBook(Book_ID, Genre_ID)
		values(@Book_ID, @Genre_ID)
END
GO
