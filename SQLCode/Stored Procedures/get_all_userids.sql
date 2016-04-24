USE DreamCareer

GO
CREATE PROCEDURE get_all_userids
AS
	SELECT UserID
	FROM DreamCareerUser

GO
GRANT EXECUTE ON get_all_userids TO dreamcareer