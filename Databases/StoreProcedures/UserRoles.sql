IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'UserRoles_Add') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [UserRoles_Add]
GO

CREATE PROCEDURE [UserRoles_Add]
	@UserId INT,
	@RoleId INT
AS
BEGIN
	INSERT INTO [UserRoles]
	(
		[UserId],
		[RoleId]
	)
	VALUES
	(
		@UserId,
		@RoleId
	);
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'UserRoles_Update') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [UserRoles_Update]
GO

CREATE PROCEDURE [UserRoles_Update]
	@UserId INT,
	@RoleId INT
AS
BEGIN
	UPDATE	[UserRoles]
	SET [RoleId] = @RoleId
	WHERE	[UserId] = @UserId;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'UserRoles_Delete') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [UserRoles_Delete]
GO

CREATE PROCEDURE [UserRoles_Delete]
	@UserId INT,
	@RoleId INT
AS
BEGIN
	DELETE	FROM [UserRoles]
	WHERE	[UserId] = @UserId
	AND		[RoleId] = @RoleId;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'UserRoles_Get') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [UserRoles_Get]
GO

CREATE PROCEDURE [UserRoles_Get]
	@UserId INT,
	@RoleId INT
AS
BEGIN
	SELECT	[UserId],
			[RoleId]
	FROM	[UserRoles]
	WHERE	[UserId] = @UserId
	AND		[RoleId] = @RoleId;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'UserRoles_GetAll') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [UserRoles_GetAll]
GO

CREATE PROCEDURE [UserRoles_GetAll]
AS
BEGIN
	SELECT	[UserId],
			[RoleId]
	FROM	[UserRoles];
END;

GO
