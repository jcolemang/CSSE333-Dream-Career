
USE DreamCareer
GO

CREATE PROCEDURE insert_new_user 
@Uname varchar(20),
@pass varchar(20),
@email varchar(20)
AS
INSERT INTO DREAMCAREERUSER
(Username, UserPassword, Email)
VALUES
(@Uname, @pass, @email)

Go
exec insert_new_user @Uname="dummy", @pass="123", @email="a@a"

Go
CREATE PROCEDURE insert_new_user_profile
@name varchar(20),
@gender varchar(20),
@major varchar(20),
@address varchar(20),
@experience varchar(100),
@userid int
AS
INSERT INTO USERPROFILE
(Name, Gender, Major, Address, Experience)
VALUES
(@name, @gender, @major, @address, @experience)

Go
exec insert_new_user_profile @name="Coleman Gibson", @gender="M",
		@major="Computer Science", @address="underground", @experience="This"