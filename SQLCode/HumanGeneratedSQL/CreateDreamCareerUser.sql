USE DreamCareer
GO

CREATE TABLE DreamCareerUser 
(
	-- Autoincrementing primary key
	UserID int IDENTITY(1,1) NOT NULL,
	Username varchar(50) NOT NULL UNIQUE,

	-- No one should be able to see plain text passwords
	HashedPassword varchar(512) NULL,
	Salt varchar(512) NULL,

	Email varchar(100) NOT NULL UNIQUE,

	PRIMARY KEY (UserID)
)

ALTER TABLE DreamCareerUser
ALTER COLUMN Password varchar(512)

ALTER TABLE DreamCareerUser
ALTER COLUMN Salt varchar(512)

ALTER TABLE DreamCareerUser
ALTER COLUMN HashedPassword varchar(512)