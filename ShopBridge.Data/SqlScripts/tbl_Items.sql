
use ShopBridge
Go

Create Table Items
(
ID int primary key identity(1,1),
Name varchar(250),
Description varchar(max),
Price float,
ImagePath varchar(500),
CreatedOn datetime

)

