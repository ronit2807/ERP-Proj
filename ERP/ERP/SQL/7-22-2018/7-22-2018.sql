create database ERP
go
use ERP
go
create table t_master_group(
id bigint identity(1,1) primary key,
groupName varchar(100)
)
go

Create table t_master_user(
id bigint identity(1,1) primary key,
userName varchar(100),
loginId varchar(100),
userPass varchar(500),
groupId bigint references t_master_group(id),
isActive bit
)