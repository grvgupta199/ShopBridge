
use ShopBridge
Go

if OBJECT_ID('Items') is not null
drop table Items
Create Table Items
(
ID int primary key identity(1,1),
Name varchar(250),
Description varchar(max),
Price float,
ImagePath varchar(500),
CreatedOn datetime

)


INSERT [dbo].[Items] ([Name], [Description], [Price], [ImagePath], [CreatedOn])
 VALUES 
 ( N'Item', N'Th', 48, N'', CAST(N'2020-09-27 13:34:47.707' AS DateTime))
, ( N'Item2', N'rt', 43, N'/Uploads/index445_637368107054581850.jpg', CAST(N'2020-09-27 13:38:26.977' AS DateTime))
, ( N'Item1', N'this is description', 34, N'/Uploads/index55_637368107987994070.jpg', CAST(N'2020-09-27 13:40:02.583' AS DateTime))
, (N'Item3', N'', 5, N'/Uploads/index_637368108256228140.jpg', CAST(N'2020-09-27 13:40:25.650' AS DateTime))



