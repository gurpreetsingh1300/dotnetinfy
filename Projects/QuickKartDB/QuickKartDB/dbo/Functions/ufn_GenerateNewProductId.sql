CREATE FUNCTION ufn_GenerateNewProductId()
RETURNS CHAR(4)
AS
BEGIN

	DECLARE @ProductId CHAR(4)
	
	IF NOT EXISTS(SELECT ProductId FROM Products)
		SET @ProductId='P100'
		
	ELSE
		SELECT @ProductId='P'+CAST(CAST(SUBSTRING(MAX(ProductId),2,3) AS INT)+1 AS CHAR) FROM Products

	RETURN @ProductId
	
END