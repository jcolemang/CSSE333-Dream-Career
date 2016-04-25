USE DreamCareer

-- Simple insert to 'like' a position
-- TODO not yet tested
GO
ALTER PROCEDURE insert_new_like
	(@username varchar(20) = NULL,
	@userid int = NULL,
	@profileid int)
AS
	-- General variables
	DECLARE @InputError smallint
	SET @InputError = -1

	DECLARE @RepeatRowError smallint
	SET @RepeatRowError = -2

	-- Validating the parameters

	IF ( @username IS NULL AND @userid IS NULL )
	BEGIN
		PRINT 'Must give either username or userid'
		RETURN @InputError
	END

	IF ( @username IS NOT NULL AND @userid IS NOT NULL )
	BEGIN
		PRINT 'Cannot give both username and userid'
		RETURN @InputError
	END

	IF ( @userid IS NULL )
	BEGIN
		SET @userid = (SELECT UserId
						FROM DreamCareerUser
						WHERE Username = @username)
	END

	IF ( NOT EXISTS (SELECT * 
						FROM DreamCareerUser
						WHERE UserID = @userid) )
	BEGIN
		PRINT 'Not a valid User'
		RETURN @InputError
	END

	IF ( NOT EXISTS (SELECT *
						FROM UserProfile
						WHERE ProfileID = @profileid) )
	BEGIN 
		PRINT 'Not a valid Profile'
		RETURN @InputError
	END

	-- Parameters are valid!

	IF ( EXISTS (SELECT *
					FROM Likes
					WHERE UserID = @userid AND
							ProfileID = @profileid) )
	BEGIN
		PRINT 'User already liked profile'
		RETURN @RepeatRowError
	END

	INSERT INTO Likes
	(UserID, ProfileID)
	VALUES
	(@userid, @profileid)

GO
GRANT EXECUTE ON insert_new_like TO dreamcareer