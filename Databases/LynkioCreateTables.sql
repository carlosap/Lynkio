USE [Lynkio]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

drop table UserClaims;
drop table UserRoles;
drop table UserLogins;
drop table UserNetworks;
drop table Networks;
drop table Roles;
drop table Users;

/**********************************************************************
Role-Based Security
A user gets assigned to one or more roles through which the user gets 
access rights. Also, by assigning a user to a role, the user immediately
gets all the access rights defined for that role.
***********************************************************************/
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NULL,
	[FirstName] nvarchar(100) NULL,
	[LastName] nvarchar(100) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[EmailNotification] bit NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[PhoneNotification] bit NOT NULL,	
	[AccessFailedCount] [int] NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[ReportsTo] [nvarchar](450) NULL,
	[DateCreated] datetime NOT NULL,
	[LastUpdate] datetime NOT NULL
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY])
 ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/**********************************************************************
Roles:
***********************************************************************/
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED([Id] ASC)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY])
 ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/**********************************************************************
UserRoles:
***********************************************************************/
CREATE TABLE [dbo].[UserRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 PRIMARY KEY CLUSTERED ([UserId] ASC,[RoleId] ASC))
 GO

/**********************************************************************
UserClaims:
***********************************************************************/
CREATE TABLE [dbo].[UserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_UserClaims] PRIMARY KEY CLUSTERED([Id] ASC) 
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) 
 ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[UserClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserClaims_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserClaims] CHECK CONSTRAINT [FK_UserClaims_Users_UserId]
GO



/**********************************************************************
UserLogins:
***********************************************************************/
CREATE TABLE [dbo].[UserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_UserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[UserLogins]  WITH CHECK ADD  CONSTRAINT [FK_UserLogins_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[UserLogins] CHECK CONSTRAINT [FK_UserLogins_Users_UserId]
GO

/**********************************************************************
NetworkConnections:
***********************************************************************/
CREATE TABLE [dbo].[Networks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[Notes] [nvarchar](max) NULL,
	[DateCreated] datetime NULL,
	[LastUpdate] datetime NULL
 CONSTRAINT [PK_Networks] PRIMARY KEY CLUSTERED ([Id] ASC)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY])
 ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/**********************************************************************
UserNetworks:
***********************************************************************/
CREATE TABLE [dbo].[UserNetworks](
	[UserId] [int]NOT NULL,
	[NetworkId] [int]NOT NULL,
 CONSTRAINT [PK_UserNetworks] PRIMARY KEY CLUSTERED(
	[UserId] ASC,
	[NetworkId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]

GO
ALTER TABLE [dbo].[UserNetworks]  WITH CHECK ADD  CONSTRAINT [FK_UserNetworks_Networks_NetworkId] FOREIGN KEY([NetworkId])REFERENCES [dbo].[Networks] ([Id])ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserNetworks] CHECK CONSTRAINT [FK_UserNetworks_Networks_NetworkId]
GO
ALTER TABLE [dbo].[UserNetworks]  WITH CHECK ADD  CONSTRAINT [FK_UserNetworks_Users_UserId] FOREIGN KEY([UserId])REFERENCES [dbo].[Users] ([Id])ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserNetworks] CHECK CONSTRAINT [FK_UserNetworks_Users_UserId]
GO




