USE [ChumakovLibrary]
GO
/****** Object:  StoredProcedure [dbo].[deleteReader]    Script Date: 20.06.2021 11:30:08 ******/
DROP PROCEDURE [dbo].[deleteReader]
GO
/****** Object:  StoredProcedure [dbo].[deleteReader]    Script Date: 20.06.2021 11:30:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[deleteReader]
	@Reader_ID uniqueidentifier
AS
BEGIN
	begin tran
		if exists(
			select *
			from Issue i
			where i.Reader_ID = @Reader_ID
				and i.Dat_Return is null
		) begin
			rollback
			raiserror('Невозможно удалить читателя, так как у него есть выданный экземпляр', 16, 1)
			return
		end

		delete from i
		from Issue i
		where i.Reader_ID = @Reader_ID

		delete from Reader
		where Reader_ID = @Reader_ID
	commit
END
GO
