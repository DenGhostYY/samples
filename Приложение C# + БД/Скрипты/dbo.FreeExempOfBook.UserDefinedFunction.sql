USE [ChumakovLibrary]
GO
/****** Object:  UserDefinedFunction [dbo].[FreeExempOfBook]    Script Date: 20.06.2021 11:30:08 ******/
DROP FUNCTION [dbo].[FreeExempOfBook]
GO
/****** Object:  UserDefinedFunction [dbo].[FreeExempOfBook]    Script Date: 20.06.2021 11:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[FreeExempOfBook](@Book_ID int)
RETURNS @result TABLE 
(
	Exemp_ID int not null,
	Exemp_Number int not null
)
AS
BEGIN
	insert into @result(Exemp_ID, Exemp_Number)
	select e.Exemp_ID, e.Exemp_Number
	from Exemp e
	where e.Book_ID = @Book_ID
		and e.Exemp_ID not in (
			select i.Exemp_ID
			from Issue i
			where i.Dat_Return is null
		)
	RETURN 
END
GO
