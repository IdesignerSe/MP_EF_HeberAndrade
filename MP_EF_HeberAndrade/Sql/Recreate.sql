USE master

CREATE DATABASE AssetsCatalog

GO

USE Asset

DROP TABLE IF EXISTS Computer

CREATE TABLE [dbo].[Computers] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Brand]        NVARCHAR (MAX) NULL,
    [ModelName]    NVARCHAR (MAX) NULL,
    [PurchaseDate] INT            NOT NULL,
    [InicialCost]  INT            NOT NULL,
    [ExpiredDate]  INT            NOT NULL,
    [ExpiredCost]  INT            NOT NULL,
    CONSTRAINT [PK_Computers] PRIMARY KEY CLUSTERED ([Id] ASC)
);

DROP TABLE IF EXISTS Phone

CREATE TABLE [dbo].[Phones] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Brand]        NVARCHAR (MAX) NULL,
    [ModelName]    NVARCHAR (MAX) NULL,
    [PurchaseDate] INT            NOT NULL,
    [InicialCost]  INT            NOT NULL,
    [ExpiredDate]  INT            NOT NULL,
    [ExpiredCost]  INT            NOT NULL,
    CONSTRAINT [PK_Phones] PRIMARY KEY CLUSTERED ([Id] ASC)
);

DROP TABLE IF EXISTS Tv

CREATE TABLE [dbo].[Tvs] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Brand]        NVARCHAR (MAX) NULL,
    [ModelName]    NVARCHAR (MAX) NULL,
    [PurchaseDate] INT            NOT NULL,
    [InicialCost]  INT            NOT NULL,
    [ExpiredDate]  INT            NOT NULL,
    [ExpiredCost]  INT            NOT NULL,
    CONSTRAINT [PK_Tvs] PRIMARY KEY CLUSTERED ([Id] ASC)
);



GO
