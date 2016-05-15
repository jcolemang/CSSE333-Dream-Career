

USE DreamCareer
GO

ALTER PROCEDURE get_user_id
	(@Username varchar(50))
AS

	DECLARE @UserDoesntExistError smallint
	SET @UserDoesntExistError = -8

	IF NOT EXISTS (SELECT * FROM DreamCareerUser WHERE @Username = Username)
	BEGIN
		PRINT 'User doesnt exist'
		RETURN @UserDoesntExistError 
	END

	SELECT UserID
	FROM DreamCareerUser
	WHERE Username = @Username
	RETURN 0

GO
GRANT EXECUTE ON get_user_id TO dreamcareer