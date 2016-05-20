USE [DreamCareer]
GO
/****** Object:  StoredProcedure [dbo].[insert_apply]    Script Date: 5/19/2016 2:28:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[insert_apply]
	(@userid int,
	@posid int)
AS
DECLARE @retVal int
SELECT @retVal = COUNT(*) 
FROM applyto
WHERE userid = @userid and PositionID = @posid

IF (@retVal > 0)
Begin
	INSERT INTO ApplyTo
	(UserID, PositionID)
	VALUES
	(@userid, @posid)
End

else
begin
	INSERT INTO ApplyTo(userid, positionid) 
	values(@userid, @posid)
end
