USE DreamCareer

-- A simple insert stored procedure
-- Inserts a company into the database
Go
CREATE PROCEDURE insert_new_company
	(@address varchar(20),
	@size int,
	@name varchar(20),
	@description varchar(100))
AS
	-- Just an insert
	INSERT INTO Company
	(Address, Size, Name, Description)
	VALUES
	(@address, @size, @name, @description)