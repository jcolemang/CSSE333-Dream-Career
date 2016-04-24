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