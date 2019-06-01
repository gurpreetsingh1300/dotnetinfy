CREATE PROCEDURE usp_InsertPurchaseDetails
(
	@EmailId VARCHAR(50),
	@ProductId CHAR(4),
	@QuantityPurchased INT,
	@PurchaseId BIGINT OUTPUT
)
AS
BEGIN
	DECLARE @retval int
	SET @PurchaseId=0	
		BEGIN TRY
			IF (@EmailId IS NULL)
				SET @retval = -1
			ELSE IF NOT EXISTS (SELECT @EmailId FROM Users WHERE EmailId=@EmailId)
				SET @retval = -2
			ELSE IF (@ProductId IS NULL)
				SET @retval = -3
			ELSE IF NOT EXISTS (SELECT ProductId FROM Products WHERE ProductId=@ProductId)
				SET @retval = -4
			ELSE IF ((@QuantityPurchased<=0) OR (@QuantityPurchased IS NULL))
				SET @retval = -5
			ELSE
				BEGIN
					INSERT INTO PurchaseDetails VALUES (@EmailId, @ProductId, @QuantityPurchased, DEFAULT)
					SELECT @PurchaseId=IDENT_CURRENT('PurchaseDetails')
					UPDATE Products SET QuantityAvailable=QuantityAvailable-@QuantityPurchased WHERE ProductId=@ProductId			
					SET @retval = 1
				END
			SELECT @retval 
		END TRY
		BEGIN CATCH
			SET @PurchaseId=0			
			SET @retval = -99
			SELECT @retval 
		END CATCH
	END