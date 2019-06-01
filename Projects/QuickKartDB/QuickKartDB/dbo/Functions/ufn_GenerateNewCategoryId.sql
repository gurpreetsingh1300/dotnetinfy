CREATE FUNCTION ufn_GenerateNewCategoryId()
RETURNS INT
AS
BEGIN

	DECLARE @CategoryId INT
	
	IF NOT EXISTS(SELECT ProductId FROM Products)
		SET @CategoryId ='1'
		
	ELSE
		SELECT @CategoryId =MAX(CategoryId)+1 FROM Categories

	RETURN @CategoryId 
	
END