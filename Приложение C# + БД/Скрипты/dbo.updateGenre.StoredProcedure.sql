USE [ChumakovLibrary]
GO
/****** Object:  StoredProcedure [dbo].[updateGenre]    Script Date: 20.06.2021 11:30:08 ******/
DROP PROCEDURE [dbo].[updateGenre]
GO
/****** Object:  StoredProcedure [dbo].[updateGenre]    Script Date: 20.06.2021 11:30:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updateGenre]
	@Genre_ID int,
	@GenreName varchar(70)
AS
BEGIN
	update Genre set
		Genre_Name = @GenreName
	where Genre_ID = @Genre_ID
END
GO
