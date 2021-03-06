USE [ChumakovLibrary]
GO
/****** Object:  StoredProcedure [dbo].[deleteBookAuthor]    Script Date: 20.06.2021 11:30:08 ******/
DROP PROCEDURE [dbo].[deleteBookAuthor]
GO
/****** Object:  StoredProcedure [dbo].[deleteBookAuthor]    Script Date: 20.06.2021 11:30:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[deleteBookAuthor]
	@Book_ID int,
	@Author_ID int
AS
BEGIN
	delete from BookAuthor
	where Book_ID = @Book_ID
		and Author_ID = @Author_ID
END
GO
