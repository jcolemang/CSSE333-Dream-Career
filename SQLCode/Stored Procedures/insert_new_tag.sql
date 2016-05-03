

USE DreamCareer
GO

CREATE PROCEDURE insert_new_tag
	(@tagword varchar(20))
AS
	DECLARE @RepeatTagError smallint
	SET @RepeatTagError = -1

	IF EXISTS (SELECT * FROM Tag WHERE Tag.TagWord=@tagword)
	BEGIN
		PRINT 'Tags must be unique.'
		RETURN @RepeatTagError
	END

	INSERT INTO Tag
	(TagWord)
	VALUES
	(LOWER(@tagword))
	