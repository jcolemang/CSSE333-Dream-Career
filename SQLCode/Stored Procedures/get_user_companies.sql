

USE DreamCareer
GO

ALTER PROCEDURE get_user_companies
	(@UserID int)
AS

	DECLARE @UserDoesntExistError smallint
	SET @UserDoesntExistError = -8

	IF NOT EXISTS (SELECT * FROM DreamCareerUser WHERE UserID = @UserID)
	BEGIN
		PRINT 'User does not exist'
		RETURN @UserDoesntExistError
	END

	SELECT Company.CompanyID, Company.Name
	FROM DreamCareerUser, Company, OwnsCompany
	WHERE DreamCareerUser.UserID = OwnsCompany.UserID AND
			OwnsCompany.CompanyID = Company.CompanyID AND
			DreamCareerUser.UserID = @UserID
	RETURN 0