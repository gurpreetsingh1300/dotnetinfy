CREATE PROCEDURE usp_AddProduct
(
	@ProductId CHAR(4),
	@ProductName VARCHAR(50),
	@CategoryId TINYINT,
	@Price NUMERIC(8),
	@QuantityAvailable INT
)
AS
BEGIN
	DECLARE @retval int
	BEGIN TRY
		IF (@ProductId IS NULL)
			SET @retval = -1
		ELSE IF (@ProductId NOT LIKE 'P%' or LEN(@ProductId)<>4)
			SET @retval = -2
		ELSE IF (@ProductName IS NULL)
			SET @retval = -3
		ELSE IF (@CategoryId IS NULL)
			SET @retval = -4
		ELSE IF NOT EXISTS(SELECT CategoryId FROM Categories WHERE CategoryId=@CategoryId)
			SET @retval = -5
		ELSE IF (@Price<=0 OR @Price IS NULL)
			SET @retval = -6
		ELSE IF (@QuantityAvailable<0 OR @QuantityAvailable IS NULL)
			SET @retval = -7
		ELSE
			BEGIN
				INSERT INTO Products VALUES 
				(@ProductId,@ProductName, @CategoryId, @Price, @QuantityAvailable)
				SET @retval = 1
			END
		SELECT @retval 
	END TRY
	BEGIN CATCH
		SET @retval = -99
		SELECT @retval 
	END CATCH
END