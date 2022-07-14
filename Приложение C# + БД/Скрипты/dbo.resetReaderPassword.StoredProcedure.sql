USE [ChumakovLibrary]
GO
/****** Object:  StoredProcedure [dbo].[resetReaderPassword]    Script Date: 20.06.2021 11:30:08 ******/
DROP PROCEDURE [dbo].[resetReaderPassword]
GO
/****** Object:  StoredProcedure [dbo].[resetReaderPassword]    Script Date: 20.06.2021 11:30:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[resetReaderPassword]
	@Reader_ID uniqueidentifier
AS
BEGIN
	update Reader set
		Password = '123'
	where Reader_ID = @Reader_ID
END
GO
