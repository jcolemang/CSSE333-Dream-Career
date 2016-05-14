USE DreamCareer

-- Simple insert to connect a tag to
-- some Position
Go
ALTER PROCEDURE insert_new_position_tag
	(@tagtext varchar(20),
	@posid int)
AS

	DECLARE @RepeatEntry smallint
	SET @RepeatEntry = -6

	-- checking if the Tag already exists
	DECLARE @tagid int
	SET @tagid = (SELECT TagID FROM Tag WHERE TagWord=@tagtext)

	-- If not, create new tag
	IF ( @tagid IS NULL )
	BEGIN
		exec insert_new_tag @tagword=@tagtext
		SET @tagid = (SELECT TagID FROM Tag WHERE TagWord=@tagtext)
	END

	-- Checking if the relation is already in the PositionHasTag table
	IF EXISTS (SELECT *	
				FROM PositionHasTag
				WHERE TagID=@tagid AND 
						PositionID=@posid)
	
	BEGIN
		PRINT 'Position already has this tag'
		RETURN @RepeatEntry
	END

	
	-- Finally, the insert
	INSERT INTO PositionHasTag
	(TagID, PositionID)
	VALUES
	(@tagid, @posid)
	RETURN 0

GO
GRANT EXECUTE ON insert_new_position_tag TO dreamcareer
