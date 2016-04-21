
USE DreamCareer
GO 

ALTER TABLE Position
DROP COLUMN Tag

GO
CREATE TABLE Tag
(
	TagID int IDENTITY(1,1) PRIMARY KEY,
	PositionID int REFERENCES Position(PositionID),
	TagWord varchar(20) NOT NULL
)