USE [ChumakovLibrary]
GO
/****** Object:  StoredProcedure [dbo].[deleteIssue]    Script Date: 20.06.2021 11:30:08 ******/
DROP PROCEDURE [dbo].[deleteIssue]
GO
/****** Object:  StoredProcedure [dbo].[deleteIssue]    Script Date: 20.06.2021 11:30:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[deleteIssue]
	@Issue_ID int
AS
BEGIN
	begin tran
		begin try
			delete from Issue
			where Issue_ID = @Issue_ID
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
