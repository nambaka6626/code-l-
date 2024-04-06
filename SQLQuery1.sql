create database product_management 

go
use product_management

go
create table dbo.category
(	
	category_id int primary key not null,
	category_name varchar(100) not null,
	note varchar(100) null
)
insert into dbo.category values (1, 'Laptop', 'Cate1')
insert into dbo.category values (2, 'TV', 'Cate2')
insert into dbo.category values (3, 'PC', 'Cate3')
insert into dbo.category values (4, 'Phone', 'Cate4')

go
create table dbo.product
(
	product_id int primary key not null,
	product_name varchar(100) not null,
	quantity int not null,
	category_id int foreign key references dbo.category(category_id) null
)
insert into dbo.product values (1, 'Laptop Dell', 5, 1)
insert into dbo.product values (2, 'TV Samsung', 3, 2)
insert into dbo.product values (3, 'PC gaming', 6, 3)
insert into dbo.product values (4, 'Iphone', 7, 4)

go 
create table dbo.account(
	username varchar(100) primary key not null,
	u_password varchar(100) not null,
	u_role varchar(10) null
	)
insert into dbo.account values ('admin', 'admin', 'admin')
insert into dbo.account values ('user', 'user', 'user')
insert into dbo.account values ('test', 'test', 'test')

select * from dbo.account;
select * from product;
select * from category;