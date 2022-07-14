USE [ChumakovLibrary]
GO
/****** Object:  StoredProcedure [dbo].[insertExemp]    Script Date: 20.06.2021 11:30:08 ******/
DROP PROCEDURE [dbo].[insertExemp]
GO
/****** Object:  StoredProcedure [dbo].[insertExemp]    Script Date: 20.06.2021 11:30:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertExemp]
	@Exemp_Number int,
	@Book_ID int
AS
BEGIN
	insert into Exemp(Exemp_Number, Book_ID)
		values(@Exemp_Number, @Book_ID)
END
GO
