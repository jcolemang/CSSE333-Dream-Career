USE DreamCareer
GO

-- A table type

GO
CREATE TYPE TagWordsTableType AS TABLE
(
	TagWords varchar(20)
)

GO
GRANT EXECUTE ON TYPE :: TagWordsTableType TO dreamcareer


GO
ALTER PROCEDURE search_positions_by_tags
	(@Tags AS TagWordsTableType READONLY)
AS	
	-- Used later
	DECLARE @NumTags int
	SET @NumTags = (SELECT COUNT(*) FROM @Tags)

	IF @NumTags = 0
	BEGIN
		SELECT Position.PositionID,
				Position.PositionTitle AS Title,
				Position.Salary AS Salary,
				Position.City AS City, 
				Position.State AS State
		FROM Position
		ORDER BY Salary DESC
		RETURN
	END
	
	SELECT Position.PositionID, 
			Position.PositionTitle AS Title,
			Position.Salary AS Salary, 
			Position.City AS City, Position.State as State
	FROM Position, PositionHasTag, Tag
	WHERE Position.PositionID = PositionHasTag.PositionID AND
			PositionHasTag.TagID = Tag.TagID AND
			(LOWER(Tag.TagWord) IN (SELECT TagWords FROM @Tags) OR
			@NumTags = 0)

	-- Extra groups so I can select those columns
	GROUP BY Position.PositionID, PositionTitle, Salary, 
			Position.City, Position.State

	-- I can only use this because the actual tag words are unique
	HAVING COUNT(Position.PositionID) >= @NumTags
	ORDER BY Salary DESC
	
GO
GRANT EXECUTE ON search_positions_by_tags TO dreamcareer
	

	





