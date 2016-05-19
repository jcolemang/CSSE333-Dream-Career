USE DreamCareer
GO

CREATE TABLE UserProfile
(
	ProfileID int NOT NULL,
	Name varchar(50) NOT NULL,
	Gender varchar(20),
	Major varchar(50),
	Experience varchar(5000),
	Street varchar(128),
	City varchar(128),
	State varchar(50),
	Zipcode char(5),

	FOREIGN KEY (ProfileID) REFERENCES DreamCareerUser(UserID)
	ON DELETE CASCADE
	ON UPDATE CASCADE
)

CREATE INDEX profile_name_index ON UserProfile (Name)