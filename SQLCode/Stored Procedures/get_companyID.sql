USE [DreamCareer]
GO
/****** Object:  StoredProcedure [dbo].[get_CompanyID]    Script Date: 5/12/2016 6:21:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[get_CompanyID](@oldpos varchar(50))
as
select companyid from position where positiontitle = @oldpos
