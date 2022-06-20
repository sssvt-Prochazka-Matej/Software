use master
go

create database DbSoftware
go

use DbSoftware
go

if exists(select * from sys.tables where name = 'tb_License')
drop table tb_License
go

create table tb_License(
	ID int identity(1,1) not null,
	LicenseName nvarchar(100) not null,
	Terms nvarchar(2000) null,
	Primary key(ID)
)

if exists(select * from sys.tables where name = 'tb_Software')
drop table tb_Software
go

create table tb_Software(
	ID int identity(1,1) not null,
	Name nvarchar(50) not null,
	Provider nvarchar(50) not null,
	Version int not null,
	ReleaseDate datetime not null,
	LicenseId int not null,
	primary key(ID),
	foreign key (LicenseId) references tb_License(ID)
)