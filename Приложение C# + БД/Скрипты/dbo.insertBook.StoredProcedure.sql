USE [ChumakovLibrary]
GO
/****** Object:  StoredProcedure [dbo].[insertBook]    Script Date: 20.06.2021 11:30:08 ******/
DROP PROCEDURE [dbo].[insertBook]
GO
/****** Object:  StoredProcedure [dbo].[insertBook]    Script Date: 20.06.2021 11:30:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertBook]
	@BookName varchar(70)
AS
BEGIN
	insert into Book(Book_Name) output inserted.Book_ID values (@BookName)
END
GO
