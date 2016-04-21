use master
go

Create Database [DreamCareerSpring2016] 
on Primary( 
	Name = [Lab3-2_gibsonjc],
	Filename = 'C:\Program Files\Microsoft SQL Server\MSSQL11.TITAN\MSSQL\DATA\DreamCareerSpring2016.mdf',
	Size = 10MB,
	MaxSize = 512MB,
	FileGrowth = 10%
) log on(
	Name = [DreamCareerSpring2016Log],
	Filename = 'C:\Program Files\Microsoft SQL Server\MSSQL11.TITAN\MSSQL\DATA\DreamCareerSpring2016.ldf',
	Size = 10MB,
	MaxSize = 512MB,
	FileGrowth = 20%
)