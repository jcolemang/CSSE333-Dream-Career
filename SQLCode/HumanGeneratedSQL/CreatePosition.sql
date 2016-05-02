USE DreamCareer
GO

CREATE TABLE Position
(
	PositionID int IDENTITY(1,1),
	CompanyID int,
	PositionTitle varchar(50),
	PositionType varchar(50) NOT NULL,
	Street varchar(50),
	City varchar(50),
	State varchar(50),
	Zipcode char(5),
	Salary money,
	PositionDescription varchar(5000),

	PRIMARY KEY (PositionID),
	FOREIGN KEY (CompanyID) REFERENCES Company(CompanyID)
	ON DELETE CASCADE
	ON UPDATE CASCADE
)