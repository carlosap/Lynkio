IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'Users_Add') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [Users_Add]
GO

CREATE PROCEDURE [Users_Add]
	@Id INT OUTPUT,
	@UserName NVARCHAR(100),
	@FirstName NVARCHAR(100),
	@LastName NVARCHAR(100),
	@Email NVARCHAR(256),
	@EmailConfirmed BIT,
	@EmailNotification BIT,
	@PasswordHash NVARCHAR(MAX),
	@PhoneNumber NVARCHAR(MAX),
	@PhoneNumberConfirmed BIT,
	@PhoneNotification BIT,
	@AccessFailedCount INT,
	@SecurityStamp NVARCHAR(MAX),
	@ConcurrencyStamp NVARCHAR(MAX),
	@LockoutEnabled BIT,
	@LockoutEnd DATETIMEOFFSET(7),
	@NormalizedEmail NVARCHAR(256),
	@NormalizedUserName NVARCHAR(256),
	@TwoFactorEnabled BIT,
	@ReportsTo NVARCHAR(450),
	@DateCreated DATETIME,
	@LastUpdate DATETIME
AS
BEGIN
	INSERT INTO [Users]
	(
		[UserName],
		[FirstName],
		[LastName],
		[Email],
		[EmailConfirmed],
		[EmailNotification],
		[PasswordHash],
		[PhoneNumber],
		[PhoneNumberConfirmed],
		[PhoneNotification],
		[AccessFailedCount],
		[SecurityStamp],
		[ConcurrencyStamp],
		[LockoutEnabled],
		[LockoutEnd],
		[NormalizedEmail],
		[NormalizedUserName],
		[TwoFactorEnabled],
		[ReportsTo],
		[DateCreated],
		[LastUpdate]
	)
	VALUES
	(
		@UserName,
		@FirstName,
		@LastName,
		@Email,
		@EmailConfirmed,
		@EmailNotification,
		@PasswordHash,
		@PhoneNumber,
		@PhoneNumberConfirmed,
		@PhoneNotification,
		@AccessFailedCount,
		@SecurityStamp,
		@ConcurrencyStamp,
		@LockoutEnabled,
		@LockoutEnd,
		@NormalizedEmail,
		@NormalizedUserName,
		@TwoFactorEnabled,
		@ReportsTo,
		@DateCreated,
		@LastUpdate
	);

	SET @Id = SCOPE_IDENTITY();
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'Users_Update') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [Users_Update]
GO

CREATE PROCEDURE [Users_Update]
	@Id INT,
	@UserName NVARCHAR(100),
	@FirstName NVARCHAR(100),
	@LastName NVARCHAR(100),
	@Email NVARCHAR(256),
	@EmailConfirmed BIT,
	@EmailNotification BIT,
	@PasswordHash NVARCHAR(MAX),
	@PhoneNumber NVARCHAR(MAX),
	@PhoneNumberConfirmed BIT,
	@PhoneNotification BIT,
	@AccessFailedCount INT,
	@SecurityStamp NVARCHAR(MAX),
	@ConcurrencyStamp NVARCHAR(MAX),
	@LockoutEnabled BIT,
	@LockoutEnd DATETIMEOFFSET(7),
	@NormalizedEmail NVARCHAR(256),
	@NormalizedUserName NVARCHAR(256),
	@TwoFactorEnabled BIT,
	@ReportsTo NVARCHAR(450),
	@DateCreated DATETIME,
	@LastUpdate DATETIME
AS
BEGIN
	UPDATE	[Users]
	SET		[UserName] = @UserName,
			[FirstName] = @FirstName,
			[LastName] = @LastName,
			[Email] = @Email,
			[EmailConfirmed] = @EmailConfirmed,
			[EmailNotification] = @EmailNotification,
			[PasswordHash] = @PasswordHash,
			[PhoneNumber] = @PhoneNumber,
			[PhoneNumberConfirmed] = @PhoneNumberConfirmed,
			[PhoneNotification] = @PhoneNotification,
			[AccessFailedCount] = @AccessFailedCount,
			[SecurityStamp] = @SecurityStamp,
			[ConcurrencyStamp] = @ConcurrencyStamp,
			[LockoutEnabled] = @LockoutEnabled,
			[LockoutEnd] = @LockoutEnd,
			[NormalizedEmail] = @NormalizedEmail,
			[NormalizedUserName] = @NormalizedUserName,
			[TwoFactorEnabled] = @TwoFactorEnabled,
			[ReportsTo] = @ReportsTo,
			[DateCreated] = @DateCreated,
			[LastUpdate] = @LastUpdate
	WHERE	[Id] = @Id;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'Users_Delete') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [Users_Delete]
GO

CREATE PROCEDURE [Users_Delete]
	@Id INT
AS
BEGIN
	DELETE	FROM [Users]
	WHERE	[Id] = @Id;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'Users_Get') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [Users_Get]
GO

CREATE PROCEDURE [Users_Get]
	@Id INT
AS
BEGIN
	SELECT	[Id],
			[UserName],
			[FirstName],
			[LastName],
			[Email],
			[EmailConfirmed],
			[EmailNotification],
			[PasswordHash],
			[PhoneNumber],
			[PhoneNumberConfirmed],
			[PhoneNotification],
			[AccessFailedCount],
			[SecurityStamp],
			[ConcurrencyStamp],
			[LockoutEnabled],
			[LockoutEnd],
			[NormalizedEmail],
			[NormalizedUserName],
			[TwoFactorEnabled],
			[ReportsTo],
			[DateCreated],
			[LastUpdate]
	FROM	[Users]
	WHERE	[Id] = @Id;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'Users_GetAll') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [Users_GetAll]
GO

CREATE PROCEDURE [Users_GetAll]
AS
BEGIN
	SELECT	[Id],
			[UserName],
			[FirstName],
			[LastName],
			[Email],
			[EmailConfirmed],
			[EmailNotification],
			[PasswordHash],
			[PhoneNumber],
			[PhoneNumberConfirmed],
			[PhoneNotification],
			[AccessFailedCount],
			[SecurityStamp],
			[ConcurrencyStamp],
			[LockoutEnabled],
			[LockoutEnd],
			[NormalizedEmail],
			[NormalizedUserName],
			[TwoFactorEnabled],
			[ReportsTo],
			[DateCreated],
			[LastUpdate]
	FROM	[Users];
END;

GO
