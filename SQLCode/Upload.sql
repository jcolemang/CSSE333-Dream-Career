USE [DreamCareer]
GO

/****** Object:  StoredProcedure [dbo].[upload]    Script Date: 5/19/2016 12:10:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[upload](@userid int, @posid int, @Name varchar(50), @ContentType nvarchar(200), @Data varbinary(max))
as
INSERT INTO ApplyTo(name, [Content Type], Data) 
values(@name, @ContentType, @Data)
SELECT name, [Content Type], Data
FROM applyto
WHERE userid = @userid and positionid = @posid
GO


