USE [DreamCareer]
GO
/****** Object:  StoredProcedure [dbo].[delete_position]    Script Date: 5/20/2016 12:09:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[delete_position](@pos int)
as
delete from position where Positionid = @pos;
go
grant execute on delete_position to dreamcareer
