USE DreamCareer

-- A simple insert stored procedure
-- Inserts a company into the database
Go
CREATE PROCEDURE insert_new_company
	(@size int,
	@name varchar(20),
	@description varchar(100),
	@street varchar(20),
	@city varchar(20),
	@state varchar(20),
	@zip varchar(10))
AS
	-- Just an insert
	INSERT INTO Company
	(Size, Name, CompanyDescription, Street, City, State, Zipcode)
	VALUES
	(@size, @name, @description, @street, @city, @state, @zip)

GO
GRANT EXECUTE ON insert_new_company TO dreamcareer