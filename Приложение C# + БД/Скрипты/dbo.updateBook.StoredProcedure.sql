USE [ChumakovLibrary]
GO
/****** Object:  StoredProcedure [dbo].[updateBook]    Script Date: 20.06.2021 11:30:08 ******/
DROP PROCEDURE [dbo].[updateBook]
GO
/****** Object:  StoredProcedure [dbo].[updateBook]    Script Date: 20.06.2021 11:30:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updateBook]
	@Book_ID int,
	@BookName varchar(70)
AS
BEGIN
	update Book set
		Book_Name = @BookName
	where Book_ID = @Book_ID
END
GO
