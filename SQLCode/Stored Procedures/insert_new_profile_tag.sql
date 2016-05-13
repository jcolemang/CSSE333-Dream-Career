USE DreamCareer
GO

CREATE PROCEDURE insert_new_profile_tag
	(@tagtext varchar(20),
	@ProfileID int)
AS

	-- Used in the database.cs file
	DECLARE @RepeatDataError smallint
	SET @RepeatDataError = -6
	
	DECLARE @tagid int
	SET @tagid = (SELECT TagID FROM Tag WHERE TagWord=@tagtext)

	-- Create new tag
	IF ( @tagid IS NULL )
	BEGIN
		exec insert_new_tag @tagword=@tagtext
		-- TODO Pretty sure this is super inefficient
		SET @tagid = (SELECT TagID FROM Tag WHERE TagWord=@tagtext)
	END

	-- checking if the relationship is already in this table
	IF EXISTS (SELECT * 
				FROM UserProfileHasTag 
				WHERE TagID = @tagid AND
						ProfileID = @ProfileID)
	BEGIN
		PRINT 'Relationship already exists in this table'
		RETURN @RepeatDataError
	END

	INSERT INTO UserProfileHasTag
	(TagID, ProfileID)
	VALUES
	(@tagid, @ProfileID)
	

GO
GRANT EXECUTE ON insert_new_profile_tag TO dreamcareer