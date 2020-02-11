SET NOCOUNT ON
GO

USE master
GO

IF EXISTS (SELECT * FROM sysdatabases WHERE NAME='AnimalHabitat')
BEGIN
	ALTER DATABASE "AnimalHabitat" SET SINGLE_USER WITH ROLLBACK IMMEDIATE
	DROP DATABASE "AnimalHabitat"
END
GO

DECLARE @device_directory NVARCHAR(520)
SELECT @device_directory = SUBSTRING(filename, 1, CHARINDEX(N'master.mdf', LOWER(filename)) - 1)
FROM master.dbo.sysaltfiles WHERE dbid = 1 AND fileid = 1

EXECUTE (N'CREATE DATABASE AnimalHabitat
  ON PRIMARY (NAME = N''AnimalHabitat'', FILENAME = N''' + @device_directory + N'animal-habitat.mdf'')
  LOG ON (NAME = N''AnimalHabitat_log'',  FILENAME = N''' + @device_directory + N'animal-habitat.ldf'')')
GO

ALTER DATABASE AnimalHabitat SET RECOVERY SIMPLE
GO

SET QUOTED_IDENTIFIER ON
GO

/* Set DATEFORMAT so that the date strings are interpreted correctly regardless of
   the default DATEFORMAT on the server.
*/
SET DATEFORMAT mdy
GO
USE "AnimalHabitat"
GO

CREATE TABLE "Continent" (
	"Id" INT IDENTITY (1, 1) NOT NULL,
	"Name" NVARCHAR (30) NOT NULL,
	CONSTRAINT "PK_Continent" PRIMARY KEY CLUSTERED (Id)
)
GO

CREATE TABLE "Animal" (
	"Id" INT IDENTITY (1, 1) NOT NULL,
	"Species" NVARCHAR (40) NOT NULL,
	"Count" INT NOT NULL,
	"ContinentId" INT NOT NULL,
	CONSTRAINT "PK_Animal_Id" PRIMARY KEY CLUSTERED ("Id"),
	CONSTRAINT "FK_Animal_Continent" FOREIGN KEY ("ContinentId") REFERENCES "Continent" ("Id")
)
GO

INSERT INTO "Continent" ([Name])
VALUES
	('Africa'),
	('Antarctica'),
	('Asia'),
	('Australia'),
	('Europe'),
	('North America'),
	('South America')
GO

DECLARE @africaContinentId INT;
SET @africaContinentId = (SELECT TOP 1 Id FROM "Continent" WHERE [Name] = 'Africa');

DECLARE @antarcticaContinentId INT;
SET @antarcticaContinentId = (SELECT TOP 1 Id FROM "Continent" WHERE [Name] = 'Antarctica');

DECLARE @asiaContinentId INT;
SET @asiaContinentId = (SELECT TOP 1 Id FROM "Continent" WHERE [Name] = 'Asia');

DECLARE @australiaContinentId INT;
SET @australiaContinentId = (SELECT TOP 1 Id FROM "Continent" WHERE [Name] = 'Australia');

DECLARE @europeContinentId INT;
SET @europeContinentId = (SELECT TOP 1 Id FROM "Continent" WHERE [Name] = 'Europe');

DECLARE @northAmericaContinentId INT;
SET @northAmericaContinentId = (SELECT TOP 1 Id FROM "Continent" WHERE [Name] = 'North America');

DECLARE @southAmericaContinentId INT;
SET @southAmericaContinentId = (SELECT TOP 1 Id FROM "Continent" WHERE [Name] = 'South America');

INSERT INTO "Animal" ([Species], [ContinentId], [Count])
VALUES 
	('White Hourse', @europeContinentId, 900),
	('Kangaroo', @australiaContinentId, 6200),
	('Black Bear', @northAmericaContinentId, 5600),
	('Bonobo', @asiaContinentId, 7100),
	('Lemur', @northAmericaContinentId, 3400),
	('Elephant', @asiaContinentId, 4600),
	('Zebra', @africaContinentId, 2100),
	('Vervet Monkey', @northAmericaContinentId, 8300),
	('Brown Fox',@europeContinentId, 2150),
	('Gibbon',@africaContinentId, 400),
	('Gorilla', @asiaContinentId, 550),
	('Lion', @africaContinentId, 700),
	('Koala', @asiaContinentId, 5200),
	('White Tiger', @asiaContinentId, 320),
	('Black Bear', @southAmericaContinentId, 560)
GO