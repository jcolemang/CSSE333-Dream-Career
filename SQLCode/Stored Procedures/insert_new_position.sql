USE DreamCareer

-- Another simple insert stored procedure
-- Inserts a Position into the database
-- Which is connected to a specific company
Go
CREATE PROCEDURE insert_new_position
	(@companyid int,
	@positiontitle varchar(20),
	@postype varchar(20),
	@street varchar(20),
	@city varchar(20),
	@state varchar(20),
	@zipcode varchar(20),
	@salary money,
	@description varchar(100))
AS
	-- Good ol' insert
	INSERT INTO Position
	(CompanyID, PositionTitle, PositionType, Street, City, State, Zipcode, Salary, PositionDescription)
	VALUES
	(@companyid, @positiontitle, @postype, @street, @city, @state, @zipcode, @salary, @description)

GO
GRANT EXECUTE ON insert_new_position TO dreamcareer