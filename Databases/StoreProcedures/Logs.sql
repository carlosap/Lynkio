IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'Logs_Add') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [Logs_Add]
GO

CREATE PROCEDURE [Logs_Add]
	@Id INT OUTPUT,
	@ProductId INT,
	@ComponentId INT,
	@CompanyId INT,
	@RunId INT,
	@StepNum INT,
	@Name NVARCHAR(256),
	@AppName NVARCHAR(100),
	@Status NVARCHAR(100),
	@Type NVARCHAR(100),
	@Build NVARCHAR(50),
	@Platform NVARCHAR(100),
	@Category NVARCHAR(100),
	@Process NVARCHAR(100),
	@Outcome NVARCHAR(100),
	@OutcomeFilePath NVARCHAR(MAX),
	@OutcomeRaw NVARCHAR(MAX),
	@MachineName NVARCHAR(100),
	@RunBy NVARCHAR(100),
	@MeasValue DECIMAL(18,0),
	@Min DECIMAL(18,0),
	@Max DECIMAL(18,0),
	@ExpectedPhrase NVARCHAR(MAX),
	@Notes NVARCHAR(MAX),
	@ErrorStack NVARCHAR(MAX),
	@StartTime DATETIME,
	@EndTime DATETIME,
	@ReportsTo INT,
	@DateCreated DATETIME
AS
BEGIN
	INSERT INTO [Logs]
	(
		[ProductId],
		[ComponentId],
		[CompanyId],
		[RunId],
		[StepNum],
		[Name],
		[AppName],
		[Status],
		[Type],
		[Build],
		[Platform],
		[Category],
		[Process],
		[Outcome],
		[OutcomeFilePath],
		[OutcomeRaw],
		[MachineName],
		[RunBy],
		[MeasValue],
		[Min],
		[Max],
		[ExpectedPhrase],
		[Notes],
		[ErrorStack],
		[StartTime],
		[EndTime],
		[ReportsTo],
		[DateCreated]
	)
	VALUES
	(
		@ProductId,
		@ComponentId,
		@CompanyId,
		@RunId,
		@StepNum,
		@Name,
		@AppName,
		@Status,
		@Type,
		@Build,
		@Platform,
		@Category,
		@Process,
		@Outcome,
		@OutcomeFilePath,
		@OutcomeRaw,
		@MachineName,
		@RunBy,
		@MeasValue,
		@Min,
		@Max,
		@ExpectedPhrase,
		@Notes,
		@ErrorStack,
		@StartTime,
		@EndTime,
		@ReportsTo,
		@DateCreated
	);

	SET @Id = SCOPE_IDENTITY();
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'Logs_Update') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [Logs_Update]
GO

CREATE PROCEDURE [Logs_Update]
	@Id INT,
	@ProductId INT,
	@ComponentId INT,
	@CompanyId INT,
	@RunId INT,
	@StepNum INT,
	@Name NVARCHAR(256),
	@AppName NVARCHAR(100),
	@Status NVARCHAR(100),
	@Type NVARCHAR(100),
	@Build NVARCHAR(50),
	@Platform NVARCHAR(100),
	@Category NVARCHAR(100),
	@Process NVARCHAR(100),
	@Outcome NVARCHAR(100),
	@OutcomeFilePath NVARCHAR(MAX),
	@OutcomeRaw NVARCHAR(MAX),
	@MachineName NVARCHAR(100),
	@RunBy NVARCHAR(100),
	@MeasValue DECIMAL(18,0),
	@Min DECIMAL(18,0),
	@Max DECIMAL(18,0),
	@ExpectedPhrase NVARCHAR(MAX),
	@Notes NVARCHAR(MAX),
	@ErrorStack NVARCHAR(MAX),
	@StartTime DATETIME,
	@EndTime DATETIME,
	@ReportsTo INT,
	@DateCreated DATETIME
AS
BEGIN
	UPDATE	[Logs]
	SET		[ProductId] = @ProductId,
			[ComponentId] = @ComponentId,
			[CompanyId] = @CompanyId,
			[RunId] = @RunId,
			[StepNum] = @StepNum,
			[Name] = @Name,
			[AppName] = @AppName,
			[Status] = @Status,
			[Type] = @Type,
			[Build] = @Build,
			[Platform] = @Platform,
			[Category] = @Category,
			[Process] = @Process,
			[Outcome] = @Outcome,
			[OutcomeFilePath] = @OutcomeFilePath,
			[OutcomeRaw] = @OutcomeRaw,
			[MachineName] = @MachineName,
			[RunBy] = @RunBy,
			[MeasValue] = @MeasValue,
			[Min] = @Min,
			[Max] = @Max,
			[ExpectedPhrase] = @ExpectedPhrase,
			[Notes] = @Notes,
			[ErrorStack] = @ErrorStack,
			[StartTime] = @StartTime,
			[EndTime] = @EndTime,
			[ReportsTo] = @ReportsTo,
			[DateCreated] = @DateCreated
	WHERE	[Id] = @Id;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'Logs_Delete') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [Logs_Delete]
GO

CREATE PROCEDURE [Logs_Delete]
	@Id INT
AS
BEGIN
	DELETE	FROM [Logs]
	WHERE	[Id] = @Id;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'Logs_Get') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [Logs_Get]
GO

CREATE PROCEDURE [Logs_Get]
	@Id INT
AS
BEGIN
	SELECT	[Id],
			[ProductId],
			[ComponentId],
			[CompanyId],
			[RunId],
			[StepNum],
			[Name],
			[AppName],
			[Status],
			[Type],
			[Build],
			[Platform],
			[Category],
			[Process],
			[Outcome],
			[OutcomeFilePath],
			[OutcomeRaw],
			[MachineName],
			[RunBy],
			[MeasValue],
			[Min],
			[Max],
			[ExpectedPhrase],
			[Notes],
			[ErrorStack],
			[StartTime],
			[EndTime],
			[ReportsTo],
			[DateCreated]
	FROM	[Logs]
	WHERE	[Id] = @Id;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'Logs_GetAll') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [Logs_GetAll]
GO

CREATE PROCEDURE [Logs_GetAll]
AS
BEGIN
	SELECT	[Id],
			[ProductId],
			[ComponentId],
			[CompanyId],
			[RunId],
			[StepNum],
			[Name],
			[AppName],
			[Status],
			[Type],
			[Build],
			[Platform],
			[Category],
			[Process],
			[Outcome],
			[OutcomeFilePath],
			[OutcomeRaw],
			[MachineName],
			[RunBy],
			[MeasValue],
			[Min],
			[Max],
			[ExpectedPhrase],
			[Notes],
			[ErrorStack],
			[StartTime],
			[EndTime],
			[ReportsTo],
			[DateCreated]
	FROM	[Logs];
END;

GO
