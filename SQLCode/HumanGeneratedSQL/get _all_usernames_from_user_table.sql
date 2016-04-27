use DreamCareer
go
create procedure get_all_usernames_from_user_table
as
select * from DreamCareerUser
go
grant execute on get_all_usernames_from_user_table to dreamcareer