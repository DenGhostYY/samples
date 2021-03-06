USE [ChumakovLibrary]
GO
/****** Object:  StoredProcedure [dbo].[deleteBook]    Script Date: 20.06.2021 11:30:08 ******/
DROP PROCEDURE [dbo].[deleteBook]
GO
/****** Object:  StoredProcedure [dbo].[deleteBook]    Script Date: 20.06.2021 11:30:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[deleteBook]
	@Book_ID int
AS
BEGIN
	begin tran
		if exists(
			select *
			from Issue i, Exemp e
			where e.Book_ID = @Book_ID
				and e.Exemp_ID = i.Exemp_ID
				and i.Dat_Return is null
		) begin
			rollback
			raiserror('Невозможно удалить книгу, так как экземпляр данной книги уже выдан', 16, 1)
			return
		end

		delete from GenreBook
		where Book_ID = @Book_ID

		delete from BookAuthor
		where Book_ID = @Book_ID

		delete from i
		from Issue i, Exemp e
		where e.Book_ID = @Book_ID
			and e.Exemp_ID = i.Exemp_ID

		delete from Exemp
		where Book_ID = @Book_ID
		
		delete from Book
		where Book_ID = @Book_ID
	commit
END
GO
