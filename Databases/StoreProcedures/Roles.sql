IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'Roles_Add') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [Roles_Add]
GO

CREATE PROCEDURE [Roles_Add]
	@Id INT OUTPUT,
	@Name NVARCHAR(100),
	@Notes NVARCHAR(MAX)
AS
BEGIN
	INSERT INTO [Roles]
	(
		[Name],
		[Notes]
	)
	VALUES
	(
		@Name,
		@Notes
	);

	SET @Id = SCOPE_IDENTITY();
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'Roles_Update') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [Roles_Update]
GO

CREATE PROCEDURE [Roles_Update]
	@Id INT,
	@Name NVARCHAR(100),
	@Notes NVARCHAR(MAX)
AS
BEGIN
	UPDATE	[Roles]
	SET		[Name] = @Name,
			[Notes] = @Notes
	WHERE	[Id] = @Id;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'Roles_Delete') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [Roles_Delete]
GO

CREATE PROCEDURE [Roles_Delete]
	@Id INT
AS
BEGIN
	DELETE	FROM [Roles]
	WHERE	[Id] = @Id;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'Roles_Get') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [Roles_Get]
GO

CREATE PROCEDURE [Roles_Get]
	@Id INT
AS
BEGIN
	SELECT	[Id],
			[Name],
			[Notes]
	FROM	[Roles]
	WHERE	[Id] = @Id;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'Roles_GetAll') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [Roles_GetAll]
GO

CREATE PROCEDURE [Roles_GetAll]
AS
BEGIN
	SELECT	[Id],
			[Name],
			[Notes]
	FROM	[Roles];
END;

GO
