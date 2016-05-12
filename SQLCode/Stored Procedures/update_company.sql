

USE DreamCareer
GO

CREATE PROCEDURE update_company
	(@CompanyID int,
	@NewCompanyName varchar(50) = NULL,
	@NewSize int = -1,
	@NewDescription varchar(500) = NULL,
	@NewStreet varchar(20) = NULL,
	@NewCity varchar(20) = NULL,
	@NewState varchar(20) = NULL,
	@NewZip char(5) = NULL)
AS
	DECLARE @NoSuchCompanyError smallint
	SET @NoSuchCompanyError = -5

	-- Checking that the Company is even there
	IF NOT EXISTS (SELECT * FROM Company WHERE @CompanyID=CompanyID)
	BEGIN
		PRINT 'No such Company exists.'
		RETURN @NoSuchCompanyError
	END


	UPDATE Company
	SET Name = CASE WHEN @NewCompanyName IS NULL THEN Name ELSE @NewCompanyName END,
		Size = CASE WHEN @NewSize = -1 THEN Size ELSE @NewSize END,
		CompanyDescription = CASE WHEN @NewDescription IS NULL THEN CompanyDescription ELSE @NewDescription END,
		Street = CASE WHEN @NewStreet IS NULL THEN Street ELSE @NewStreet END,
		City = CASE WHEN @NewCity IS NULL THEN City ELSE @NewCity END,
		State = CASE WHEN @NewState IS NULL THEN State ELSE @NewState END,
		Zipcode = CASE WHEN @NewZip IS NULL THEN Zipcode ELSE @NewZip END
	WHERE CompanyID = @CompanyID
	RETURN 0
	
GO
GRANT EXECUTE ON update_company TO dreamcareer
