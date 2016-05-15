USE DreamCareer

-- A simple insert stored procedure
-- Inserts a company into the database
Go
ALTER PROCEDURE insert_new_company
	(@size int,
	@name varchar(50),
	@description varchar(100),
	@street varchar(50),
	@city varchar(50),
	@state varchar(50),
	@zip varchar(5),
	@UserID int,
	@CompanyID int OUTPUT)
AS

	DECLARE @UserDoesntExist int
	SET @UserDoesntExist = -3

	DECLARE @RepeatCompanyName smallint
	SET @RepeatCompanyName = -8

	IF NOT EXISTS (SELECT * FROM DreamCareerUser WHERE UserID = @UserID)
	BEGIN
		PRINT 'Company needs a valid user'
		RETURN @UserDoesntExist
	END	

	-- checking if a company exists by the same name
	IF EXISTS (SELECT Name FROM Company WHERE Name=@name)
	BEGIN
		PRINT 'Company by that name already exists'
		RETURN @RepeatCompanyName
	END

	-- Standard insert into Company
	INSERT INTO Company
	(Size, Name, CompanyDescription, Street, City, State, Zipcode)
	VALUES
	(@size, @name, @description, @street, @city, @state, @zip)

	-- So the user knows what company they just created
	SET @CompanyID = (SELECT SCOPE_IDENTITY())

	-- linking the company to the user
	INSERT INTO OwnsCompany
	(UserID, CompanyID)
	VALUES
	(@UserID, @CompanyID)

	-- success!
	RETURN 0

GO
GRANT EXECUTE ON insert_new_company TO dreamcareer