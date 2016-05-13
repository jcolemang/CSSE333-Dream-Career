
USE DreamCareer
GO

CREATE TABLE UserProfileHasTag
(
	TagID int,
	ProfileID int,

	FOREIGN KEY (TagID) REFERENCES Tag(TagID)
	ON DELETE CASCADE
	ON UPDATE CASCADE,

	FOREIGN KEY (ProfileID) REFERENCES DreamCareerUser(UserID)
	ON DELETE CASCADE
	ON UPDATE CASCADE
)

-- Trigger to check that the user has a profile
-- as we cannot have a foreign key relationship
-- to ProfileID
GO
CREATE TRIGGER has_profile_trigger 
ON UserProfileHasTag
INSTEAD OF INSERT
AS BEGIN
	DECLARE @InsertedUserID int
	SET @InsertedUserID = (SELECT ProfileID FROM inserted)

	IF EXISTS ( SELECT * 
				FROM UserProfile 
				WHERE UserProfile.ProfileID = @InsertedUserID)
	BEGIN
		INSERT INTO UserProfileHasTag
			SELECT * FROM inserted
	END
END

	