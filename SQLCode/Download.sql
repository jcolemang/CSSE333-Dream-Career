use dreamcareer
go
create procedure download(@id int)
as
select Name, applyto.[Content Type], Data from ApplyTo where Id=@Id
go
grant execute on download to dreamcareer