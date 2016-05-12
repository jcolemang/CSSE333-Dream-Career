
USE DreamCareer
GO

CREATE PROCEDURE delete_company
	(@CompanyID int)
AS

	DELETE FROM Company
	WHERE CompanyID = @CompanyID

GO
GRANT EXECUTE ON delete_company TO dreamcareer