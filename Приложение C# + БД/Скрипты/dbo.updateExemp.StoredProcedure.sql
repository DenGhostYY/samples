USE [ChumakovLibrary]
GO
/****** Object:  StoredProcedure [dbo].[updateExemp]    Script Date: 20.06.2021 11:30:08 ******/
DROP PROCEDURE [dbo].[updateExemp]
GO
/****** Object:  StoredProcedure [dbo].[updateExemp]    Script Date: 20.06.2021 11:30:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updateExemp]
	@Exemp_ID int,
	@Exemp_Number int,
	@Book_ID int
AS
BEGIN
	update Exemp set
		Exemp_Number = @Exemp_Number,
		Book_ID = @Book_ID
	where Exemp_ID = @Exemp_ID
END
GO
