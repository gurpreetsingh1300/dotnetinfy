CREATE FUNCTION ufn_ValidateUserCredentials
(
                @EmailId VARCHAR(50),
                @UserPassword VARCHAR(15)
)
RETURNS INT
AS
BEGIN
DECLARE @RoleId INT

                                SELECT @RoleId=RoleId FROM Users WHERE EmailId=@EmailId AND UserPassword=@UserPassword
                                
                                RETURN @RoleId
END