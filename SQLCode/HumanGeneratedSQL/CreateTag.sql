
USE DreamCareer
GO

CREATE TABLE Tag
(
	TagID int IDENTITY(1,1),
	TagWord varchar(50)
	PRIMARY KEY (TagID)
)

ALTER TABLE Tag
ADD UNIQUE(TagWord)

CREATE INDEX tag_index ON Tag (TagWord)

