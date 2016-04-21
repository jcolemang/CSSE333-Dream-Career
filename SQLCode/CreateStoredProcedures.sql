
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
exec insert_new_user @Uname="Coleman", @pass="123", @email="b@b"

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

UPDATE DREAMCAREERUSER
SET ProfileID = (SELECT SCOPE_IDENTITY())
WHERE UserID = @userid

Go
exec insert_new_user_profile @name="Coleman Gibson", @gender="M",
		@major="Computer Science", @address="underground", @experience="This",
		@userid=3


Go
CREATE PROCEDURE insert_new_company
@address varchar(20),
@size int,
@name varchar(20),
@description varchar(100)
AS
INSERT INTO COMPANY
(CompanyAddress, Size, Name, Description)
VALUES
(@address, @size, @name, @description)

Go
exec insert_new_company @address="Rose", @size=1000, @name="Coleman's Company", 
	@description="This is a company"


Go
CREATE PROCEDURE insert_new_position
@companyid int,
@postype varchar(20),
@posloc varchar(20),
@salary money

AS
INSERT INTO POSITION
(CompanyID, PositionType, PositionLocation, Salary)
VALUES
(@companyid, @postype, @posloc, @salary)

Go
exec insert_new_position @companyid=1, @postype="Internship",
	@posloc="Terre Haute", @salary=50000


--Go
--CREATE PROCEDURE insert_position_tag
--@tagtext varchar(20),
--@posid int

--AS
--INSERT INTO TAG
--(TagWord, )
--VALUES
--(@tagtext)

--UPDATE POSITION
--SET 