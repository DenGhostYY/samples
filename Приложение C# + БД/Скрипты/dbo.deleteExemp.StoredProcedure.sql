USE [ChumakovLibrary]
GO
/****** Object:  StoredProcedure [dbo].[deleteExemp]    Script Date: 20.06.2021 11:30:08 ******/
DROP PROCEDURE [dbo].[deleteExemp]
GO
/****** Object:  StoredProcedure [dbo].[deleteExemp]    Script Date: 20.06.2021 11:30:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[deleteExemp]
	@Exemp_ID int
AS
BEGIN
	begin tran
		if exists(
			select *
			from Issue i
			where i.Exemp_ID = @Exemp_ID
				and i.Dat_Return is null
		) begin
			rollback
			raiserror('Невозможно удалить экземпляр, так как он уже выдан', 16, 1)
			return
		end

		delete from i
		from Issue i
		where i.Exemp_ID = @Exemp_ID

		delete from Exemp
		where Exemp_ID = @Exemp_ID
	commit
END
GO
