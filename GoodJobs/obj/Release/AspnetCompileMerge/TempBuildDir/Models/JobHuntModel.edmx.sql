
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/26/2018 18:36:40
-- Generated from EDMX file: D:\My software development projects\ASP.net\GoodJobs-dev\GoodJobs\GoodJobs\Models\JobHuntModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [JobHuntDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserJobApplications]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JobApplications] DROP CONSTRAINT [FK_UserJobApplications];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[JobApplications]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobApplications];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NULL,
    [LastName] nvarchar(max)  NULL,
    [Password] nvarchar(max)  NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [StreetName] nvarchar(max)  NULL,
    [StreetNumber] nvarchar(max)  NULL,
    [City] nvarchar(max)  NULL,
    [ZipCode] nvarchar(max)  NULL,
    [LinkedIn] nvarchar(max)  NULL,
    [Country] nvarchar(max)  NULL,
    [BirthDate] datetime  NULL,
    [MainCareer] nvarchar(max)  NOT NULL,
    [SubCareer] nvarchar(max)  NOT NULL,
    [Friends] nvarchar(max)  NULL,
    [SearchTag] nvarchar(max)  NULL,
    [FriendsInvRecieved] nvarchar(max)  NULL,
    [FriendsInvSend] nvarchar(max)  NULL,
    [Resume] nvarchar(max)  NULL,
    [Categories] nvarchar(max)  NULL
);
GO

-- Creating table 'JobApplications'
CREATE TABLE [dbo].[JobApplications] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [JobApplDateTime] datetime  NULL,
    [JobApplName] nvarchar(max)  NULL,
    [VacancyTitle] nvarchar(max)  NULL,
    [VacancyText] nvarchar(max)  NULL,
    [VacancyContactPerson] nvarchar(max)  NULL,
    [VacancyContactPersonLinkedIn] nvarchar(max)  NULL,
    [VacancyCompany] nvarchar(max)  NULL,
    [VacancyCompanyCity] nvarchar(max)  NULL,
    [VacancyCompanyStreetName] nvarchar(max)  NULL,
    [VacancyCompanyStreetNumber] nvarchar(max)  NULL,
    [VacancyCompanyZipCode] nvarchar(max)  NULL,
    [JobApplFeedback] nvarchar(max)  NULL,
    [VacancyLink] nvarchar(max)  NULL,
    [JobApplStatus] nvarchar(max)  NULL,
    [VacancyFunctionTitle] nvarchar(max)  NULL,
    [VacancyCompanyWebsite] nvarchar(max)  NULL,
    [JobApplNote] nvarchar(max)  NULL,
    [JobApplTime] nvarchar(max)  NULL,
    [JobApplLetter] nvarchar(max)  NULL,
    [JobApplInterviewDateTime] datetime  NULL,
    [JobApplInterviewTime] nvarchar(max)  NULL,
    [JobApplSecInterviewDateTime] datetime  NULL,
    [JobApplSecInterviewTime] nvarchar(max)  NULL,
    [VacancyContactPersonEmail] nvarchar(max)  NULL,
    [VacancyCompanyCountry] nvarchar(max)  NULL,
    [VacancyCareerField] nvarchar(max)  NULL,
    [JobApplThirdInterviewDateTime] datetime  NULL,
    [JobApplThirdInterviewTime] nvarchar(max)  NULL,
    [JobApplInterviewPersons] nvarchar(max)  NULL,
    [JobApplSecInterviewPersons] nvarchar(max)  NULL,
    [JobApplThirdInterviewPersons] nvarchar(max)  NULL,
    [JobApplMyRating] nvarchar(max)  NULL,
    [JobApplInterviewPreperation] nvarchar(max)  NULL,
    [JobApplMyQuestions] nvarchar(max)  NULL,
    [JobApplCompanyQuestions] nvarchar(max)  NULL,
    [VacancySalary] nvarchar(max)  NULL,
    [VacancyCompanySummary] nvarchar(max)  NULL,
    [JobApplMyFollowUpEmails] nvarchar(max)  NULL,
    [JobApplFollowUpStatus] nvarchar(max)  NULL,
    [JobApplMethod] nvarchar(max)  NULL,
    [JobApplInterviewNotes] nvarchar(max)  NULL,
    [UserUserId] int  NOT NULL,
    [ShowToFriends] nvarchar(max)  NULL,
    [JobApplCat] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [ID] in table 'JobApplications'
ALTER TABLE [dbo].[JobApplications]
ADD CONSTRAINT [PK_JobApplications]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserUserId] in table 'JobApplications'
ALTER TABLE [dbo].[JobApplications]
ADD CONSTRAINT [FK_UserJobApplications]
    FOREIGN KEY ([UserUserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserJobApplications'
CREATE INDEX [IX_FK_UserJobApplications]
ON [dbo].[JobApplications]
    ([UserUserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------