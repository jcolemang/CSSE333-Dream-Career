USE DreamCareer

-- Simple insert to connect a tag to
-- some Position
Go
CREATE PROCEDURE insert_new_position_tag
	(@tagtext varchar(20),
	@posid int)
AS
	
	DECLARE @tagid int
	SET @tagid = (SELECT TagID FROM Tag WHERE TagWord=@tagtext)

	-- Create new tag
	IF ( @tagid IS NULL )
	BEGIN
		exec insert_new_tag @tagword=@tagtext
	END

	INSERT INTO HasTag
	(TagID, PositionID)
	VALUES
	(@tagid, @posid)
	

GO
GRANT EXECUTE ON insert_new_position_tag TO dreamcareer
