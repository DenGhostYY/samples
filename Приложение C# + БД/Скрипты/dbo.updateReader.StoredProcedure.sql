USE [ChumakovLibrary]
GO
/****** Object:  StoredProcedure [dbo].[updateReader]    Script Date: 20.06.2021 11:30:08 ******/
DROP PROCEDURE [dbo].[updateReader]
GO
/****** Object:  StoredProcedure [dbo].[updateReader]    Script Date: 20.06.2021 11:30:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updateReader]
	@Reader_ID uniqueidentifier,
	@ReaderSurname varchar(50),
	@ReaderName varchar(50),
	@ReaderOtch varchar(50),
	@NumberTicket int,
	@Login varchar(20)
AS
BEGIN
	update Reader set
		Reader_Surname = @ReaderSurname,
		Reader_Name = @ReaderName,
		Reader_Otch = @ReaderOtch,
		NumberTicket = @NumberTicket,
		Login = @Login
	where Reader_ID = @Reader_ID
END
GO
