
USE DreamCareer
GO

CREATE PROCEDURE search_profiles_by_tags
	(@Tags AS TagWordsTableType READONLY)
AS
	-- The number of tags in the given table
	-- to know how many matches are needed 
	DECLARE @NumTagsGiven int
	SET @NumTagsGiven = (SELECT COUNT(*) FROM @Tags)

	SELECT UserProfile.ProfileID, UserProfile.Name
	FROM UserProfile, UserProfileHasTag, Tag
	WHERE UserProfile.ProfileID = UserProfileHasTag.ProfileID AND
			UserProfileHasTag.TagID = Tag.TagID AND
			LOWER(Tag.TagWord) IN (SELECT TagWords FROM @Tags)
	GROUP BY UserProfile.ProfileID, UserProfile.Name
	HAVING COUNT(UserProfile.ProfileID) = @NumTagsGiven

GO
GRANT EXECUTE ON search_profiles_by_tags TO dreamcareer