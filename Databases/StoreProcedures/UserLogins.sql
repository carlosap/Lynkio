IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'UserLogins_Add') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [UserLogins_Add]
GO

CREATE PROCEDURE [UserLogins_Add]
	@LoginProvider NVARCHAR(450),
	@ProviderKey NVARCHAR(450),
	@ProviderDisplayName NVARCHAR(MAX),
	@UserId INT
AS
BEGIN
	INSERT INTO [UserLogins]
	(
		[LoginProvider],
		[ProviderKey],
		[ProviderDisplayName],
		[UserId]
	)
	VALUES
	(
		@LoginProvider,
		@ProviderKey,
		@ProviderDisplayName,
		@UserId
	);
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'UserLogins_Update') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [UserLogins_Update]
GO

CREATE PROCEDURE [UserLogins_Update]
	@LoginProvider NVARCHAR(450),
	@ProviderKey NVARCHAR(450),
	@ProviderDisplayName NVARCHAR(MAX),
	@UserId INT
AS
BEGIN
	UPDATE	[UserLogins]
	SET		[ProviderDisplayName] = @ProviderDisplayName,
			[UserId] = @UserId
	WHERE	[LoginProvider] = @LoginProvider
	AND		[ProviderKey] = @ProviderKey;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'UserLogins_Delete') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [UserLogins_Delete]
GO

CREATE PROCEDURE [UserLogins_Delete]
	@LoginProvider NVARCHAR(450),
	@ProviderKey NVARCHAR(450)
AS
BEGIN
	DELETE	FROM [UserLogins]
	WHERE	[LoginProvider] = @LoginProvider
	AND		[ProviderKey] = @ProviderKey;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'UserLogins_Get') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [UserLogins_Get]
GO

CREATE PROCEDURE [UserLogins_Get]
	@LoginProvider NVARCHAR(450),
	@ProviderKey NVARCHAR(450)
AS
BEGIN
	SELECT	[LoginProvider],
			[ProviderKey],
			[ProviderDisplayName],
			[UserId]
	FROM	[UserLogins]
	WHERE	[LoginProvider] = @LoginProvider
	AND		[ProviderKey] = @ProviderKey;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'UserLogins_GetAll') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [UserLogins_GetAll]
GO

CREATE PROCEDURE [UserLogins_GetAll]
AS
BEGIN
	SELECT	[LoginProvider],
			[ProviderKey],
			[ProviderDisplayName],
			[UserId]
	FROM	[UserLogins];
END;

GO
