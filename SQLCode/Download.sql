USE [DreamCareer]
GO
/****** Object:  StoredProcedure [dbo].[download]    Script Date: 5/19/2016 9:09:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[download](@id int)
as
select Name, [Content Type], Data from resume where id = @id
go
grant execute on download to dreamcareer
