CREATE PROCEDURE usp_RegisterUser
(
	@UserPassword VARCHAR(15),
	@Gender CHAR,
	@EmailId VARCHAR(50),
	@DateOfBirth DATE,
	@Address VARCHAR(200)
)
AS
BEGIN
	DECLARE @RoleId TINYINT,
		@retval int
	BEGIN TRY
		IF (LEN(@EmailId)<4 OR LEN(@EmailId)>50 OR (@EmailId IS NULL))
			SET @retval = -1
		ELSE IF (LEN(@UserPassword)<8 OR LEN(@UserPassword)>15 OR (@UserPassword IS NULL))
			SET @retval = -2
		ELSE IF (@Gender<>'F' AND @Gender<>'M' OR (@Gender Is NULL))
			SET @retval = -3		
		ELSE IF (@DateOfBirth>=CAST(GETDATE() AS DATE) OR (@DateOfBirth IS NULL))
			SET @retval = -4
		ELSE IF DATEDIFF(d,@DateOfBirth,GETDATE())<6570
			SET @retval = -5
		ELSE IF (@Address IS NULL)
			SET @retval = -6
		ELSE
			BEGIN
				SELECT @RoleId=RoleId FROM Roles WHERE RoleName='Customer'
				INSERT INTO Users VALUES 
				(@EmailId,@UserPassword, @RoleId, @Gender, @DateOfBirth, @Address)
				SET @retval = 1			
			END
		SELECT @retval 
		END TRY
		BEGIN CATCH
			SET @retval = -99
			SELECT @retval 
		END CATCH
		
END