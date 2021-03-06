USE [ChumakovLibrary]
GO
/****** Object:  UserDefinedFunction [dbo].[trendOfBooks]    Script Date: 20.06.2021 11:30:08 ******/
DROP FUNCTION [dbo].[trendOfBooks]
GO
/****** Object:  UserDefinedFunction [dbo].[trendOfBooks]    Script Date: 20.06.2021 11:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[trendOfBooks](@nDays int)
returns @result table(
	Book_Name varchar(70) not null,
	Authors varchar(max) null,
	countOf int null
)
AS
BEGIN
	insert into @result(Book_Name, Authors, countOf)
	select top 10 b.Book_Name, b.Authors, count(*) as countOf
	from Book b, Exemp e, Issue i
	where i.Exemp_ID = e.Exemp_ID
		and e.Book_ID = b.Book_ID
		and DATEDIFF(DAY, getdate(), DATEADD(DAY, @nDays, i.Dat_Issue)) >= 0
	group by b.Book_Name, b.Authors
	order by countOf desc
	return 
END
GO
