USE DreamCareer

-- Stored procedure which uses the userid
-- to find a user and attach a new profile 
-- them. Checks to see if there was already 
-- a profile before it completes the insert

-- TODO this is incomplete

GO
CREATE PROCEDURE insert_new_user_profile
	(@name varchar(20),
	@gender varchar(20),
	@major varchar(20),
	@experience varchar(100),
	@street varchar(20),
	@city varchar(20),
	@state varchar(20),
	@zip varchar(10),
	@userid int)
AS

	DECLARE @InputError int
	SET @InputError = -1

	-- Need error checking 

	INSERT INTO UserProfile
	(Name, Gender, Major, Experience, Street, City, State, Zipcode, ProfileID)
	VALUES
	(@name, @gender, @major, @experience, @street, @city, @state, @zip, @userid)

GO
GRANT EXECUTE ON insert_new_user_profile TO dreamcareer