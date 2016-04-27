USE DreamCareer
GO

CREATE TABLE DreamCareerUser 
(
	-- Autoincrementing primary key
	UserID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Username varchar(50) NOT NULL UNIQUE,

	-- No one should be able to see plain text passwords
	HashedPassword varchar(100) NOT NULL,
	Salt varchar(50) NOT NULL,

	Email varchar(50) NOT NULL UNIQUE
)