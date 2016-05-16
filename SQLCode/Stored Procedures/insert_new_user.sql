USE DreamCareer

-- Stored procedure to insert new user
-- its really just a simple insert in 
-- this case

GO
CREATE PROCEDURE insert_new_user 
	(@Uname varchar(20),
	@password varchar(512),
	@salt varchar(512),
	@email varchar(20),
	@UserID int OUTPUT)
AS

	DECLARE @RepeatUsernameError smallint
	SET @RepeatUsernameError = -1

	DECLARE @RepeatEmailError smallint
	SET @RepeatEmailError = -2

	IF (EXISTS (SELECT *
				FROM DreamCareerUser
				WHERE Username = @Uname))
	BEGIN
		PRINT 'Username already exists.'
		RETURN @RepeatUsernameError
	END

	IF (EXISTS (SELECT *
				FROM DreamCareerUser
				WHERE Email = @email))
	BEGIN
		PRINT 'Email already exists.'
		RETURN @RepeatEmailError
	END

	INSERT INTO DreamCareerUser
	(Username, HashedPassword, Salt, Email)	
	VALUES
	(@Uname, HASHBYTES('SHA1', @password + @salt), @salt, @email)

	SET @UserID = (SELECT SCOPE_IDENTITY())
	RETURN 0

GO
GRANT EXECUTE ON insert_new_user TO dreamcareer