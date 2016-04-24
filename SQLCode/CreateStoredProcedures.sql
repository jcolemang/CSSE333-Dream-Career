
USE DreamCareer


-- Stored procedure to insert new user
-- its really just a simple insert in 
-- this case
GO
CREATE PROCEDURE insert_new_user 
	(@Uname varchar(20),
	@pass varchar(20),
	@email varchar(20))
AS
	INSERT INTO DreamCareerUser
	(Username, Password, Email)	
	VALUES
	(@Uname, @pass, @email)


-- Stored procedure which uses the userid
-- to find a user and attach a new profile 
-- them. Checks to see if there was already 
-- a profile before it completes the insert
GO
CREATE PROCEDURE insert_new_user_profile_id
	(@name varchar(20),
	@gender varchar(20),
	@major varchar(20),
	@address varchar(20),
	@experience varchar(100),
	@userid int)
AS
	-- Checking if the user already has a profile
	IF (SELECT ProfileID
			FROM DreamCareerUser
			WHERE UserID=@userid) IS NOT NULL
	BEGIN
		PRINT 'User with UserID ' + CONVERT(varchar(30), @userid) +
				' already has a profile.'
		RETURN -1
	END

	-- Creating their profiles
	INSERT INTO UserProfile
	(Name, Gender, Major, Address, Experience)
	VALUES
	(@name, @gender, @major, @address, @experience)

	-- Creating the reference from DreamCareerUser
	-- to UserProfile
	UPDATE DreamCareerUser
	SET ProfileID = (SELECT SCOPE_IDENTITY())
	WHERE UserID = @userid


					
-- Calls insert_new_user_profile_id but this
-- stored procedure takes a username, not a UserId
Go
CREATE PROCEDURE insert_new_user_profile_username
	(@name varchar(20),
	@gender varchar(20),
	@major varchar(20),
	@address varchar(20),
	@experience varchar(100),
	@username varchar(20))
AS
	-- Getting the userid from the username
	DECLARE @userid int
	SET @userid = (SELECT UserID
					FROM DreamCareerUser
					WHERE Username=@username)

	-- Calling the stored procedure that does
	-- all the work
	EXEC insert_new_user_profile_id @name, @gender,
										@major, @address,
										@experience,
										@userid
	




-- A simple insert stored procedure
-- Inserts a company into the database
Go
CREATE PROCEDURE insert_new_company
	(@address varchar(20),
	@size int,
	@name varchar(20),
	@description varchar(100))
AS
	-- Just an insert
	INSERT INTO Company
	(Address, Size, Name, Description)
	VALUES
	(@address, @size, @name, @description)


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

Go
exec insert_new_position @companyid=1, @postype="Internship",
	@posloc="Terre Haute", @salary=50000, @description='Cool'



-- Simple insert to connect a tag to
-- some Position
Go
CREATE PROCEDURE insert_position_tag
	(@tagtext varchar(20),
	@posid int)
AS
	-- Performing the insert on tag
	INSERT INTO Tag
	(TagWord, PositionID)
	VALUES
	(@tagtext, @posid)


-- Simple insert to 'apply' for a position
-- TODO not yet tested
GO
CREATE PROCEDURE apply_to_position
	(@username varchar(20),
	@posid int)
AS
	INSERT INTO Apply
	(Username, PositionID)
	VALUES
	(@username, @posid)


-- Simple insert to 'like' a position
-- TODO not yet tested
GO
CREATE PROCEDURE like_profile
	(@username varchar(20),
	@profileid int)
AS
	INSERT INTO Like
	(Username, ProfileID)
	VALUES
	(@username, @profileid)


-- TODO not yet tested
-- joins positions and tags
-- on their id's 
GO 
CREATE PROCEDURE search_by_tag
	@tagtext varchar(20)
AS
	SELECT Position.PositionID
	FROM Tag, Position
	WHERE Tag.PositionID = Position.PositionID
			AND Tag.TagWord = @tagtext



-- A select to help with logins
-- TODO The entire way we do passwords is
-- not even slightly secure. 
-- it really should change
GO
CREATE PROCEDURE is_valid_user
	(@username varchar(20),
	@password varchar(20))
AS

	SELECT *
	FROM DreamCareerUser
	WHERE Username=@username AND
			Password=@password


GO
CREATE PROCEDURE get_all_userids
AS
	SELECT UserID
	FROM DreamCareerUser


GO 
CREATE PROCEDURE get_user_likes
	(@userid int)

AS
	SELECT ProfileID
	FROM Likes
	WHERE UserID = @userid




-- THE REST ARE REALLY JUST FOR POPULATING THE DATABASE
-- In other words, wont ever really be used in the
-- application. Credit to some guy on stackexchange
-- for answering a 'random row' question
GO
CREATE PROCEDURE get_random_username
AS
	SELECT TOP 1 Username
	FROM DreamCareerUser
	ORDER BY NEWID()

GO
CREATE PROCEDURE get_random_position_id
AS
	SELECT TOP 1 PositionID
	FROM Position
	ORDER BY NEWID()

GO
CREATE PROCEDURE get_random_profile_id
AS
	SELECT TOP 1 ProfileID
	FROM UserProfile
	ORDER BY NEWID()

GO
CREATE PROCEDURE get_random_company_id
AS
	SELECT TOP 1 CompanyID
	FROM Company
	ORDER BY NEWID()

GO
CREATE PROCEDURE get_random_userid
AS

	SELECT TOP 1 UserID
	FROM DreamCareerUser
	ORDER BY NEWID()

