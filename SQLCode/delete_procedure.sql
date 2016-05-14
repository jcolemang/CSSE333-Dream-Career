create procedure delete_position(@pos varchar(50))
as
delete from position where PositionTitle = @pos;
go
grant execute on delete_position to dreamcareer