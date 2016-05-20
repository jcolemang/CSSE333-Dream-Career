USE DreamCareer
GO

CREATE TABLE Company
(
	CompanyID int IDENTITY(1,1),
	Size int NOT NULL,
	Name varchar(50) NOT NULL UNIQUE,
	CompanyDescription varchar(500),
	Street varchar(50),
	City varchar(50),
	State varchar(50),
	Zipcode char(5),

	PRIMARY KEY (CompanyID)
)

CREATE INDEX company_name_index ON Company (Name)
