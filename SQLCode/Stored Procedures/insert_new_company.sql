USE DreamCareer

-- A simple insert stored procedure
-- Inserts a company into the database
Go
CREATE PROCEDURE insert_new_company
	(@size int,
	@name varchar(50),
	@description varchar(100),
	@street varchar(50),
	@city varchar(50),
	@state varchar(50),
	@zip varchar(5))
AS

	DECLARE @RepeatCompanyName smallint
	SET @RepeatCompanyName = -7

	-- checking if a company exists by the same name
	IF EXISTS (SELECT Name FROM Company WHERE Name=@name)
	BEGIN
		PRINT 'Company by that name already exists'
		RETURN @RepeatCompanyName
	END


	-- Just an insert
	INSERT INTO Company
	(Size, Name, CompanyDescription, Street, City, State, Zipcode)
	VALUES
	(@size, @name, @description, @street, @city, @state, @zip)

	RETURN 0

GO
GRANT EXECUTE ON insert_new_company TO dreamcareer