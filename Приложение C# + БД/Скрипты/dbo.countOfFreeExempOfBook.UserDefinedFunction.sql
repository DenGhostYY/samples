USE [ChumakovLibrary]
GO
/****** Object:  UserDefinedFunction [dbo].[countOfFreeExempOfBook]    Script Date: 20.06.2021 11:30:08 ******/
DROP FUNCTION [dbo].[countOfFreeExempOfBook]
GO
/****** Object:  UserDefinedFunction [dbo].[countOfFreeExempOfBook]    Script Date: 20.06.2021 11:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[countOfFreeExempOfBook](@Book_ID int) 
RETURNS int
AS
BEGIN
	DECLARE @result int

	SELECT @result = ISNULL(COUNT(Exemp_ID), 0)
	from dbo.FreeExempOfBook(@Book_ID)
	
	RETURN @result
END
GO
