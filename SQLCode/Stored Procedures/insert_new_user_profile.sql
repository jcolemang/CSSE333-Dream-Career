USE DreamCareer

-- Stored procedure which uses the userid
-- to find a user and attach a new profile 
-- them. Checks to see if there was already 
-- a profile before it completes the insert

-- TODO this is incomplete

GO
alter PROCEDURE insert_new_user_profile
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
	DECLARE @InputError int
	SET @InputError = -1

	-- Need error checking 
	set @id = (select profileid from userprofile 
	where exists (select username from DreamCareerUser where username = @uname))
	--checking username doesn't already exist in user table
	if((select count(profileid) from userprofile where @id = profileid) is not null)
		begin
		print 'Trying to insert username that already exists in profile'
		return @InputError
		end
	INSERT INTO UserProfile
	(Name, Gender, Major, Experience, Street, City, State, Zipcode, ProfileID)
	VALUES
	(@name, @gender, @major, @experience, @street, @city, @state, @zip, @id)

GO
GRANT EXECUTE ON insert_new_user_profile TO dreamcareer