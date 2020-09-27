Use ShopBridge
go

IF (OBJECT_ID('[usp_AddItem]') IS NOT NULL)
  DROP PROCEDURE usp_AddItem
GO
Create Procedure usp_AddItem @name varchar(250),@description varchar(max),@price float,@imagePath varchar(500)
AS
BEgin

Insert Into Items(Name,Description,Price,ImagePath,CreatedOn)Values(@name,@description,@price,@imagePath,GETDATE())
select 'success'
END