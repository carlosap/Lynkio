IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'Networks_Add') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [Networks_Add]
GO

CREATE PROCEDURE [Networks_Add]
	@Id INT OUTPUT,
	@Name NVARCHAR(256),
	@PasswordHash NVARCHAR(MAX),
	@Notes NVARCHAR(MAX),
	@DateCreated DATETIME,
	@LastUpdate DATETIME
AS
BEGIN
	INSERT INTO [Networks]
	(
		[Name],
		[PasswordHash],
		[Notes],
		[DateCreated],
		[LastUpdate]
	)
	VALUES
	(
		@Name,
		@PasswordHash,
		@Notes,
		@DateCreated,
		@LastUpdate
	);

	SET @Id = SCOPE_IDENTITY();
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'Networks_Update') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [Networks_Update]
GO

CREATE PROCEDURE [Networks_Update]
	@Id INT,
	@Name NVARCHAR(256),
	@PasswordHash NVARCHAR(MAX),
	@Notes NVARCHAR(MAX),
	@DateCreated DATETIME,
	@LastUpdate DATETIME
AS
BEGIN
	UPDATE	[Networks]
	SET		[Name] = @Name,
			[PasswordHash] = @PasswordHash,
			[Notes] = @Notes,
			[DateCreated] = @DateCreated,
			[LastUpdate] = @LastUpdate
	WHERE	[Id] = @Id;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'Networks_Delete') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [Networks_Delete]
GO

CREATE PROCEDURE [Networks_Delete]
	@Id INT
AS
BEGIN
	DELETE	FROM [Networks]
	WHERE	[Id] = @Id;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'Networks_Get') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [Networks_Get]
GO

CREATE PROCEDURE [Networks_Get]
	@Id INT
AS
BEGIN
	SELECT	[Id],
			[Name],
			[PasswordHash],
			[Notes],
			[DateCreated],
			[LastUpdate]
	FROM	[Networks]
	WHERE	[Id] = @Id;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'Networks_GetAll') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [Networks_GetAll]
GO

CREATE PROCEDURE [Networks_GetAll]
AS
BEGIN
	SELECT	[Id],
			[Name],
			[PasswordHash],
			[Notes],
			[DateCreated],
			[LastUpdate]
	FROM	[Networks];
END;

GO
