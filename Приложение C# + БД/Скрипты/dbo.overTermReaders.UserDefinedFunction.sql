USE [ChumakovLibrary]
GO
/****** Object:  UserDefinedFunction [dbo].[overTermReaders]    Script Date: 20.06.2021 11:30:08 ******/
DROP FUNCTION [dbo].[overTermReaders]
GO
/****** Object:  UserDefinedFunction [dbo].[overTermReaders]    Script Date: 20.06.2021 11:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[overTermReaders](@nDays int)
returns @result table(
	Reader_ID uniqueidentifier not null,
	NumberTicket int not null,
	Reader_Surname varchar(50) not null,
	Reader_Name varchar(50) not null,
	Reader_Otch varchar(50) null
)
AS
BEGIN
	insert into @result(Reader_ID, NumberTicket, Reader_Surname, Reader_Name, Reader_Otch)
	select distinct r.Reader_ID, r.NumberTicket, r.Reader_Surname, r.Reader_Name, r.Reader_Otch
	from Reader r, Issue i
	where i.Reader_ID = r.Reader_ID
		and i.Dat_Return is null
		and DATEDIFF(DAY, DATEADD(DAY, @nDays, i.Dat_Issue), getdate()) > 0
	return
END
GO
