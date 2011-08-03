
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 08/03/2011 03:35:27
-- Generated from EDMX file: C:\Users\C. Yehia\Documents\Visual Studio 2010\Projects\Politiq2\Models\DB\DBModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [db3687];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_MemberParty]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Members] DROP CONSTRAINT [FK_MemberParty];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Members]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Members];
GO
IF OBJECT_ID(N'[dbo].[Parties]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Parties];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Members'
CREATE TABLE [dbo].[Members] (
    [MemberID] int IDENTITY(1,1) NOT NULL,
    [LoginID] nchar(10)  NOT NULL,
    [FirstName] nchar(10)  NULL,
    [LastName] nchar(10)  NULL,
    [Password] nchar(10)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Party_PartyID] int  NULL
);
GO

-- Creating table 'Parties'
CREATE TABLE [dbo].[Parties] (
    [PartyID] int IDENTITY(1,1) NOT NULL,
    [PartyName] nvarchar(max)  NOT NULL,
    [PartyLongName] nvarchar(max)  NOT NULL,
    [Seats] int  NOT NULL,
    [Side] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MemberID] in table 'Members'
ALTER TABLE [dbo].[Members]
ADD CONSTRAINT [PK_Members]
    PRIMARY KEY CLUSTERED ([MemberID] ASC);
GO

-- Creating primary key on [PartyID] in table 'Parties'
ALTER TABLE [dbo].[Parties]
ADD CONSTRAINT [PK_Parties]
    PRIMARY KEY CLUSTERED ([PartyID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Party_PartyID] in table 'Members'
ALTER TABLE [dbo].[Members]
ADD CONSTRAINT [FK_MemberParty]
    FOREIGN KEY ([Party_PartyID])
    REFERENCES [dbo].[Parties]
        ([PartyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MemberParty'
CREATE INDEX [IX_FK_MemberParty]
ON [dbo].[Members]
    ([Party_PartyID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------