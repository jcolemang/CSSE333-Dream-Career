
USE DreamCareer
GO


-- See 'search_positions_by_tags.sql' for information on the
-- table valued parameter

ALTER PROCEDURE search_companies_by_tags
	(@Tags AS TagWordsTableType READONLY)
AS
	-- The number of tags in the given table
	-- to know how many matches are needed 
	DECLARE @NumTagsGiven int
	SET @NumTagsGiven = (SELECT COUNT(DISTINCT TagWords) FROM @Tags)

	SELECT Company.CompanyID, Company.Name
	FROM Company, CompanyHasTag, Tag
	WHERE Company.CompanyID = CompanyHasTag.CompanyID AND
			CompanyHasTag.TagID = Tag.TagID AND
			((LOWER(Tag.TagWord) IN (SELECT DISTINCT TagWords FROM @Tags)) OR
			(@NumTagsGiven = 0))
	GROUP BY Company.CompanyID, Company.Name
	HAVING COUNT(Company.CompanyID) >= @NumTagsGiven

GO
GRANT EXECUTE ON search_companies_by_tags TO dreamcareer