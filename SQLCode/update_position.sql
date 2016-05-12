USE DreamCareer
Go
CREATE PROCEDURE update_position
	(@positionid int,
	@companyid int,
	@positiontitle varchar(20),
	@postype varchar(20),
	@street varchar(20),
	@city varchar(20),
	@state varchar(20),
	@zipcode varchar(20),
	@salary money,
	@description varchar(100))
AS
	UPDATE Position
	set PositionTitle = @positiontitle, 
		Positiontype = @postype,
		Street = @street,
		City = @city,
		State = @state,
		Zipcode = @zipcode,
		Salary = @salary,
		Positiondescription = @description
	where Positionid = @positionid and companyid = @companyid
GO
GRANT EXECUTE ON update_position TO dreamcareer

