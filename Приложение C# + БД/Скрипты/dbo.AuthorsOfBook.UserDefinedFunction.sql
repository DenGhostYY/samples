USE [ChumakovLibrary]
GO
/****** Object:  UserDefinedFunction [dbo].[AuthorsOfBook]    Script Date: 20.06.2021 11:30:08 ******/
DROP FUNCTION [dbo].[AuthorsOfBook]
GO
/****** Object:  UserDefinedFunction [dbo].[AuthorsOfBook]    Script Date: 20.06.2021 11:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[AuthorsOfBook](@Book_ID int)
RETURNS varchar(max)
AS
BEGIN
	declare @result varchar(max)
	set @result = ''
	select @result = @result +
		a.Author_Surname + ' ' + left(a.Author_Name, 1) +
		'.' + isnull(left(a.Author_Otch,1) + '.', '') + ', '
	from BookAuthor ba, Author a
	where ba.Book_ID = @Book_ID
		and ba.Author_ID = a.Author_ID
	if LEN(@result) != 0
		set @result = SUBSTRING(@result, 1, LEN(@result) - 1)
	return @result
END
GO
