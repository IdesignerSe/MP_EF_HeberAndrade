USE master
CREATE DATABASE AssetsCatalog

GO

USE BlogPostDemo

DROP TABLE IF EXISTS Computer

CREATE TABLE Computer
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
    Brand NVARCHAR(50) NULL,
	ModeName NVARCHAR(50) NULL,
    PurchaseDate NVARCHAR(50) NULL,
    InicialCost  NVARCHAR(50) NULL,
    ExpiredDate  NVARCHAR(50) NULL,
    ExpiredCost  NVARCHAR(50) NULL,

)


CREATE TABLE Phone
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
    Brand NVARCHAR(50) NULL,
	ModeName NVARCHAR(50) NULL,
    PurchaseDate NVARCHAR(50) NULL,
    InicialCost  NVARCHAR(50) NULL,
    ExpiredDate  NVARCHAR(50) NULL,
    ExpiredCost  NVARCHAR(50) NULL,

)

CREATE TABLE Tv
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
    Brand NVARCHAR(50) NULL,
	ModeName NVARCHAR(50) NULL,
    PurchaseDate NVARCHAR(50) NULL,
    InicialCost  NVARCHAR(50) NULL,
    ExpiredDate  NVARCHAR(50) NULL,
    ExpiredCost  NVARCHAR(50) NULL,

)

GO
