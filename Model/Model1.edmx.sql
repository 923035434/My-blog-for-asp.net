
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/26/2017 18:01:23
-- Generated from EDMX file: C:\Users\Administrator\Desktop\项目\My-blog-for-asp.net\Model\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BlogSystem];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BlogTypeBlog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Blog] DROP CONSTRAINT [FK_BlogTypeBlog];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoBlog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Blog] DROP CONSTRAINT [FK_UserInfoBlog];
GO
IF OBJECT_ID(N'[dbo].[FK_SingerSong]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Song] DROP CONSTRAINT [FK_SingerSong];
GO
IF OBJECT_ID(N'[dbo].[FK_BlogSettingM_BgImg]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[M_BgImg] DROP CONSTRAINT [FK_BlogSettingM_BgImg];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfo];
GO
IF OBJECT_ID(N'[dbo].[Message]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Message];
GO
IF OBJECT_ID(N'[dbo].[BlogType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BlogType];
GO
IF OBJECT_ID(N'[dbo].[Blog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Blog];
GO
IF OBJECT_ID(N'[dbo].[Singer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Singer];
GO
IF OBJECT_ID(N'[dbo].[Song]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Song];
GO
IF OBJECT_ID(N'[dbo].[BlogSetting]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BlogSetting];
GO
IF OBJECT_ID(N'[dbo].[M_BgImg]', 'U') IS NOT NULL
    DROP TABLE [dbo].[M_BgImg];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserInfo'
CREATE TABLE [dbo].[UserInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Account] nvarchar(max)  NOT NULL,
    [PassWord] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Message'
CREATE TABLE [dbo].[Message] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [Time] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'BlogType'
CREATE TABLE [dbo].[BlogType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(max)  NOT NULL,
    [Rank] int  NOT NULL
);
GO

-- Creating table 'Blog'
CREATE TABLE [dbo].[Blog] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [ImgUrl] nvarchar(max)  NOT NULL,
    [HtmlContent] nvarchar(max)  NOT NULL,
    [Time] nvarchar(max)  NOT NULL,
    [BlogTypeId] int  NULL,
    [UserInfoId] int  NULL
);
GO

-- Creating table 'Singer'
CREATE TABLE [dbo].[Singer] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SingerId] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ImgUrl] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Song'
CREATE TABLE [dbo].[Song] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MusicId] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ImgUrl] nvarchar(max)  NOT NULL,
    [AlbumName] nvarchar(max)  NOT NULL,
    [SingerId] int  NULL,
    [Url] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'BlogSetting'
CREATE TABLE [dbo].[BlogSetting] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [Signature] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Avatar] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'M_BgImg'
CREATE TABLE [dbo].[M_BgImg] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [M_HomeImg] nvarchar(max)  NOT NULL,
    [M_BlogImg] nvarchar(max)  NOT NULL,
    [IsDelete] int  NOT NULL,
    [BlogSettingId] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserInfo'
ALTER TABLE [dbo].[UserInfo]
ADD CONSTRAINT [PK_UserInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Message'
ALTER TABLE [dbo].[Message]
ADD CONSTRAINT [PK_Message]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BlogType'
ALTER TABLE [dbo].[BlogType]
ADD CONSTRAINT [PK_BlogType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Blog'
ALTER TABLE [dbo].[Blog]
ADD CONSTRAINT [PK_Blog]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Singer'
ALTER TABLE [dbo].[Singer]
ADD CONSTRAINT [PK_Singer]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Song'
ALTER TABLE [dbo].[Song]
ADD CONSTRAINT [PK_Song]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BlogSetting'
ALTER TABLE [dbo].[BlogSetting]
ADD CONSTRAINT [PK_BlogSetting]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'M_BgImg'
ALTER TABLE [dbo].[M_BgImg]
ADD CONSTRAINT [PK_M_BgImg]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BlogTypeId] in table 'Blog'
ALTER TABLE [dbo].[Blog]
ADD CONSTRAINT [FK_BlogTypeBlog]
    FOREIGN KEY ([BlogTypeId])
    REFERENCES [dbo].[BlogType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BlogTypeBlog'
CREATE INDEX [IX_FK_BlogTypeBlog]
ON [dbo].[Blog]
    ([BlogTypeId]);
GO

-- Creating foreign key on [UserInfoId] in table 'Blog'
ALTER TABLE [dbo].[Blog]
ADD CONSTRAINT [FK_UserInfoBlog]
    FOREIGN KEY ([UserInfoId])
    REFERENCES [dbo].[UserInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoBlog'
CREATE INDEX [IX_FK_UserInfoBlog]
ON [dbo].[Blog]
    ([UserInfoId]);
GO

-- Creating foreign key on [SingerId] in table 'Song'
ALTER TABLE [dbo].[Song]
ADD CONSTRAINT [FK_SingerSong]
    FOREIGN KEY ([SingerId])
    REFERENCES [dbo].[Singer]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SingerSong'
CREATE INDEX [IX_FK_SingerSong]
ON [dbo].[Song]
    ([SingerId]);
GO

-- Creating foreign key on [BlogSettingId] in table 'M_BgImg'
ALTER TABLE [dbo].[M_BgImg]
ADD CONSTRAINT [FK_BlogSettingM_BgImg]
    FOREIGN KEY ([BlogSettingId])
    REFERENCES [dbo].[BlogSetting]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BlogSettingM_BgImg'
CREATE INDEX [IX_FK_BlogSettingM_BgImg]
ON [dbo].[M_BgImg]
    ([BlogSettingId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------