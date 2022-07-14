USE [ChumakovLibrary]
GO
/****** Object:  UserDefinedFunction [dbo].[GetIdBookByIdExemp]    Script Date: 20.06.2021 11:30:08 ******/
DROP FUNCTION [dbo].[GetIdBookByIdExemp]
GO
/****** Object:  UserDefinedFunction [dbo].[GetIdBookByIdExemp]    Script Date: 20.06.2021 11:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetIdBookByIdExemp] 
(
	@Exemp_ID int
)
RETURNS int
AS
BEGIN
	DECLARE @result int

	SELECT @result = Book_ID
	from Exemp
	where Exemp_ID = @Exemp_ID

	RETURN @result
END
GO
