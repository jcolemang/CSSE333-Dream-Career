
USE DreamCareer
GO

CREATE PROCEDURE get_position
	(@posid int)
AS
	
	SELECT Position.PositionTitle, PositionType,
			Position.Salary, Position.PositionDescription,
			Position.Street, Position.City, Position.State, 
			Position.Zipcode
	FROM Position
	WHERE PositionID=@posid

GO
GRANT EXECUTE ON get_position TO dreamcareer


