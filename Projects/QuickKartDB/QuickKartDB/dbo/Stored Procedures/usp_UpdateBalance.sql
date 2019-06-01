CREATE PROCEDURE usp_UpdateBalance
(
	@CardNumber NUMERIC(16),
	@NameOnCard VARCHAR(40),
	@CardType CHAR(6),
	@CVVNumber NUMERIC(3),
	@ExpiryDate DATE,
	@Price DECIMAL(8)
)
AS
BEGIN
	DECLARE @TempUserName VARCHAR(40), @TempCardType CHAR(6), @TempCVVNumber NUMERIC(3), @TempExpiryDate DATE, @Balance DECIMAL(8), @retval int
	BEGIN TRY
		IF (@CardNumber IS NULL)
			SET @retval = -1
		ELSE IF NOT EXISTS(SELECT * FROM CardDetails WHERE CardNumber=@CardNumber)
			SET @retval = -2
		ELSE
			BEGIN
				SELECT @TempUserName=NameOnCard, @TempCardType=CardType, @TempCVVNumber=CVVNumber, @TempExpiryDate=ExpiryDate, @Balance=Balance 
				FROM CardDetails 
				WHERE CardNumber=@CardNumber
				IF ((@TempUserName<>@NameOnCard) OR (@NameOnCard IS NULL))
					SET @retval = -3
				ELSE IF ((@TempCardType<>@CardType) OR (@CardType IS NULL))
					SET @retval = -4
				ELSE IF ((@TempCVVNumber<>@CVVNumber) OR (@CVVNumber IS NULL))
					SET @retval = -5			
				ELSE IF ((@TempExpiryDate<>@ExpiryDate) OR (@ExpiryDate IS NULL))
					SET @retval = -6
				ELSE IF ((@Balance<@Price) OR (@Price IS NULL))
					SET @retval = -7
				ELSE
					BEGIN
						UPDATE Carddetails SET Balance=Balance-@Price WHERE CardNumber=@CardNumber
						SET @retval = 1
					END
			END
		SELECT @retval 
	END TRY
	BEGIN CATCH
		SET @retval = -99
		SELECT @retval 
	END CATCH
END