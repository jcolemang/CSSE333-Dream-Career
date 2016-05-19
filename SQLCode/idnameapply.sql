 
create procedure idnameapply
as
select id, Name 
from dbo.ApplyTo 
go 
GRANT execute on idnameapply TO DreamCareer