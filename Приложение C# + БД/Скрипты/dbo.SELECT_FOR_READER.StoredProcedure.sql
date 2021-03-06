USE [ChumakovLibrary]
GO
/****** Object:  StoredProcedure [dbo].[SELECT_FOR_READER]    Script Date: 20.06.2021 11:30:08 ******/
DROP PROCEDURE [dbo].[SELECT_FOR_READER]
GO
/****** Object:  StoredProcedure [dbo].[SELECT_FOR_READER]    Script Date: 20.06.2021 11:30:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SELECT_FOR_READER] 
	@Reader_ID uniqueidentifier
AS
BEGIN
	SET NOCOUNT ON;

	select b.Book_ID, b.Book_Name as [Название книги],
		b.Authors as [Авторы], b.Genres as [Жанры], ce.countOf as [Количество]
	from countOfFreeExemp ce, Book b
	where ce.Book_ID = b.Book_ID
	order by ce.countOf desc

	select i.Issue_ID, e.Exemp_Number as [Номер экземпляра],
		b.Book_Name as [Название книги],
		DATEADD(day, i.Term, i.Dat_Issue) as [Вернуть до]
	from Issue i, Exemp e, Book b
	where i.Reader_ID = @Reader_ID
		and i.Dat_Return is null
		and i.Exemp_ID = e.Exemp_ID
		and e.Book_ID = b.Book_ID
END
GO
