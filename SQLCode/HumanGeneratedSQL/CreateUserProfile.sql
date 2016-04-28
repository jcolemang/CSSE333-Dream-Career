USE DreamCareer
GO

CREATE TABLE UserProfile
(
	ProfileID int NOT NULL,
	Name varchar(50) NOT NULL,
	Gender varchar(20),
	Major varchar(50),
	Experience varchar(500),
	Street varchar(50),
	City varchar(50),
	State varchar(50),
	Zipcode char(5),

	FOREIGN KEY (ProfileID) REFERENCES DreamCareerUser(UserID)
	ON DELETE CASCADE
)