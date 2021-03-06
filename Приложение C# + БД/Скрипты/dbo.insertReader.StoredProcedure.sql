USE [ChumakovLibrary]
GO
/****** Object:  StoredProcedure [dbo].[insertReader]    Script Date: 20.06.2021 11:30:08 ******/
DROP PROCEDURE [dbo].[insertReader]
GO
/****** Object:  StoredProcedure [dbo].[insertReader]    Script Date: 20.06.2021 11:30:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertReader]
	@ReaderSurname varchar(50),
	@ReaderName varchar(50),
	@ReaderOtch varchar(50),
	@NumberTicket int,
	@Login varchar(20)
AS
BEGIN
	insert into Reader(Reader_Surname, Reader_Name,
			Reader_Otch, NumberTicket, Login)
		values(@ReaderSurname, @ReaderName,
			@ReaderOtch, @NumberTicket, @Login)
END
GO
