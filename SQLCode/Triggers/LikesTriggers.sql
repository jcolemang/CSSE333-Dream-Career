

CREATE TRIGGER must_like_profile
ON Likes
INSTEAD OF INSERT
AS
	DECLARE @id int
	SET @id = (SELECT ProfileID FROM inserted)
	
	IF (NOT @id in (SELECT ProfileID FROM UserProfile))
	BEGIN
		PRINT 'No profile to like!'
	END
	ELSE BEGIN
		INSERT INTO Likes
		SELECT * FROM inserted
	END