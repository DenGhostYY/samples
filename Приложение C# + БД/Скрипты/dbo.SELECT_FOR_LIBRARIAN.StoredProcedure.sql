USE [ChumakovLibrary]
GO
/****** Object:  StoredProcedure [dbo].[SELECT_FOR_LIBRARIAN]    Script Date: 20.06.2021 11:30:08 ******/
DROP PROCEDURE [dbo].[SELECT_FOR_LIBRARIAN]
GO
/****** Object:  StoredProcedure [dbo].[SELECT_FOR_LIBRARIAN]    Script Date: 20.06.2021 11:30:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SELECT_FOR_LIBRARIAN] 
AS
BEGIN
	SET NOCOUNT ON;
	select Genre_ID, Genre_Name as [Название жанра]
	from Genre

	select Author_ID, Author_Surname as [Фамилия],
		Author_Name as [Имя], Author_Otch as [Отчество]
	from Author

	select Book_ID, Book_Name as [Название книги],
		Authors as [Авторы книги], Genres as [Жанры книги]
	from Book

	select BookAuthor_ID, Book_ID, Author_ID
	from BookAuthor

	select GenreBook_ID, Book_ID, Genre_ID
	from GenreBook

	select e.Exemp_ID, e.Exemp_Number as [Номер экземпляра],
		b.Book_Name as [Название книги], b.Authors as [Авторы]
	from Exemp e, Book b
	where e.Book_ID = b.Book_ID

	select Reader_ID, NumberTicket as [Номер билета],
		Reader_Surname as [Фамилия], Reader_Name as [Имя],
		Reader_Otch as [Отчество], Login as [Логин]
	from Reader

	select i.Issue_ID, r.NumberTicket as [Номер билета],
		r.Reader_Surname + ' ' + left(r.Reader_Name, 1) +
			'.' + isnull(left(r.Reader_Otch, 1) + '.', '') as [Фамилия И.О.],
		e.Exemp_Number as [Номер экземпляра],
		b.Book_Name as [Название книги],
		i.Dat_Issue as [Дата выдачи],
		i.Dat_Return as [Дата возврата],
		i.Term as [Срок выдачи]
	from Issue i, Reader r, Exemp e, Book b
	where i.Reader_ID = r.Reader_ID
		and i.Exemp_ID = e.Exemp_ID
		and e.Book_ID = b.Book_ID

	--свободные экземпляры
	select e.Exemp_ID, e.Exemp_Number as [Номер экземпляра], e.Book_ID
	from Exemp e
	where not exists(
		select *
		from Issue i
	where i.Exemp_ID = e.Exemp_ID
		and i.Dat_Return is null
)
END
GO
