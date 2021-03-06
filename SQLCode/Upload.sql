USE [DreamCareer]
GO
/****** Object:  StoredProcedure [dbo].[upload]    Script Date: 5/19/2016 8:42:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[upload](@userid int, @posid int, @Name varchar(50), @ContentType nvarchar(200), @Data varbinary(max))
as

declare @idvalue int

SELECT @idvalue = id
FROM applyto
WHERE userid = @userid and PositionID = @posid
group by id;

BEGIN
update resume
set id = @idvalue, name = @name, [content type] = @ContentType, data = @Data
end

go
grant execute on upload to dreamcareer