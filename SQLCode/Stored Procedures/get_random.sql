-- THE REST ARE REALLY JUST FOR POPULATING THE DATABASE
-- In other words, wont ever really be used in the
-- application. Credit to some guy on stackexchange
-- for answering a 'random row' question
GO
CREATE PROCEDURE get_random_username
AS
	SELECT TOP 1 Username
	FROM DreamCareerUser
	ORDER BY NEWID()

GO
CREATE PROCEDURE get_random_position_id
AS
	SELECT TOP 1 PositionID
	FROM Position
	ORDER BY NEWID()

GO
CREATE PROCEDURE get_random_profile_id
AS
	SELECT TOP 1 ProfileID
	FROM UserProfile
	ORDER BY NEWID()

GO
CREATE PROCEDURE get_random_company_id
AS
	SELECT TOP 1 CompanyID
	FROM Company
	ORDER BY NEWID()

GO
CREATE PROCEDURE get_random_userid
AS

	SELECT TOP 1 UserID
	FROM DreamCareerUser
	ORDER BY NEWID()

GO
GRANT EXECUTE ON get_random_username TO dreamcareer
GRANT EXECUTE ON get_random_position_id TO dreamcareer
GRANT EXECUTE ON get_random_profile_id TO dreamcareer
GRANT EXECUTE ON get_random_company_id TO dreamcareer
GRANT EXECUTE ON get_random_userid TO dreamcareer