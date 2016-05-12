create procedure get_CompanyID(@oldpos varchar(50))
as
select positionid from position where positiontitle = @oldpos
go
grant execute on get_companyid to dreamcareer

          