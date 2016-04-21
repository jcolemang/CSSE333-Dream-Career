use DreamCareer
go

CREATE TABLE USERPROFILE
(
	ProfileID int IDENTITY(1,1) PRIMARY KEY,
	Name varchar(20) NOT NULL,
	Gender varchar(20),
	Major varchar(20),
	Address varchar(20),
	Experience varchar(100)
)

GO
CREATE TABLE DREAMCAREERUSER
(
	UserID int IDENTITY(1,1) PRIMARY KEY,
	Username varchar(20) UNIQUE NOT NULL,
	ProfileID int REFERENCES USERPROFILE(ProfileID),
	UserPassword varchar(20) NOT NULL,
	Email varchar(20) NOT NULL
)

GO
CREATE TABLE COMPANY
(
	CompanyID int IDENTITY(1,1) PRIMARY KEY,
	CompanyAddress varchar(20) NOT NULL,
	Size int NOT NULL,
	Name varchar(20) NOT NULL,
	Description varchar(100)
)

GO
CREATE TABLE POSITION
(
	PositionID int IDENTITY(1,1) PRIMARY KEY,
	CompanyID int REFERENCES COMPANY(CompanyID),
	PositionType varchar(20),
	PositionLocation varchar(20),
	Salary money
)

GO
CREATE TABLE TAG
(
	TagID int IDENTITY(1,1) PRIMARY KEY,
	PositionID int REFERENCES POSITION(PositionID),
	TagWord varchar(20) NOT NULL
)





