Use ShopBridge
go

IF (OBJECT_ID('[usp_GetItemDetails]') IS NOT NULL)
  DROP PROCEDURE usp_GetItemDetails
GO
Create Procedure usp_GetItemDetails @id int
AS  
BEgin  
  
Select * from Items where id=@id

END


