USE [DreamCareer]
GO
/****** Object:  StoredProcedure [dbo].[checkif_name_in_database]    Script Date: 5/5/2016 10:27:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[checkif_name_in_database]
(@name varchar(50))
as
if(@name in (select name from company)) 
	begin 
	(select name from company where @name = name) 
	end
go
grant execute on dbo.checkif_name_in_database to dreamcareer