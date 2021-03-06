USE [ChumakovLibrary]
GO
/****** Object:  StoredProcedure [dbo].[CHANGE_PSW]    Script Date: 21.06.2021 0:47:03 ******/
DROP PROCEDURE [dbo].[CHANGE_PSW]
GO
/****** Object:  StoredProcedure [dbo].[CHANGE_PSW]    Script Date: 21.06.2021 0:47:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CHANGE_PSW] 
	@numberTicket int,
	@oldPsw varchar(20),
	@newPsw varchar(20)
AS
BEGIN
	declare @checkPassword varchar(20)
	select @checkPassword = r.Password
	from Reader r
	where r.NumberTicket = @numberTicket

	if @checkPassword != @oldPsw begin
		raiserror('Старый пароль неверный', 16, 1)
		return
	end

	update Reader set
		Password = @newPsw
	where NumberTicket = @numberTicket
END
GO
