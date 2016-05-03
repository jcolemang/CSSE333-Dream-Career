

CREATE TRIGGER delete_likes
ON DreamCareerUser
INSTEAD OF DELETE
AS
	DECLARE @DeletedUserID int
	SET @DeletedUserID = (SELECT UserID
						FROM deleted)

	DELETE FROM Likes
	WHERE Likes.UserIDLikes = @DeletedUserID OR 
		Likes.ProfileLikedUserID = @DeletedUserID

	-- TODO is this needed?
	DELETE FROM DreamCareerUser
	WHERE UserID = @DeletedUserID