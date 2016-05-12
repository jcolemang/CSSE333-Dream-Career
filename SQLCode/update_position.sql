USE [DreamCareer]
GO
/****** Object:  StoredProcedure [dbo].[update_position]    Script Date: 5/12/2016 6:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[update_position]
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
		Positiontype = CASE WHEN @postype is null then PositionType else @postype end,
		Street = CASE WHEN @street IS NULL THEN Street ELSE @street END,
		City = CASE WHEN @city IS NULL THEN City ELSE @city END,
		State = CASE WHEN @state IS NULL THEN State ELSE @state END,
		Zipcode = CASE WHEN @zipcode IS NULL THEN Zipcode ELSE @zipcode END,
		Salary = CASE WHEN @salary IS NULL THEN Salary ELSE @salary END,
		Positiondescription = CASE WHEN @description IS NULL THEN PositionDescription ELSE @description END
	where Positionid = @positionid
	RETURN 0
