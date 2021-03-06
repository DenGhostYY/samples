USE [ChumakovLibrary]
GO
/****** Object:  StoredProcedure [dbo].[updateAuthor]    Script Date: 20.06.2021 11:30:08 ******/
DROP PROCEDURE [dbo].[updateAuthor]
GO
/****** Object:  StoredProcedure [dbo].[updateAuthor]    Script Date: 20.06.2021 11:30:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updateAuthor]
	@Author_ID int,
	@AuthorSurname varchar(50),
	@AuthorName varchar(50),
	@AuthorOtch varchar(50)
AS
BEGIN
	update Author set
		Author_Surname = @AuthorSurname,
		Author_Name = @AuthorName,
		Author_Otch = @AuthorOtch
	where Author_ID = @Author_ID
END
GO
