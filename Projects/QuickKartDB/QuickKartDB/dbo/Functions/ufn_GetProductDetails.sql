CREATE FUNCTION ufn_GetProductDetails(@CategoryId INT)
RETURNS TABLE 
AS
RETURN (SELECT ProductId,ProductName,Price,QuantityAvailable FROM Products WHERE CategoryId=@CategoryId)