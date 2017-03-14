IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'UserClaims_Add') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [UserClaims_Add]
GO

CREATE PROCEDURE [UserClaims_Add]
	@Id INT OUTPUT,
	@ClaimType NVARCHAR(MAX),
	@ClaimValue NVARCHAR(MAX),
	@UserId INT
AS
BEGIN
	INSERT INTO [UserClaims]
	(
		[ClaimType],
		[ClaimValue],
		[UserId]
	)
	VALUES
	(
		@ClaimType,
		@ClaimValue,
		@UserId
	);

	SET @Id = SCOPE_IDENTITY();
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'UserClaims_Update') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [UserClaims_Update]
GO

CREATE PROCEDURE [UserClaims_Update]
	@Id INT,
	@ClaimType NVARCHAR(MAX),
	@ClaimValue NVARCHAR(MAX),
	@UserId INT
AS
BEGIN
	UPDATE	[UserClaims]
	SET		[ClaimType] = @ClaimType,
			[ClaimValue] = @ClaimValue,
			[UserId] = @UserId
	WHERE	[Id] = @Id;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'UserClaims_Delete') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [UserClaims_Delete]
GO

CREATE PROCEDURE [UserClaims_Delete]
	@Id INT
AS
BEGIN
	DELETE	FROM [UserClaims]
	WHERE	[Id] = @Id;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'UserClaims_Get') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [UserClaims_Get]
GO

CREATE PROCEDURE [UserClaims_Get]
	@Id INT
AS
BEGIN
	SELECT	[Id],
			[ClaimType],
			[ClaimValue],
			[UserId]
	FROM	[UserClaims]
	WHERE	[Id] = @Id;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'UserClaims_GetAll') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [UserClaims_GetAll]
GO

CREATE PROCEDURE [UserClaims_GetAll]
AS
BEGIN
	SELECT	[Id],
			[ClaimType],
			[ClaimValue],
			[UserId]
	FROM	[UserClaims];
END;

GO
