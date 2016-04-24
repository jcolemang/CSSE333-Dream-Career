USE DreamCareer

-- Simple insert to connect a tag to
-- some Position
Go
CREATE PROCEDURE insert_new_position_tag
	(@tagtext varchar(20),
	@posid int)
AS
	-- Performing the insert on tag
	INSERT INTO Tag
	(TagWord, PositionID)
	VALUES
	(@tagtext, @posid)

GO
GRANT EXECUTE ON insert_new_position_tag TO dreamcareer