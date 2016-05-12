use dreamcareer
go
create procedure get_positionIdold(@oldpos varchar(50))
as
select positionid from position where positiontitle = @oldpos;
go
grant execute on get_positionidold to dreamcareer