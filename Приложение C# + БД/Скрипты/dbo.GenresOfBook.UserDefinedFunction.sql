USE [ChumakovLibrary]
GO
/****** Object:  UserDefinedFunction [dbo].[GenresOfBook]    Script Date: 20.06.2021 11:30:08 ******/
DROP FUNCTION [dbo].[GenresOfBook]
GO
/****** Object:  UserDefinedFunction [dbo].[GenresOfBook]    Script Date: 20.06.2021 11:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GenresOfBook](@Book_ID int)
RETURNS varchar(max)
AS
BEGIN
	declare @result varchar(max)
	set @result = ''
	select @result = @result + g.Genre_Name + ', '
	from GenreBook gb, Genre g
	where gb.Book_ID = @Book_ID
		and gb.Genre_ID = g.Genre_ID
	if LEN(@result) != 0
		set @result = SUBSTRING(@result, 1, LEN(@result) - 1)
	return @result
END
GO
