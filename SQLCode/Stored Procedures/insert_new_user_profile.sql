USE DreamCareer

-- Stored procedure which uses the userid
-- to find a user and attach a new profile 
-- them. Checks to see if there was already 
-- a profile before it completes the insert

-- TODO this is incomplete

GO
CREATE PROCEDURE insert_new_user_profile
	(@name varchar(20),
	@gender varchar(20),
	@major varchar(20),
	@address varchar(20),
	@experience varchar(100),
	@userid int = NULL,
	@username varchar(20) = NULL)
AS

	DECLARE @InputError int
	SET @InputError = -1

	IF ( @userid IS NULL AND @username IS NULL )
	BEGIN
		PRINT 'Either a username or a userid must be given'
		RETURN @InputError
	END

	IF ( @userid IS NOT NULL AND @username IS NOT NULL )
	BEGIN
		PRINT 'Must use only one of userid and username'
		RETURN @InputError
	END