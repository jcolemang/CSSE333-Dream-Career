
USE DreamCareer
GO

CREATE PROCEDURE get_user_salt
	(@uname varchar(100))
AS

	DECLARE @UsernameDoesntExistError smallint
	SET @UsernameDoesntExistError = -3

	IF NOT EXISTS (SELECT Username 
					FROM DreamCareerUser
					WHERE Username=@uname)
	BEGIN
		PRINT 'Username does not exist'
		RETURN @UsernameDoesntExistError
	END
	
	SELECT Salt
	FROM DreamCareerUser
	WHERE Username=@uname
	RETURN 0