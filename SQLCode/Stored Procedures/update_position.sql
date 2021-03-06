USE [DreamCareer]
GO
/****** Object:  StoredProcedure [dbo].[update_position]    Script Date: 5/12/2016 6:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[update_position]
	(@positionid int,
	@companyid int = null,
	@positiontitle varchar(50) = null,
	@postype varchar(50) = null,
	@street varchar(50) = null,
	@city varchar(50) = null,
	@state varchar(50) = null,
	@zipcode varchar(50) = null,
	@salary money = null,
	@description varchar(500) = null)
AS
	UPDATE Position
	set PositionTitle = CASE WHEN @positiontitle IS NULL THEN PositionTitle ELSE @positiontitle END, 
		Positiontype = CASE WHEN @postype is null then PositionType else @postype end,
		Street = CASE WHEN @street IS NULL THEN Street ELSE @street END,
		City = CASE WHEN @city IS NULL THEN City ELSE @city END,
		State = CASE WHEN @state IS NULL THEN State ELSE @state END,
		Zipcode = CASE WHEN @zipcode IS NULL THEN Zipcode ELSE @zipcode END,
		Salary = CASE WHEN @salary IS NULL THEN Salary ELSE @salary END,
		Positiondescription = CASE WHEN @description IS NULL THEN PositionDescription ELSE @description END
	where Positionid = @positionid
	RETURN 0
go
grant execute on update_position to dreamcareer
