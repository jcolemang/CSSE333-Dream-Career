use DreamCareer
go
ALTER procedure get_inserted_companyid(
	@name varchar(20))
as
declare @ans int
select company.CompanyID from company where company.Name = @name
go
grant execute on get_inserted_companyid to dreamcareer