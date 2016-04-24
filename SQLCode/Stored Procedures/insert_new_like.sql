USE DreamCareer

-- Simple insert to 'like' a position
-- TODO not yet tested
GO
CREATE PROCEDURE insert_new_like
	(@username varchar(20),
	@profileid int)
AS
	INSERT INTO Likes
	(UserID, ProfileID)
	VALUES
	(@username, @profileid)

GO
GRANT EXECUTE ON insert_new_like TO dreamcareer