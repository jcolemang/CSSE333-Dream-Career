USE DreamCareer

-- Stored procedure which uses the userid
-- to find a user and attach a new profile 
-- them. Checks to see if there was already 
-- a profile before it completes the insert

-- TODO this is incomplete

GO
ALTER PROCEDURE insert_new_user_profile
	(@name varchar(20),
	@gender varchar(20),
	@major varchar(50),
	@experience varchar(100),
	@street varchar(50),
	@city varchar(50),
	@state varchar(50),
	@zip varchar(5),
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

	-- because setting the gender to 'Select' by default is extremely silly
	DECLARE @GenderToUse varchar(20)
	IF LOWER(@gender) = 'select'
	BEGIN
		SET @GenderToUse = NULL
	END
	ELSE BEGIN
		SET @GenderToUse = @gender
	END

	INSERT INTO UserProfile
	(Name, Gender, Major, Experience, Street, City, State, Zipcode, ProfileID)
	VALUES
	(@name, @GenderToUse, @major, @experience, @street, @city, @state, @zip, @id)
	RETURN 0
GO
GRANT EXECUTE ON insert_new_user_profile TO dreamcareer
