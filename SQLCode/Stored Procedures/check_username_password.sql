USE DreamCareer

-- A select to help with logins
-- TODO The entire way we do passwords is
-- not even slightly secure. 
-- it really should change
GO
CREATE PROCEDURE check_username_password
	(@username varchar(20),
	@password varchar(20))
AS

	SELECT *
	FROM DreamCareerUser
	WHERE Username=@username AND
			Password=@password