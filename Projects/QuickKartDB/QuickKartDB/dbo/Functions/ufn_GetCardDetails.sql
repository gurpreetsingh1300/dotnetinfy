CREATE FUNCTION ufn_GetCardDetails(@CardNumber NUMERIC(16))
RETURNS TABLE 
AS
	RETURN (SELECT NameOnCard,CardType,CVVNumber,ExpiryDate,Balance FROM CardDetails WHERE CardNumber=@CardNumber)