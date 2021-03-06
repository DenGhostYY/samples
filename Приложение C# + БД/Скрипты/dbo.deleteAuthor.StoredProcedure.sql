USE [ChumakovLibrary]
GO
/****** Object:  StoredProcedure [dbo].[deleteAuthor]    Script Date: 20.06.2021 11:30:08 ******/
DROP PROCEDURE [dbo].[deleteAuthor]
GO
/****** Object:  StoredProcedure [dbo].[deleteAuthor]    Script Date: 20.06.2021 11:30:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[deleteAuthor]
	@Author_ID int
AS
BEGIN
	delete from BookAuthor
	where Author_ID = @Author_ID

	delete from Author
	where Author_ID = @Author_ID
END
GO
