
USE DreamCareer
GO

CREATE TABLE PositionHasTag
(
	TagID int,
	PositionID int,

	FOREIGN KEY (TagID) REFERENCES Tag(TagID)
	ON DELETE CASCADE
	ON UPDATE CASCADE,

	FOREIGN KEY (PositionID) REFERENCES Position(PositionID)
	ON DELETE CASCADE
	ON UPDATE CASCADE
)