

ALTER TRIGGER delete_likes
ON DreamCareerUser
INSTEAD OF DELETE
AS

	DELETE FROM Likes
	WHERE Likes.UserIDLikes IN (SELECT UserID FROM deleted) OR 
		Likes.ProfileLikedUserID IN (SELECT UserID FROM deleted)

	-- TODO is this needed?
	DELETE FROM DreamCareerUser
	WHERE UserID IN (SELECT UserID FROM deleted)