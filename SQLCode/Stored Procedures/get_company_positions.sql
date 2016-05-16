

USE DreamCareer
GO

CREATE PROCEDURE get_company_positions
	(@CompanyID int)
AS

	SELECT PositionID, PositionTitle, PositionType, Salary
	FROM Company, Position
	WHERE Company.CompanyID = Position.CompanyID AND
			Company.CompanyID = @CompanyID
GO
GRANT EXECUTE ON get_company_positions TO dreamcareer