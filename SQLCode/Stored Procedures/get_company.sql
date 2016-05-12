

USE DreamCareer
GO

CREATE PROCEDURE get_company
	(@CompanyID int)
AS
	
	SELECT Name, CompanyDescription, Size, Street, City, State, Zipcode
	FROM Company
	WHERE Company.CompanyID = @CompanyID

GO
GRANT EXECUTE ON get_company TO dreamcareer
