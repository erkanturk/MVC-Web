Create database ETradeDb
go
use ETradeDb

create table Categories(
CategoryId int primary key identity(1,1),
[Name] nvarchar(200) not null
)
Create table Products(
ProductId int primary key identity(1,1),
[Name] nvarchar(200)not null,
Price decimal(18,2)not null,
CategoryId int foreign key references Categories(CategoryId)
)

