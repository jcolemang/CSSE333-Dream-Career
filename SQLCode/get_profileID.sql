USE [DreamCareer]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[get_profileID](@oldpos varchar(50))
as
select ProfileID from UserProfile where Name = @oldpos;

Go
GRANT EXECUTE ON get_profileID TO dreamcareer 