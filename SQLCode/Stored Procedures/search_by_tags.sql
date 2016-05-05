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
ALTER PROCEDURE search_by_tags
	(@Tags AS TagWordsTableType READONLY)
AS	
	-- Used later
	DECLARE @NumTags int
	SET @NumTags = (SELECT COUNT(*) FROM @Tags)
	
	SELECT Position.PositionTitle AS Title, Position.PositionType AS PositionType,
			Position.PositionDescription AS PositionDescription, 
			Position.Salary AS Salary, Position.PositionID
	FROM Position, HasTag, Tag
	WHERE Position.PositionID = HasTag.PositionID AND
			HasTag.TagID = Tag.TagID AND
			Tag.TagWord IN (SELECT TagWords FROM @Tags)

	-- Extra groups so I can select those columns
	GROUP BY Position.PositionID, PositionTitle, PositionType, 
			PositionDescription, Salary

	-- I can only use this because the actual tag words are unique
	HAVING COUNT(Position.PositionID) = @NumTags
	
GO
GRANT EXECUTE ON search_by_tags TO dreamcareer
	

	





