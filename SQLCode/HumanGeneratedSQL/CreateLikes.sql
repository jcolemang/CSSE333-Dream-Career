USE DreamCareer
GO

CREATE TABLE Likes
(
	UserID int,
	ProfileID int,

	FOREIGN KEY (UserID) REFERENCES DreamCareerUser(UserID)
	ON UPDATE CASCADE
	ON DELETE CASCADE,

	FOREIGN KEY (ProfileID) REFERENCES DreamCareerUser(UserID)
)

GO

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