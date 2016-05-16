

USE DreamCareer
GO
ALTER PROCEDURE get_profile
	(@username varchar(20))
AS
	DECLARE @InputError smallint
	SET @InputError = -1

	SELECT Username, Name, Gender, Major, Experience, Street, City, State, Zipcode
	FROM UserProfile, DreamCareerUser
	WHERE DreamCareerUser.UserID = UserProfile.ProfileID AND
			LOWER(DreamCareerUser.Username) = LOWER(@username)
	RETURN 0

GO
GRANT EXECUTE ON get_profile TO dreamcareer