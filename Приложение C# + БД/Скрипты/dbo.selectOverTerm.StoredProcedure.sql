USE [ChumakovLibrary]
GO
/****** Object:  StoredProcedure [dbo].[selectOverTerm]    Script Date: 20.06.2021 11:30:08 ******/
DROP PROCEDURE [dbo].[selectOverTerm]
GO
/****** Object:  StoredProcedure [dbo].[selectOverTerm]    Script Date: 20.06.2021 11:30:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[selectOverTerm] 
	@nDays int
AS
BEGIN
	SET NOCOUNT ON;
	select Reader_ID, NumberTicket as [Номер билета],
		Reader_Surname as [Фамилия], Reader_Name as [Имя],
		Reader_Otch as [Отчество]
	from dbo.overTermReaders(@nDays)

	select i.Issue_ID, i.Reader_ID, e.Exemp_Number as [Номер экземпляра],
		b.Book_Name as [Название книги], i.Dat_Issue as [Дата выдачи],
		i.Dat_Return as [Дата возврата], i.Term as [Срок выдачи]
	from Issue i, Exemp e, Book b, dbo.overTermReaders(@nDays) d
	where d.Reader_ID = i.Reader_ID
		and i.Dat_Return is null
		and i.Exemp_ID = e.Exemp_ID
		and e.Book_ID = b.Book_ID
END
GO
