Use ShopBridge
go

IF (OBJECT_ID('[usp_GetAllItems]') IS NOT NULL)
  DROP PROCEDURE [usp_GetAllItems]
GO
CREATE  PROCEDURE [dbo].[usp_GetAllItems]
AS
	BEGIN
	Select * from Items order by CreatedOn desc
	END
