IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'ProductClaims_Add') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [ProductClaims_Add]
GO

CREATE PROCEDURE [ProductClaims_Add]
	@Id INT OUTPUT,
	@ProductId INT,
	@ClaimType NVARCHAR(MAX),
	@ClaimValue NVARCHAR(MAX)
AS
BEGIN
	INSERT INTO [ProductClaims]
	(
		[ProductId],
		[ClaimType],
		[ClaimValue]
	)
	VALUES
	(
		@ProductId,
		@ClaimType,
		@ClaimValue
	);

	SET @Id = SCOPE_IDENTITY();
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'ProductClaims_Update') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [ProductClaims_Update]
GO

CREATE PROCEDURE [ProductClaims_Update]
	@Id INT,
	@ProductId INT,
	@ClaimType NVARCHAR(MAX),
	@ClaimValue NVARCHAR(MAX)
AS
BEGIN
	UPDATE	[ProductClaims]
	SET		[ProductId] = @ProductId,
			[ClaimType] = @ClaimType,
			[ClaimValue] = @ClaimValue
	WHERE	[Id] = @Id;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'ProductClaims_Delete') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [ProductClaims_Delete]
GO

CREATE PROCEDURE [ProductClaims_Delete]
	@Id INT
AS
BEGIN
	DELETE	FROM [ProductClaims]
	WHERE	[Id] = @Id;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'ProductClaims_Get') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [ProductClaims_Get]
GO

CREATE PROCEDURE [ProductClaims_Get]
	@Id INT
AS
BEGIN
	SELECT	[Id],
			[ProductId],
			[ClaimType],
			[ClaimValue]
	FROM	[ProductClaims]
	WHERE	[Id] = @Id;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'ProductClaims_GetAll') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [ProductClaims_GetAll]
GO

CREATE PROCEDURE [ProductClaims_GetAll]
AS
BEGIN
	SELECT	[Id],
			[ProductId],
			[ClaimType],
			[ClaimValue]
	FROM	[ProductClaims];
END;

GO
