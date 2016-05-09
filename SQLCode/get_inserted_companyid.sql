use DreamCareer
go
alter procedure get_inserted_companyid(
	@name varchar(20))
as
declare @ans int
select @ans = company.CompanyID from company where company.Name = @name
go
grant execute on get_inserted_companyid to dreamcareer