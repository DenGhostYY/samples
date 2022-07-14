USE [ChumakovLibrary]
GO
/****** Object:  StoredProcedure [dbo].[updateIssue]    Script Date: 20.06.2021 11:30:08 ******/
DROP PROCEDURE [dbo].[updateIssue]
GO
/****** Object:  StoredProcedure [dbo].[updateIssue]    Script Date: 20.06.2021 11:30:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updateIssue]
	@Issue_ID int,
	@DatReturn date
AS
BEGIN
	update Issue set
		Dat_Return = @DatReturn
	where Issue_ID = @Issue_ID
END
GO
