

USE DreamCareer
GO

CREATE PROCEDURE insert_new_tag
	(@tagword varchar(20))
AS

	INSERT INTO Tag
	(TagWord)
	VALUES
	(LOWER(@tagword))
	