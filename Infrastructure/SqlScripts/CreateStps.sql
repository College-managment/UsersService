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

CREATE PROCEDURE usp_UpdateUser
	@Id		INT,
	@Email	NVARCHAR(255)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Users
	SET Email = @Email, UpdatedDate = SYSUTCDATETIME()
	WHERE Id = @Id
END
GO

CREATE PROCEDURE usp_UpdateUserPassword
	@Id				INT,
	@PasswordHash	NVARCHAR(400)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Users
	SET PasswordHash = @PasswordHash, UpdatedDate = SYSUTCDATETIME()
	WHERE Id = @Id
END
GO

CREATE PROCEDURE usp_GetAllUsers
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Id, Email, PasswordHash, IsActive, CreatedDate, UpdatedDate
	FROM Users
END
GO

CREATE PROCEDURE usp_GetUserByEmail
	@Email NVARCHAR(255)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Id, Email, PasswordHash, IsActive, CreatedDate, UpdatedDate
	FROM Users
	Where Email = @Email
END
GO