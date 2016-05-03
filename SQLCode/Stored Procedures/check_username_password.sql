USE DreamCareer

-- A select to help with logins
-- TODO The entire way we do passwords is
-- not even slightly secure. 
-- it really should change
GO
CREATE PROCEDURE check_username_password
	(@username varchar(20),
	@pass varchar(20))
AS
	DECLARE @salt varchar(512)
	SET @salt=(SELECT Salt
				FROM DreamCareerUser
				WHERE Username=@username)

	SELECT *
	FROM DreamCareerUser
	WHERE Username=@username AND
			HashedPassword=HASHBYTES('SHA1', @pass+@salt)

GO
GRANT EXECUTE ON check_username_password TO dreamcareer