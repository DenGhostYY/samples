USE [ChumakovLibrary]
GO
/****** Object:  StoredProcedure [dbo].[insertIssue]    Script Date: 20.06.2021 11:30:08 ******/
DROP PROCEDURE [dbo].[insertIssue]
GO
/****** Object:  StoredProcedure [dbo].[insertIssue]    Script Date: 20.06.2021 11:30:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertIssue]
	@ReaderID uniqueidentifier,
	@ExempID int,
	@DatIssue date,
	@Term int
AS
BEGIN
	begin tran
		begin try
			insert into Issue(Reader_ID, Exemp_ID, Dat_Issue, Term)
				values(@ReaderID, @ExempID, @DatIssue, @Term)
			commit
		end try
		begin catch
			rollback
			declare @mes varchar(max)
			set @mes = ERROR_MESSAGE()
			raiserror(@mes, 16, 1)
		end catch
END
GO
