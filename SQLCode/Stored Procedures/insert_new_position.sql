USE DreamCareer

-- Another simple insert stored procedure
-- Inserts a Position into the database
-- Which is connected to a specific company
Go
ALTER PROCEDURE insert_new_position
	(@companyid int,
	@positiontitle varchar(50),
	@postype varchar(50),
	@street varchar(50),
	@city varchar(50),
	@state varchar(50),
	@zipcode varchar(50),
	@salary money,
	@description varchar(500))
AS
	-- Good ol' insert
	INSERT INTO Position
	(CompanyID, PositionTitle, PositionType, Street, City, State, Zipcode, Salary, PositionDescription)
	VALUES
	(@companyid, @positiontitle, @postype, @street, @city, @state, @zipcode, @salary, @description)

GO
GRANT EXECUTE ON insert_new_position TO dreamcareer