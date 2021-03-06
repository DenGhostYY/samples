USE [ChumakovLibrary]
GO
/****** Object:  StoredProcedure [dbo].[CHECK_PSW]    Script Date: 20.06.2021 11:30:08 ******/
DROP PROCEDURE [dbo].[CHECK_PSW]
GO
/****** Object:  StoredProcedure [dbo].[CHECK_PSW]    Script Date: 20.06.2021 11:30:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CHECK_PSW] 
	@login varchar(20), @psw varchar(20)
AS
BEGIN
	SET NOCOUNT ON;

	select r.Role_ID, r.LoginServ, r.PasswordServ
	from Role r
	where r.Role_ID = 2
		and r.LoginServ = @login
		and r.PasswordServ = @psw
	if @@ROWCOUNT = 0
		select r.Role_ID, r.LoginServ, r.PasswordServ, rd.Reader_ID,
			rd.Reader_Surname + ' ' + rd.Reader_Name +
				ISNULL(' ' + rd.Reader_Otch,''),
				rd.NumberTicket
		from Role r, Reader rd
		where r.Role_ID = 1
			and rd.Login = @login
			and rd.Password = @psw
	if @@ROWCOUNT = 0
		raiserror('Неверен логин или пароль', 16, 1)
END
GO
