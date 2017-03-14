IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'UserNetworks_Add') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [UserNetworks_Add]
GO

CREATE PROCEDURE [UserNetworks_Add]
	@UserId INT,
	@NetworkId INT
AS
BEGIN
	INSERT INTO [UserNetworks]
	(
		[UserId],
		[NetworkId]
	)
	VALUES
	(
		@UserId,
		@NetworkId
	);
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'UserNetworks_Update') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [UserNetworks_Update]
GO

CREATE PROCEDURE [UserNetworks_Update]
	@UserId INT,
	@NetworkId INT
AS
BEGIN
	UPDATE	[UserNetworks]
	SET		[NetworkId] = @NetworkId
	WHERE	[UserId] = @UserId

END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'UserNetworks_Delete') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [UserNetworks_Delete]
GO

CREATE PROCEDURE [UserNetworks_Delete]
	@UserId INT,
	@NetworkId INT
AS
BEGIN
	DELETE	FROM [UserNetworks]
	WHERE	[UserId] = @UserId
	AND		[NetworkId] = @NetworkId;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'UserNetworks_Get') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [UserNetworks_Get]
GO

CREATE PROCEDURE [UserNetworks_Get]
	@UserId INT,
	@NetworkId INT
AS
BEGIN
	SELECT	[UserId],
			[NetworkId]
	FROM	[UserNetworks]
	WHERE	[UserId] = @UserId
	AND		[NetworkId] = @NetworkId;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'UserNetworks_GetAll') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [UserNetworks_GetAll]
GO

CREATE PROCEDURE [UserNetworks_GetAll]
AS
BEGIN
	SELECT	[UserId],
			[NetworkId]
	FROM	[UserNetworks];
END;

GO
