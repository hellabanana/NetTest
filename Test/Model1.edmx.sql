
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/12/2019 14:41:37
-- Generated from EDMX file: A:\Учеба\C#\Projects\Test\Test\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [bk];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BooksEntity2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookAuthorSet] DROP CONSTRAINT [FK_BooksEntity2];
GO
IF OBJECT_ID(N'[dbo].[FK_Entity3Entity2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookAuthorSet] DROP CONSTRAINT [FK_Entity3Entity2];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BooksSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BooksSet];
GO
IF OBJECT_ID(N'[dbo].[BookAuthorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookAuthorSet];
GO
IF OBJECT_ID(N'[dbo].[AuthorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AuthorSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BooksSet'
CREATE TABLE [dbo].[BooksSet] (
    [Id_book] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Year] int  NOT NULL
);
GO

-- Creating table 'BookAuthorSet'
CREATE TABLE [dbo].[BookAuthorSet] (
    [Id_book] int  NOT NULL,
    [Id_author] int  NOT NULL
);
GO

-- Creating table 'AuthorSet'
CREATE TABLE [dbo].[AuthorSet] (
    [Id_author] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id_book] in table 'BooksSet'
ALTER TABLE [dbo].[BooksSet]
ADD CONSTRAINT [PK_BooksSet]
    PRIMARY KEY CLUSTERED ([Id_book] ASC);
GO

-- Creating primary key on [Id_book], [Id_author] in table 'BookAuthorSet'
ALTER TABLE [dbo].[BookAuthorSet]
ADD CONSTRAINT [PK_BookAuthorSet]
    PRIMARY KEY CLUSTERED ([Id_book], [Id_author] ASC);
GO

-- Creating primary key on [Id_author] in table 'AuthorSet'
ALTER TABLE [dbo].[AuthorSet]
ADD CONSTRAINT [PK_AuthorSet]
    PRIMARY KEY CLUSTERED ([Id_author] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Id_book] in table 'BookAuthorSet'
ALTER TABLE [dbo].[BookAuthorSet]
ADD CONSTRAINT [FK_BooksEntity2]
    FOREIGN KEY ([Id_book])
    REFERENCES [dbo].[BooksSet]
        ([Id_book])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id_author] in table 'BookAuthorSet'
ALTER TABLE [dbo].[BookAuthorSet]
ADD CONSTRAINT [FK_Entity3Entity2]
    FOREIGN KEY ([Id_author])
    REFERENCES [dbo].[AuthorSet]
        ([Id_author])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Entity3Entity2'
CREATE INDEX [IX_FK_Entity3Entity2]
ON [dbo].[BookAuthorSet]
    ([Id_author]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------