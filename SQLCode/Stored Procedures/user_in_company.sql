

USE DreamCareer
GO

CREATE PROCEDURE user_in_company
	(@UserID int,
	@CompanyID int)
AS
	-- Just a test to see if any rows exists. 
	SELECT *
	FROM OwnsCompany
	WHERE CompanyID = @CompanyID AND
			@UserID = UserID

GO
GRANT EXECUTE ON user_in_company TO dreamcareer