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

	UserType char(1) NOT NULL DEFAULT 'U',
	
	PRIMARY KEY (UserID)
)

ALTER TABLE DreamCareerUser
ADD CONSTRAINT UserType_check
CHECK (
	UserType IN ('U', 'C', 'A')
);

