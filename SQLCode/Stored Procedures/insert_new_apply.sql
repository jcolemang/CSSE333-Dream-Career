USE DreamCareer

-- Simple insert to 'apply' for a position
-- TODO not yet tested
-- TODO rename this
-- TODO allow either username or userid
GO
CREATE PROCEDURE insert_new_apply
	(@username varchar(20),
	@posid int)
AS
	INSERT INTO Apply
	(UserID, PositionID)
	VALUES
	(@username, @posid)

GRANT EXECUTE ON insert_new_apply TO dreamcareer