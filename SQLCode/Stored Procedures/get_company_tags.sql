

USE DreamCareer
GO	

CREATE PROCEDURE get_company_tags
	(@CompanyID int)
AS

	DECLARE @NoCompanyError smallint
	SET @NoCompanyError = -5

	IF EXISTS (SELECT * FROM Company WHERE CompanyID = @CompanyID)
	BEGIN
		SELECT Tag.TagWord
		FROM Company, CompanyHasTag, Tag
		WHERE Company.CompanyID = CompanyHasTag.CompanyID AND
				CompanyHasTag.TagID = Tag.TagID AND
				Company.CompanyID = @CompanyID
		RETURN 0
	END
	ELSE
	BEGIN
		PRINT 'Company does not exist'
		RETURN @NoCompanyError
	END
GO
GRANT EXECUTE ON get_company_tags TO dreamcareer