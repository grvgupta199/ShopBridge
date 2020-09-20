CREATE  PROCEDURE [dbo].[usp_GetAllItems]
AS
	BEGIN
	Select * from Items order by CreatedOn desc
	END
