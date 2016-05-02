USE DreamCareer
GO

CREATE TABLE Likes
(
	UserIDLikes int,
	ProfileLikedUserID int,

	FOREIGN KEY (UserIDLikes) REFERENCES DreamCareerUser(UserID),
	FOREIGN KEY (ProfileLikedUserID) REFERENCES DreamCareerUser(UserID)

)


