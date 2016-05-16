USE DreamCareer
GO

CREATE PROCEDURE insert_new_company_tag
	(@tagtext varchar(50),
	@CompanyID int)
AS

	-- Used in the database.cs file
	DECLARE @RepeatDataError smallint
	SET @RepeatDataError = -6
	
	DECLARE @tagid int
	SET @tagid = (SELECT TagID FROM Tag WHERE TagWord=@tagtext)

	-- Create new tag
	IF ( @tagid IS NULL )
	BEGIN
		exec insert_new_tag @tagword=@tagtext
		SET @tagid = (SELECT TagID FROM Tag WHERE TagWord=@tagtext)
	END

	-- checking if the relationship is already in this table
	IF EXISTS (SELECT * 
				FROM CompanyHasTag 
				WHERE TagID = @tagid AND
						CompanyID = @CompanyID)
	BEGIN
		PRINT 'Relationship already exists in this table'
		RETURN @RepeatDataError
	END

	INSERT INTO CompanyHasTag
	(TagID, CompanyID)
	VALUES
	(@tagid, @CompanyID)
	

GO
GRANT EXECUTE ON insert_new_company_tag TO dreamcareer