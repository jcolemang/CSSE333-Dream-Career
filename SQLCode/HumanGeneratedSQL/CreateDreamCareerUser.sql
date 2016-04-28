USE DreamCareer
GO

CREATE TABLE DreamCareerUser 
(
	-- Autoincrementing primary key
	UserID int IDENTITY(1,1) NOT NULL,
	Username varchar(50) NOT NULL UNIQUE,

	Password varchar(50) NOT NULL,

	-- No one should be able to see plain text passwords
	HashedPassword varchar(100) NULL,
	Salt varchar(50) NULL,

	Email varchar(50) NOT NULL UNIQUE,

	PRIMARY KEY (UserID)
)