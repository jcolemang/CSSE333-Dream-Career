USE DreamCareer

-- Stored procedure to insert new user
-- its really just a simple insert in 
-- this case

GO
ALTER PROCEDURE insert_new_user 
	(@Uname varchar(50),
	@password varchar(512),
	@salt varchar(512),
	@email varchar(100),
	@UserID int OUTPUT)
AS

	DECLARE @RepeatUsernameError smallint
	SET @RepeatUsernameError = -1

	DECLARE @RepeatEmailError smallint
	SET @RepeatEmailError = -2

	IF (EXISTS (SELECT *
				FROM DreamCareerUser
				WHERE Username = LOWER(@Uname)))
	BEGIN
		PRINT 'Username already exists.'
		RETURN @RepeatUsernameError
	END

	IF (EXISTS (SELECT *
				FROM DreamCareerUser
				WHERE Email = LOWER(@email)))
	BEGIN
		PRINT 'Email already exists.'
		RETURN @RepeatEmailError
	END

	INSERT INTO DreamCareerUser
	(Username, HashedPassword, Salt, Email)	
	VALUES
	(LOWER(@Uname), HASHBYTES('SHA1', @password + @salt), @salt, LOWER(@email))

	SET @UserID = (SELECT SCOPE_IDENTITY())
	RETURN 0

GO
GRANT EXECUTE ON insert_new_user TO dreamcareer