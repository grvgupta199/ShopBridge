Create Procedure usp_DeleteItem @id int
AS  
BEgin  
  
Delete From Items where id=@id
select 'success'
END


