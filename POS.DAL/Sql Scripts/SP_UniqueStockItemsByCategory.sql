
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kalana>
-- Create date: <Create Date,,2022-02-16>
-- Description:	<Description,,Fetch Unique items in the inventrory table by given category Id>
-- =============================================
CREATE PROCEDURE SP_UniqueStockItemsByCategory
@CategoryId int
AS
BEGIN
	SELECT distinct 
	[ItemId],
	i.Code,
	i.Barcode,
	i.[Name]
	FROM [Inventories] inv
	INNER JOIN [Items] i ON inv.ItemId = i.Id
	WHERE i.CategoryId = @CategoryId
END
GO
