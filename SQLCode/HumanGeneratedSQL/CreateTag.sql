
USE DreamCareer
GO

CREATE TABLE Tag
(
	TagID int IDENTITY(1,1),
	TagWord varchar(20)
	PRIMARY KEY (TagID)
)