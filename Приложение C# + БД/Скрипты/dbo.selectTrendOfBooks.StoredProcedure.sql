USE [ChumakovLibrary]
GO
/****** Object:  StoredProcedure [dbo].[selectTrendOfBooks]    Script Date: 20.06.2021 11:30:08 ******/
DROP PROCEDURE [dbo].[selectTrendOfBooks]
GO
/****** Object:  StoredProcedure [dbo].[selectTrendOfBooks]    Script Date: 20.06.2021 11:30:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[selectTrendOfBooks] 
	@nDays int
AS
BEGIN
	SET NOCOUNT ON;
	select Book_Name as [Название книги], Authors as [Авторы],
		countOf as [Сколько раз выдана]
    from dbo.trendOfBooks(@nDays)
END
GO
