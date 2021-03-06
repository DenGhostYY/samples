USE [ChumakovLibrary]
GO
/****** Object:  StoredProcedure [dbo].[insertAuthor]    Script Date: 20.06.2021 11:30:08 ******/
DROP PROCEDURE [dbo].[insertAuthor]
GO
/****** Object:  StoredProcedure [dbo].[insertAuthor]    Script Date: 20.06.2021 11:30:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertAuthor]
	@AuthorSurname varchar(50),
	@AuthorName varchar(50),
	@AuthorOtch varchar(50)
AS
BEGIN
	insert into Author(Author_Surname, Author_Name, Author_Otch)
		values(@AuthorSurname, @AuthorName, @AuthorOtch)
END
GO
