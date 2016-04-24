USE DreamCareer

-- Another simple insert stored procedure
-- Inserts a Position into the database
-- Which is connected to a specific company
Go
CREATE PROCEDURE insert_new_position
	(@companyid int,
	@postype varchar(20),
	@posloc varchar(20),
	@salary money,
	@description varchar(100))
AS
	-- Good ol' insert
	INSERT INTO Position
	(CompanyID, Type, Location, Salary, Description)
	VALUES
	(@companyid, @postype, @posloc, @salary, @description)

GO
GRANT EXECUTE ON insert_new_position TO dreamcareer