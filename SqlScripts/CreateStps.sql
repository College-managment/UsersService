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

CREATE PROCEDURE usp_DeactivateUser
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Users
	SET IsActive = 0
	WHERE Id = @Id
END
GO

