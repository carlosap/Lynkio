IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'Products_Add') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [Products_Add]
GO

CREATE PROCEDURE [Products_Add]
	@Id INT OUTPUT,
	@UserId INT,
	@Name NVARCHAR(256),
	@SerialNumber NVARCHAR(100),
	@ProductNumber NVARCHAR(100),
	@AssemblyNumber NVARCHAR(100),
	@Make NVARCHAR(100),
	@Model NVARCHAR(100),
	@Version NVARCHAR(100),
	@Author NVARCHAR(100),
	@License NVARCHAR(100),
	@Notes NVARCHAR(MAX),
	@ReportsTo INT,
	@DateCreated DATETIME,
	@LastUpdate DATETIME
AS
BEGIN
	INSERT INTO [Products]
	(
		[UserId],
		[Name],
		[SerialNumber],
		[ProductNumber],
		[AssemblyNumber],
		[Make],
		[Model],
		[Version],
		[Author],
		[License],
		[Notes],
		[ReportsTo],
		[DateCreated],
		[LastUpdate]
	)
	VALUES
	(
		@UserId,
		@Name,
		@SerialNumber,
		@ProductNumber,
		@AssemblyNumber,
		@Make,
		@Model,
		@Version,
		@Author,
		@License,
		@Notes,
		@ReportsTo,
		@DateCreated,
		@LastUpdate
	);

	SET @Id = SCOPE_IDENTITY();
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'Products_Update') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [Products_Update]
GO

CREATE PROCEDURE [Products_Update]
	@Id INT,
	@UserId INT,
	@Name NVARCHAR(256),
	@SerialNumber NVARCHAR(100),
	@ProductNumber NVARCHAR(100),
	@AssemblyNumber NVARCHAR(100),
	@Make NVARCHAR(100),
	@Model NVARCHAR(100),
	@Version NVARCHAR(100),
	@Author NVARCHAR(100),
	@License NVARCHAR(100),
	@Notes NVARCHAR(MAX),
	@ReportsTo INT,
	@DateCreated DATETIME,
	@LastUpdate DATETIME
AS
BEGIN
	UPDATE	[Products]
	SET		[UserId] = @UserId,
			[Name] = @Name,
			[SerialNumber] = @SerialNumber,
			[ProductNumber] = @ProductNumber,
			[AssemblyNumber] = @AssemblyNumber,
			[Make] = @Make,
			[Model] = @Model,
			[Version] = @Version,
			[Author] = @Author,
			[License] = @License,
			[Notes] = @Notes,
			[ReportsTo] = @ReportsTo,
			[DateCreated] = @DateCreated,
			[LastUpdate] = @LastUpdate
	WHERE	[Id] = @Id;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'Products_Delete') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [Products_Delete]
GO

CREATE PROCEDURE [Products_Delete]
	@Id INT
AS
BEGIN
	DELETE	FROM [Products]
	WHERE	[Id] = @Id;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'Products_Get') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [Products_Get]
GO

CREATE PROCEDURE [Products_Get]
	@Id INT
AS
BEGIN
	SELECT	[Id],
			[UserId],
			[Name],
			[SerialNumber],
			[ProductNumber],
			[AssemblyNumber],
			[Make],
			[Model],
			[Version],
			[Author],
			[License],
			[Notes],
			[ReportsTo],
			[DateCreated],
			[LastUpdate]
	FROM	[Products]
	WHERE	[Id] = @Id;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'Products_GetAll') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [Products_GetAll]
GO

CREATE PROCEDURE [Products_GetAll]
AS
BEGIN
	SELECT	[Id],
			[UserId],
			[Name],
			[SerialNumber],
			[ProductNumber],
			[AssemblyNumber],
			[Make],
			[Model],
			[Version],
			[Author],
			[License],
			[Notes],
			[ReportsTo],
			[DateCreated],
			[LastUpdate]
	FROM	[Products];
END;

GO
