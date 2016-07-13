
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/20/2016 14:19:12
-- Generated from EDMX file: c:\users\alina\documents\visual studio 2015\Projects\HospitalApp\HospitalApp\HospitalModelVersion1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HospitalDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_DoctorPosition]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Doctors] DROP CONSTRAINT [FK_DoctorPosition];
GO
IF OBJECT_ID(N'[dbo].[FK_DoctorAppointment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Appointments] DROP CONSTRAINT [FK_DoctorAppointment];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerAppointment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Appointments] DROP CONSTRAINT [FK_CustomerAppointment];
GO
IF OBJECT_ID(N'[dbo].[FK_DoctorSchedule]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Schedules] DROP CONSTRAINT [FK_DoctorSchedule];
GO
IF OBJECT_ID(N'[dbo].[FK_AppointmentBill]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bills] DROP CONSTRAINT [FK_AppointmentBill];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceBill]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bills] DROP CONSTRAINT [FK_ServiceBill];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Doctors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Doctors];
GO
IF OBJECT_ID(N'[dbo].[Positions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Positions];
GO
IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[Appointments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Appointments];
GO
IF OBJECT_ID(N'[dbo].[Schedules]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Schedules];
GO
IF OBJECT_ID(N'[dbo].[Services]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Services];
GO
IF OBJECT_ID(N'[dbo].[Bills]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bills];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Doctors'
CREATE TABLE [dbo].[Doctors] (
    [Id] uniqueidentifier  NOT NULL,
    [FIO] nvarchar(max)  NOT NULL,
    [PositionId] uniqueidentifier  NOT NULL,
    [PhoneNumber] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Positions'
CREATE TABLE [dbo].[Positions] (
    [Id] uniqueidentifier  NOT NULL,
    [PositionName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Id] uniqueidentifier  NOT NULL,
    [FIO] nvarchar(max)  NOT NULL,
    [PhoneNumber] nvarchar(max)  NOT NULL,
    [BirthDate] datetime  NOT NULL,
    [EnsuranceNumber] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Appointments'
CREATE TABLE [dbo].[Appointments] (
    [Id] uniqueidentifier  NOT NULL,
    [DoctorId] uniqueidentifier  NOT NULL,
    [CustomerId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Schedules'
CREATE TABLE [dbo].[Schedules] (
    [Id] uniqueidentifier  NOT NULL,
    [DoctorId] uniqueidentifier  NOT NULL,
    [WeekDay] nvarchar(max)  NOT NULL,
    [DayBegin] datetime  NOT NULL,
    [DayEnd] datetime  NOT NULL
);
GO

-- Creating table 'Services'
CREATE TABLE [dbo].[Services] (
    [Id] uniqueidentifier  NOT NULL,
    [Cost] decimal(19,2)  NOT NULL,
    [ServiceName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Bills'
CREATE TABLE [dbo].[Bills] (
    [Id] uniqueidentifier  NOT NULL,
    [AppointmentId] uniqueidentifier  NOT NULL,
    [ServiceId] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Doctors'
ALTER TABLE [dbo].[Doctors]
ADD CONSTRAINT [PK_Doctors]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Positions'
ALTER TABLE [dbo].[Positions]
ADD CONSTRAINT [PK_Positions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Appointments'
ALTER TABLE [dbo].[Appointments]
ADD CONSTRAINT [PK_Appointments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Schedules'
ALTER TABLE [dbo].[Schedules]
ADD CONSTRAINT [PK_Schedules]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Services'
ALTER TABLE [dbo].[Services]
ADD CONSTRAINT [PK_Services]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Bills'
ALTER TABLE [dbo].[Bills]
ADD CONSTRAINT [PK_Bills]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PositionId] in table 'Doctors'
ALTER TABLE [dbo].[Doctors]
ADD CONSTRAINT [FK_DoctorPosition]
    FOREIGN KEY ([PositionId])
    REFERENCES [dbo].[Positions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DoctorPosition'
CREATE INDEX [IX_FK_DoctorPosition]
ON [dbo].[Doctors]
    ([PositionId]);
GO

-- Creating foreign key on [DoctorId] in table 'Appointments'
ALTER TABLE [dbo].[Appointments]
ADD CONSTRAINT [FK_DoctorAppointment]
    FOREIGN KEY ([DoctorId])
    REFERENCES [dbo].[Doctors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DoctorAppointment'
CREATE INDEX [IX_FK_DoctorAppointment]
ON [dbo].[Appointments]
    ([DoctorId]);
GO

-- Creating foreign key on [CustomerId] in table 'Appointments'
ALTER TABLE [dbo].[Appointments]
ADD CONSTRAINT [FK_CustomerAppointment]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerAppointment'
CREATE INDEX [IX_FK_CustomerAppointment]
ON [dbo].[Appointments]
    ([CustomerId]);
GO

-- Creating foreign key on [DoctorId] in table 'Schedules'
ALTER TABLE [dbo].[Schedules]
ADD CONSTRAINT [FK_DoctorSchedule]
    FOREIGN KEY ([DoctorId])
    REFERENCES [dbo].[Doctors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DoctorSchedule'
CREATE INDEX [IX_FK_DoctorSchedule]
ON [dbo].[Schedules]
    ([DoctorId]);
GO

-- Creating foreign key on [AppointmentId] in table 'Bills'
ALTER TABLE [dbo].[Bills]
ADD CONSTRAINT [FK_AppointmentBill]
    FOREIGN KEY ([AppointmentId])
    REFERENCES [dbo].[Appointments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AppointmentBill'
CREATE INDEX [IX_FK_AppointmentBill]
ON [dbo].[Bills]
    ([AppointmentId]);
GO

-- Creating foreign key on [ServiceId] in table 'Bills'
ALTER TABLE [dbo].[Bills]
ADD CONSTRAINT [FK_ServiceBill]
    FOREIGN KEY ([ServiceId])
    REFERENCES [dbo].[Services]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceBill'
CREATE INDEX [IX_FK_ServiceBill]
ON [dbo].[Bills]
    ([ServiceId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------