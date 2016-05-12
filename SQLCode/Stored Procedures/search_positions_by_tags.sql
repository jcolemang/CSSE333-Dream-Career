USE DreamCareer
GO

-- A table type

CREATE TYPE TagWordsTableType AS TABLE
(
	TagWords varchar(20)
)

GO
GRANT EXECUTE ON TYPE :: TagWordsTableType TO dreamcareer


GO
CREATE PROCEDURE search_positions_by_tags
	(@Tags AS TagWordsTableType READONLY)
AS	
	-- Used later
	DECLARE @NumTags int
	SET @NumTags = (SELECT COUNT(*) FROM @Tags)
	
	SELECT Position.PositionID, 
			Position.PositionTitle AS Title,
			Position.Salary AS Salary, 
			Position.City AS City, Position.State as State
	FROM Position, PositionHasTag, Tag
	WHERE Position.PositionID = PositionHasTag.PositionID AND
			PositionHasTag.TagID = Tag.TagID AND
			LOWER(Tag.TagWord) IN (SELECT TagWords FROM @Tags)

	-- Extra groups so I can select those columns
	GROUP BY Position.PositionID, PositionTitle, Salary, 
			Position.City, Position.State

	-- I can only use this because the actual tag words are unique
	HAVING COUNT(Position.PositionID) = @NumTags
	
GO
GRANT EXECUTE ON search_positions_by_tags TO dreamcareer
	

	





