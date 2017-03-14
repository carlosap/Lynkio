IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'Components_Add') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [Components_Add]
GO

CREATE PROCEDURE [Components_Add]
	@Id INT OUTPUT,
	@ProductId INT,
	@VendorId INT,
	@Name NVARCHAR(256),
	@Type NVARCHAR(100),
	@CRD NVARCHAR(10),
	@Unit NVARCHAR(50),
	@Symbol NVARCHAR(100),
	@PartNumber NVARCHAR(100),
	@LotNumber NVARCHAR(100),
	@Version NVARCHAR(100),
	@Nominal DECIMAL(18,0),
	@Min DECIMAL(18,0),
	@Max DECIMAL(18,0),
	@Rev NVARCHAR(100),
	@DateCode NVARCHAR(100),
	@Notes NVARCHAR(MAX),
	@DateCreated DATETIME,
	@LastUpdate DATETIME
AS
BEGIN
	INSERT INTO [Components]
	(
		[ProductId],
		[VendorId],
		[Name],
		[Type],
		[CRD],
		[Unit],
		[Symbol],
		[PartNumber],
		[LotNumber],
		[Version],
		[Nominal],
		[Min],
		[Max],
		[Rev],
		[DateCode],
		[Notes],
		[DateCreated],
		[LastUpdate]
	)
	VALUES
	(
		@ProductId,
		@VendorId,
		@Name,
		@Type,
		@CRD,
		@Unit,
		@Symbol,
		@PartNumber,
		@LotNumber,
		@Version,
		@Nominal,
		@Min,
		@Max,
		@Rev,
		@DateCode,
		@Notes,
		@DateCreated,
		@LastUpdate
	);

	SET @Id = SCOPE_IDENTITY();
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'Components_Update') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [Components_Update]
GO

CREATE PROCEDURE [Components_Update]
	@Id INT,
	@ProductId INT,
	@VendorId INT,
	@Name NVARCHAR(256),
	@Type NVARCHAR(100),
	@CRD NVARCHAR(10),
	@Unit NVARCHAR(50),
	@Symbol NVARCHAR(100),
	@PartNumber NVARCHAR(100),
	@LotNumber NVARCHAR(100),
	@Version NVARCHAR(100),
	@Nominal DECIMAL(18,0),
	@Min DECIMAL(18,0),
	@Max DECIMAL(18,0),
	@Rev NVARCHAR(100),
	@DateCode NVARCHAR(100),
	@Notes NVARCHAR(MAX),
	@DateCreated DATETIME,
	@LastUpdate DATETIME
AS
BEGIN
	UPDATE	[Components]
	SET		[ProductId] = @ProductId,
			[VendorId] = @VendorId,
			[Name] = @Name,
			[Type] = @Type,
			[CRD] = @CRD,
			[Unit] = @Unit,
			[Symbol] = @Symbol,
			[PartNumber] = @PartNumber,
			[LotNumber] = @LotNumber,
			[Version] = @Version,
			[Nominal] = @Nominal,
			[Min] = @Min,
			[Max] = @Max,
			[Rev] = @Rev,
			[DateCode] = @DateCode,
			[Notes] = @Notes,
			[DateCreated] = @DateCreated,
			[LastUpdate] = @LastUpdate
	WHERE	[Id] = @Id;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'Components_Delete') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [Components_Delete]
GO

CREATE PROCEDURE [Components_Delete]
	@Id INT
AS
BEGIN
	DELETE	FROM [Components]
	WHERE	[Id] = @Id;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'Components_Get') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [Components_Get]
GO

CREATE PROCEDURE [Components_Get]
	@Id INT
AS
BEGIN
	SELECT	[Id],
			[ProductId],
			[VendorId],
			[Name],
			[Type],
			[CRD],
			[Unit],
			[Symbol],
			[PartNumber],
			[LotNumber],
			[Version],
			[Nominal],
			[Min],
			[Max],
			[Rev],
			[DateCode],
			[Notes],
			[DateCreated],
			[LastUpdate]
	FROM	[Components]
	WHERE	[Id] = @Id;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'Components_GetAll') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [Components_GetAll]
GO

CREATE PROCEDURE [Components_GetAll]
AS
BEGIN
	SELECT	[Id],
			[ProductId],
			[VendorId],
			[Name],
			[Type],
			[CRD],
			[Unit],
			[Symbol],
			[PartNumber],
			[LotNumber],
			[Version],
			[Nominal],
			[Min],
			[Max],
			[Rev],
			[DateCode],
			[Notes],
			[DateCreated],
			[LastUpdate]
	FROM	[Components];
END;

GO
