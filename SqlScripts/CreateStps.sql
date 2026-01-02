CREATE PROCEDURE usp_InsertUser
	@Email			NVARCHAR(255),
	@PasswordHash	NVARCHAR(400)
AS 
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Users (Email, PasswordHash)
	VALUES (@Email, @PasswordHash)
END
GO

