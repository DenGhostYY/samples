USE [ChumakovLibrary]
GO
/****** Object:  StoredProcedure [dbo].[insertBookAuthor]    Script Date: 20.06.2021 11:30:08 ******/
DROP PROCEDURE [dbo].[insertBookAuthor]
GO
/****** Object:  StoredProcedure [dbo].[insertBookAuthor]    Script Date: 20.06.2021 11:30:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertBookAuthor]
	@Book_ID int,
	@Author_ID int
AS
BEGIN
	insert into BookAuthor(Book_ID, Author_ID)
		values(@Book_ID, @Author_ID)
END
GO
