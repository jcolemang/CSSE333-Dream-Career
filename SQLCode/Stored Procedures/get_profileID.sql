USE [DreamCareer]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[get_profileID](@oldpos varchar(50))
AS

	SELECT ProfileID 
	FROM DreamCareerUser, UserProfile
	WHERE DreamCareerUser.UserID = UserProfile.ProfileID
			AND @oldpos = DreamCareerUser.Username

GRANT EXECUTE ON get_profileID TO dreamcareer