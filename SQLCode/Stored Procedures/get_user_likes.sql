USE DreamCareer

GO 
CREATE PROCEDURE get_user_likes
	(@userid int)
AS
	SELECT ProfileID
	FROM Likes
	WHERE UserID = @userid

GRANT EXECUTE ON get_user_likes TO dreamcareer