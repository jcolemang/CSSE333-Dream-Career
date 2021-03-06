USE [DreamCareer]
GO
/****** Object:  StoredProcedure [dbo].[get_positonIdold]    Script Date: 5/12/2016 8:16:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[get_positonIdold](@oldpos varchar(50))
as
DECLARE @NoSuchPositionError smallint
	SET @NoSuchPositionError = -5

	-- Checking that the Position is even there
	IF EXISTS (SELECT * FROM Position WHERE @oldpos=PositionTitle)
	BEGIN
		PRINT 'No such Position exists.'
		RETURN @NoSuchPositionError
	END

select positionid from position where positiontitle = @oldpos;
