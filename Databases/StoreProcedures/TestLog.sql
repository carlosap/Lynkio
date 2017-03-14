-- Table: TestLogs
IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'TestLogs_Add') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [TestLogs_Add]
GO

CREATE PROCEDURE [TestLogs_Add]
	@Id INT OUTPUT,
	@ProductId NVARCHAR(450),
	@ComponentId NVARCHAR(450),
	@ReportsTo INT,
	@RunId NVARCHAR(450),
	@StepNum INT,
	@Name NVARCHAR(256),
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
	@DateCreated DATETIME
AS
BEGIN
	INSERT INTO [TestLogs]
	(
		[ProductId],
		[ComponentId],
		[ReportsTo],
		[RunId],
		[StepNum],
		[Name],
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
		[DateCreated]
	)
	VALUES
	(
		@ProductId,
		@ComponentId,
		@ReportsTo,
		@RunId,
		@StepNum,
		@Name,
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
		@DateCreated
	);

	SET @Id = SCOPE_IDENTITY();
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'TestLogs_Update') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [TestLogs_Update]
GO

CREATE PROCEDURE [TestLogs_Update]
	@Id INT,
	@ProductId NVARCHAR(450),
	@ComponentId NVARCHAR(450),
	@ReportsTo INT,
	@RunId NVARCHAR(450),
	@StepNum INT,
	@Name NVARCHAR(256),
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
	@DateCreated DATETIME
AS
BEGIN
	UPDATE	[TestLogs]
	SET		[ProductId] = @ProductId,
			[ComponentId] = @ComponentId,
			[ReportsTo] = @ReportsTo,
			[RunId] = @RunId,
			[StepNum] = @StepNum,
			[Name] = @Name,
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
			[DateCreated] = @DateCreated
	WHERE	[Id] = @Id;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'TestLogs_Delete') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [TestLogs_Delete]
GO

CREATE PROCEDURE [TestLogs_Delete]
	@Id INT
AS
BEGIN
	DELETE	FROM [TestLogs]
	WHERE	[Id] = @Id;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'TestLogs_Get') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [TestLogs_Get]
GO

CREATE PROCEDURE [TestLogs_Get]
	@Id INT
AS
BEGIN
	SELECT	[Id],
			[ProductId],
			[ComponentId],
			[ReportsTo],
			[RunId],
			[StepNum],
			[Name],
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
			[DateCreated]
	FROM	[TestLogs]
	WHERE	[Id] = @Id;
END;

GO

IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'TestLogs_GetAll') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [TestLogs_GetAll]
GO

CREATE PROCEDURE [TestLogs_GetAll]
AS
BEGIN
	SELECT	[Id],
			[ProductId],
			[ComponentId],
			[ReportsTo],
			[RunId],
			[StepNum],
			[Name],
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
			[DateCreated]
	FROM	[TestLogs];
END;

GO
