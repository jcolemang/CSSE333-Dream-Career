USE [DreamCareer]
GO

/****** Object:  StoredProcedure [dbo].[checkif_username_in_database]    Script Date: 4/28/2016 6:58:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[checkif_username_in_database]
(@uname varchar(50))
as
if(@uname in (select Username from DreamCareerUser)) 
	begin 
	(select username from DreamCareerUser where @uname = Username) 
	end

GO
GRANT EXECUTE ON checkif_username_in_database TO dreamcareer