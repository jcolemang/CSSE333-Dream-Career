

USE DreamCareer
GO

CREATE PROCEDURE get_company_tags
	(@CompanyID int)
AS

	IF EXISTS (SELECT * FROM Company WHERE CompanyID = @CompanyID)
	BEGIN
		SELECT Tag.TagWord
		FROM Company, CompanyHasTag, Tag
		WHERE Company.CompanyID = CompanyHasTag.CompanyID AND
				CompanyHasTag.TagID = Tag.TagID AND
				Company.CompanyID = @CompanyID
		
	END
	