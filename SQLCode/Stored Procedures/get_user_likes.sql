USE DreamCareer

GO 
CREATE PROCEDURE get_user_likes
	(@userid int)
AS
	SELECT ProfileLikedUserID
	FROM Likes
	WHERE UserIDLikes = @userid

GRANT EXECUTE ON get_user_likes TO dreamcareer