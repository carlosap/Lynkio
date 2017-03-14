IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'ComponentClaims_Add') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [ComponentClaims_Add]
GO

CREATE PROCEDURE [ComponentClaims_Add]
	@Id INT OUTPUT,
	@ComponentId INT,
	@ClaimType NVARCHAR(MAX),
	@ClaimValue NVARCHAR(MAX)
AS
BEGIN
	INSERT INTO [ComponentClaims]
	(
		[ComponentId],
		[ClaimType],
		[ClaimValue]
	)
	VALUES
	(
		@ComponentId,
		@ClaimType,
		@ClaimValue
	);

	SET @Id = SCOPE_IDENTITY();
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'ComponentClaims_Update') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [ComponentClaims_Update]
GO

CREATE PROCEDURE [ComponentClaims_Update]
	@Id INT,
	@ComponentId INT,
	@ClaimType NVARCHAR(MAX),
	@ClaimValue NVARCHAR(MAX)
AS
BEGIN
	UPDATE	[ComponentClaims]
	SET		[ComponentId] = @ComponentId,
			[ClaimType] = @ClaimType,
			[ClaimValue] = @ClaimValue
	WHERE	[Id] = @Id;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'ComponentClaims_Delete') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [ComponentClaims_Delete]
GO

CREATE PROCEDURE [ComponentClaims_Delete]
	@Id INT
AS
BEGIN
	DELETE	FROM [ComponentClaims]
	WHERE	[Id] = @Id;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'ComponentClaims_Get') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [ComponentClaims_Get]
GO

CREATE PROCEDURE [ComponentClaims_Get]
	@Id INT
AS
BEGIN
	SELECT	[Id],
			[ComponentId],
			[ClaimType],
			[ClaimValue]
	FROM	[ComponentClaims]
	WHERE	[Id] = @Id;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'ComponentClaims_GetAll') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [ComponentClaims_GetAll]
GO

CREATE PROCEDURE [ComponentClaims_GetAll]
AS
BEGIN
	SELECT	[Id],
			[ComponentId],
			[ClaimType],
			[ClaimValue]
	FROM	[ComponentClaims];
END;

GO
