USE [DreamCareer]
GO
/****** Object:  StoredProcedure [dbo].[insert_new_position_gui]    Script Date: 5/8/2016 9:28:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insert_new_position_gui]
	(@companyid int,
	@positiontitle varchar(20),
	@postype varchar(20),
	@street varchar(20),
	@city varchar(20),
	@state varchar(20),
	@zipcode varchar(20),
	@salary money,
	@description varchar(100))
AS
	-- Good ol' insert
	INSERT INTO Position
	(CompanyID, PositionTitle, PositionType, Street, City, State, Zipcode, Salary, PositionDescription)
	VALUES
	(@companyid, @positiontitle, @postype, @street, @city, @state, @zipcode, @salary, @description)
go
grant execute on [insert_new_position_gui] to dreamcareer
