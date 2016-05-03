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
	@uname varchar(50))
AS
	declare @id int
	DECLARE @ProfileExists int
	SET @ProfileExists = -4

	set @id = (select userid from DreamCareerUser 
				where username = @uname)

	--checking username doesn't already exist in user table
	if((select count(profileid) from userprofile where @id = profileid) != 0)
	begin
		print 'Trying to insert username that already exists in profile'
		return @ProfileExists
	end

	INSERT INTO UserProfile
	(Name, Gender, Major, Experience, Street, City, State, Zipcode, ProfileID)
	VALUES
	(@name, @gender, @major, @experience, @street, @city, @state, @zip, @id)
	RETURN 0
GO
GRANT EXECUTE ON insert_new_user_profile TO dreamcareer