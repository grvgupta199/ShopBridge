Use ShopBridge
go

IF (OBJECT_ID('[usp_DeleteItem]') IS NOT NULL)
  DROP PROCEDURE usp_DeleteItem
GO
Create Procedure usp_DeleteItem @id int
AS  
BEgin  
  
Delete From Items where id=@id
select 'success'
END


