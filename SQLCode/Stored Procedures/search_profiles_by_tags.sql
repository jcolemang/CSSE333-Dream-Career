
USE DreamCareer
GO

ALTER PROCEDURE search_profiles_by_tags
	(@Tags AS TagWordsTableType READONLY)
AS
	-- The number of tags in the given table
	-- to know how many matches are needed 
	DECLARE @NumTagsGiven int
	SET @NumTagsGiven = (SELECT COUNT(*) FROM @Tags)

	IF @NumTagsGiven = 0
	BEGIN
		SELECT UserProfile.ProfileID, UserProfile.Name, DreamCareerUser.Username
		FROM UserProfile, DreamCareerUser
		WHERE UserProfile.ProfileID = DreamCareerUser.UserID
		ORDER BY UserProfile.Name
		RETURN
	END

	SELECT UserProfile.ProfileID, UserProfile.Name, DreamCareerUser.Username
	FROM UserProfile, UserProfileHasTag, Tag, DreamCareerUser
	WHERE UserProfile.ProfileID = UserProfileHasTag.ProfileID AND
			UserProfileHasTag.TagID = Tag.TagID AND
			DreamCareerUser.UserID = UserProfile.ProfileID AND
			(LOWER(Tag.TagWord) IN (SELECT TagWords FROM @Tags) OR
			@NumTagsGiven = 0)
	GROUP BY UserProfile.ProfileID, DreamCareerUser.Username, UserProfile.Name
	HAVING COUNT(UserProfile.ProfileID) >= @NumTagsGiven
	ORDER BY UserProfile.Name

GO
GRANT EXECUTE ON search_profiles_by_tags TO dreamcareer