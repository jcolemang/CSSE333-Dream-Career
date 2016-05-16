

USE DreamCareer
GO

CREATE VIEW company_with_tags_view
AS
	SELECT Company.CompanyID, Size, Name, CompanyDescription, Street, City, State, Zipcode, TagWord
	FROM Company, CompanyHasTag, Tag
	WHERE Company.CompanyID = CompanyHasTag.CompanyID AND
			CompanyHasTag.TagID = Tag.TagID