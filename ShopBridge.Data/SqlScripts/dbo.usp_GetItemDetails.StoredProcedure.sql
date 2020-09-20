Create Procedure usp_GetItemDetails @id int
AS  
BEgin  
  
Select * from Items where id=@id

END


