
USE DreamCareer
GO

CREATE PROCEDURE search_profiles_by_tags
	(@Tags AS TagWordsTableType READONLY)
AS
	-- The number of tags in the given table
	-- to know how many matches are needed 
	DECLARE @NumTagsGiven int
	SET @NumTagsGiven = (SELECT COUNT(*) FROM @Tags)

	SELECT UserProfile.ProfileID, UserProfile.Name, DreamCareerUser.Username
	FROM UserProfile, UserProfileHasTag, Tag, DreamCareerUser
	WHERE UserProfile.ProfileID = UserProfileHasTag.ProfileID AND
			UserProfileHasTag.TagID = Tag.TagID AND
			DreamCareerUser.UserID = UserProfile.ProfileID AND
			LOWER(Tag.TagWord) IN (SELECT TagWords FROM @Tags)
	GROUP BY UserProfile.ProfileID, DreamCareerUser.Username, UserProfile.Name
	HAVING COUNT(UserProfile.ProfileID) = @NumTagsGiven

GO
GRANT EXECUTE ON search_profiles_by_tags TO dreamcareer