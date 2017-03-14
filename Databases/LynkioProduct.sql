USE [Lynkio]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


drop table ProductClaims;
drop table ComponentClaims;
drop table Components;
drop table Products;
drop table Logs;
/**********************************************************************
Components
***********************************************************************/
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[Name] [nvarchar](256) NULL,
	[SerialNumber] nvarchar(100) NULL,
	[ProductNumber] nvarchar(100) NULL,
	[AssemblyNumber] nvarchar(100) NULL,
	[Make] nvarchar(100) NULL,
	[Model] nvarchar(100) NULL,
	[Version] nvarchar(100) NULL,
	[Author] nvarchar(100) NULL,
	[License] nvarchar(100) NULL,
	[Notes] [nvarchar](max) NULL,
	[ReportsTo] [int] NULL,
	[DateCreated] datetime NULL,
	[LastUpdate] datetime NULL
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id] ASC)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY])
 ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/**********************************************************************
ProductClaims:
***********************************************************************/
CREATE TABLE [dbo].[ProductClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL
 CONSTRAINT [PK_ProductClaims] PRIMARY KEY CLUSTERED([Id] ASC) 
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) 
 ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProductClaims]  WITH CHECK ADD  CONSTRAINT [FK_ProductClaims_Products_ProductId] FOREIGN KEY([ProductId]) REFERENCES [dbo].[Products] ([Id]) ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductClaims] CHECK CONSTRAINT [FK_ProductClaims_Products_ProductId]
GO

/**********************************************************************
Component:
***********************************************************************/
CREATE TABLE [dbo].[Components](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[VendorId] [int] NULL,
	[Name] [nvarchar](256) NULL,
	[Type] nvarchar(100) NULL,
	[CRD] nvarchar(10) NULL,
	[Unit] nvarchar(50) NULL,
	[Symbol] nvarchar(100) NULL,
	[PartNumber] nvarchar(100) NULL,
	[LotNumber] nvarchar(100) NULL,
	[Version] nvarchar(100) NULL,
	[Nominal] decimal NULL,
	[Min] decimal NULL,
	[Max] decimal NULL,
	[Rev] nvarchar(100) NULL,
	[DateCode] nvarchar(100) NULL,
	[Notes] [nvarchar](max) NULL,
	[DateCreated] datetime NULL,
	[LastUpdate] datetime NULL
 CONSTRAINT [PK_Components] PRIMARY KEY CLUSTERED ([Id] ASC)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY])
 ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/**********************************************************************
ComponentClaims:
***********************************************************************/
CREATE TABLE [dbo].[ComponentClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ComponentId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL
 CONSTRAINT [PK_ComponentClaims] PRIMARY KEY CLUSTERED([Id] ASC) 
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) 
 ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[ComponentClaims]  WITH CHECK ADD  CONSTRAINT [FK_ComponentClaims_Components_ComponentId] FOREIGN KEY([ComponentId]) REFERENCES [dbo].[Components] ([Id]) ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ComponentClaims] CHECK CONSTRAINT [FK_ComponentClaims_Components_ComponentId]
GO


/**********************************************************************
TestLogs:
--TestOutcomePassing: Boolean (Passed,Completed,Warning)
--TestOutcome: string (Aborted,Completed,Disconnected,Timeout,Error,Failed,Inconclusive,In Progress,Not Executed,Not Runnable,Passed,Pending,Warning)
***********************************************************************/
CREATE TABLE [dbo].[Logs](
	[Id]  [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[ComponentId] [int] NULL,
	[CompanyId] [int] NULL,	
	[RunId] [int] NULL,
	[StepNum] [int] NULL,
	[Name] [nvarchar](256) NULL,
	[AppName] nvarchar(100) NULL,
	[Status] nvarchar(100) NULL,
	[Type] nvarchar(100) NULL,
	[Build] nvarchar(50) NULL,
	[Platform] nvarchar(100) NULL,
	[Category] nvarchar(100) NULL,
	[Process] nvarchar(100) NULL,
	[Outcome] nvarchar(100) NULL,
	[OutcomeFilePath] [nvarchar](max) NULL,
	[OutcomeRaw] [nvarchar](max) NULL,
	[MachineName] nvarchar(100) NULL,
	[RunBy] nvarchar(100) NULL,
	[MeasValue] decimal NULL,
	[Min] decimal NULL,
	[Max] decimal NULL,
	[ExpectedPhrase] [nvarchar](max) NULL,
	[Notes] [nvarchar](max) NULL,
	[ErrorStack] [nvarchar](max) NULL,
	[StartTime] datetime NULL,
	[EndTime] datetime NULL,
	[ReportsTo] [int] NULL,
	[DateCreated] datetime NULL
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED ([Id] ASC)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY])
 ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
