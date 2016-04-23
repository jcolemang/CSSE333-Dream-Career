use DreamCareer
go

CREATE TABLE UserProfile
(
	ProfileID int IDENTITY(1,1) PRIMARY KEY,
	Name varchar(20) NOT NULL,
	Gender varchar(20),
	Major varchar(20),
	Address varchar(20),
	Experience varchar(100)
)


GO
CREATE TABLE DreamCareerUser
(
	UserID int IDENTITY(1,1) PRIMARY KEY,
	Username varchar(20) UNIQUE NOT NULL,
	ProfileID int REFERENCES USERPROFILE(ProfileID),
	Password varchar(20) NOT NULL,
	Email varchar(20) NOT NULL
)

GO
CREATE TABLE Company
(
	CompanyID int IDENTITY(1,1) PRIMARY KEY,
	Address varchar(20) NOT NULL,
	Size int NOT NULL,
	Name varchar(20) NOT NULL,
	Description varchar(100)
)

GO
CREATE TABLE Position
(
	PositionID int IDENTITY(1,1) PRIMARY KEY,
	CompanyID int REFERENCES COMPANY(CompanyID),
	[Type] varchar(20),
	Location varchar(20),
	Salary money,
	Description varchar(256)
)

GO
CREATE TABLE Tag
(
	TagID int IDENTITY(1,1) PRIMARY KEY,
	PositionID int REFERENCES POSITION(PositionID),
	TagWord varchar(20) NOT NULL
)





