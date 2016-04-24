USE DreamCareer

-- TODO not yet tested
-- joins positions and tags
-- on their id's 
GO 
CREATE PROCEDURE search_by_tag
	@tagtext varchar(20)
AS
	SELECT Position.PositionID
	FROM Tag, Position
	WHERE Tag.PositionID = Position.PositionID
			AND Tag.TagWord = @tagtext