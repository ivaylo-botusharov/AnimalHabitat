SET NOCOUNT ON
GO

USE master
GO

IF EXISTS (SELECT * FROM sysdatabases WHERE NAME='Ecology')
BEGIN
	--ALTER DATABASE "Ecology" SET OFFLINE WITH ROLLBACK IMMEDIATE
	DROP DATABASE "Ecology"
END
GO

DECLARE @device_directory NVARCHAR(520)
SELECT @device_directory = SUBSTRING(filename, 1, CHARINDEX(N'master.mdf', LOWER(filename)) - 1)
FROM master.dbo.sysaltfiles WHERE dbid = 1 AND fileid = 1

EXECUTE (N'CREATE DATABASE Ecology
  ON PRIMARY (NAME = N''Ecology'', FILENAME = N''' + @device_directory + N'Ecology.mdf'')
  LOG ON (NAME = N''Ecology_log'',  FILENAME = N''' + @device_directory + N'Ecology.ldf'')')
GO

ALTER DATABASE Ecology SET RECOVERY SIMPLE
GO

SET QUOTED_IDENTIFIER ON
GO

/* Set DATEFORMAT so that the date strings are interpreted correctly regardless of
   the default DATEFORMAT on the server.
*/
SET DATEFORMAT mdy
GO
USE "Ecology"
GO

CREATE TABLE "Realm" 
(
	"Id" INT IDENTITY (1, 1) NOT NULL,
	"Name" NVARCHAR (300) NOT NULL,
	"Description" NVARCHAR (500) NULL,
	CONSTRAINT "PK_Realm" PRIMARY KEY CLUSTERED (Id)
)
GO

CREATE TABLE "Biome" 
(
	"Id" INT IDENTITY (1, 1) NOT NULL,
	"Name" NVARCHAR (300) NOT NULL,
	"Description" NVARCHAR (500) NULL,
	CONSTRAINT "PK_Biome" PRIMARY KEY CLUSTERED (Id)
)
GO

CREATE TABLE "RealmBiome" 
(
	"RealmId" INT NOT NULL,
	"BiomeId" INT NOT NULL,
	CONSTRAINT "PK_Realm_Biome" PRIMARY KEY ("RealmId", "BiomeId"),
	CONSTRAINT "FK_Realm" FOREIGN KEY ("RealmId") REFERENCES "Realm" ("Id"),
	CONSTRAINT "FK_Biome" FOREIGN KEY ("BiomeId") REFERENCES "Biome" ("Id")
)

CREATE TABLE "Ecoregion" 
(
	"Id" INT IDENTITY (1, 1) NOT NULL,
	"Name" NVARCHAR (300) NOT NULL,
	"Description" NVARCHAR (500) NULL,
	"RealmId" INT NOT NULL,
	"BiomeId" INT NOT NULL,
	CONSTRAINT "PK_Ecoregion" PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT "FK_RealmBiome" FOREIGN KEY(RealmId, BiomeId) REFERENCES "RealmBiome" (RealmId, BiomeId)
)
GO

CREATE TABLE "Country" 
(
	"Id" INT IDENTITY (1, 1) NOT NULL,
	"Name" NVARCHAR (100) NOT NULL,
	CONSTRAINT "PK_Country" PRIMARY KEY CLUSTERED (Id)
)
GO

CREATE TABLE "EcoregionCountry"
(
	"EcoregionId" INT NOT NULL,
	"CountryId" INT NOT NULL,
	CONSTRAINT "PK_Ecoregion_Country" PRIMARY KEY ("EcoregionId", "CountryId"),
	CONSTRAINT "FK_Ecoregion" FOREIGN KEY ("EcoregionId") REFERENCES "Ecoregion" ("Id"),
	CONSTRAINT "FK_Country" FOREIGN KEY ("CountryId") REFERENCES "Country" ("Id")
)
GO

CREATE TABLE "Species" 
(
	"Id" INT IDENTITY (1, 1) NOT NULL,
	"CommonName" NVARCHAR (100) NOT NULL,
	"ScientificName" NVARCHAR (100) NULL,
	CONSTRAINT "PK_Species" PRIMARY KEY CLUSTERED (Id)
)
GO

CREATE TABLE "SpeciesDistribution"
(
	"Id" INT IDENTITY (1, 1) NOT NULL,
	"SpeciesId" INT NOT NULL,
	"EcoregionId" INT NOT NULL,
	"CountryId" INT NOT NULL,
	"Population" INT NOT NULL,
	"Description" NVARCHAR(500) NULL
	CONSTRAINT "PK_SpeciesDistribution_Id" PRIMARY KEY NONCLUSTERED ("Id"),
	CONSTRAINT "FK_SpeciesDistribution_Species" FOREIGN KEY ("SpeciesId") REFERENCES "Species" ("Id"),
	CONSTRAINT "FK_SpeciesDistribution_EcoregionCountry" FOREIGN KEY ("EcoregionId", "CountryId") 
		REFERENCES "EcoregionCountry" ("EcoregionId", "CountryId")
)
GO

INSERT INTO "Realm" ([Name])
VALUES
	('Afrotropic'),
	('Neotropic'),
	('Australasia')
GO

INSERT INTO "Biome" ([Name])
VALUES
	('Tropical and subtropical dry broadleaf forests'),
	('Temperate grasslands, savannas, and shrublands'),
	('Tropical and subtropical moist broadleaf forests'),
	('Tropical and subtropical grasslands, savannas, and shrublands'),
	('Montane grasslands and shrublands'),
	('Mediterranean forests, woodlands, and shrub')
GO

DECLARE @afrotropicRealmId INT;
SET @afrotropicRealmId = (SELECT TOP 1 Id FROM "Realm" WHERE [Name] = 'Afrotropic');

DECLARE @neotropicRealmId INT;
SET @neotropicRealmId = (SELECT TOP 1 Id FROM "Realm" WHERE [Name] = 'Neotropic');

DECLARE @australasiaId INT;
SET @australasiaId = (SELECT TOP 1 Id FROM "Realm" WHERE [Name] = 'Australasia');

----------------------

DECLARE @tropicalDryBroadleafForestsId INT;
SET @tropicalDryBroadleafForestsId = (SELECT TOP 1 Id FROM "Biome" WHERE [Name] = 'Tropical and subtropical dry broadleaf forests');

DECLARE @temperateGrasslandsId INT;
SET @temperateGrasslandsId = (SELECT TOP 1 Id FROM "Biome" WHERE [Name] = 'Temperate grasslands, savannas, and shrublands');

DECLARE @tropicalMoistBroadleftForestsId INT;
SET @tropicalMoistBroadleftForestsId = (SELECT TOP 1 Id FROM "Biome" WHERE [Name] = 'Tropical and subtropical moist broadleaf forests');

DECLARE @tropicalGrasslandsSavannasId INT;
SET @tropicalGrasslandsSavannasId = (SELECT TOP 1 Id FROM "Biome" WHERE [Name] = 'Tropical and subtropical grasslands, savannas, and shrublands');

DECLARE @montaneGrasslandsId INT;
SET @montaneGrasslandsId = (SELECT TOP 1 Id FROM "Biome" WHERE [Name] = 'Montane grasslands and shrublands');

DECLARE @mediterraneanForestsId INT;
SET @mediterraneanForestsId = (SELECT TOP 1 Id FROM "Biome" WHERE [Name] = 'Mediterranean forests, woodlands, and shrub');

INSERT INTO "RealmBiome" ([RealmId], [BiomeId])
VALUES
	(@afrotropicRealmId, @tropicalDryBroadleafForestsId),
	(@afrotropicRealmId, @temperateGrasslandsId),
	(@neotropicRealmId, @tropicalMoistBroadleftForestsId),
	(@neotropicRealmId, @tropicalGrasslandsSavannasId),
	(@australasiaId, @tropicalMoistBroadleftForestsId),
	(@australasiaId, @montaneGrasslandsId),
	(@australasiaId, @mediterraneanForestsId);

INSERT INTO "Ecoregion" ([Name], [RealmId], [BiomeId])
VALUES
	('Cape Verde Islands dry forests', @afrotropicRealmId, @tropicalDryBroadleafForestsId),
	('Madagascar dry deciduous forests', @afrotropicRealmId, @tropicalDryBroadleafForestsId),
	('Zambezian Cryptosepalum dry forests', @afrotropicRealmId, @tropicalDryBroadleafForestsId),
	('Al Hajar Al Gharbi montane woodlands', @afrotropicRealmId, @temperateGrasslandsId),
	('Amsterdam and Saint-Paul Islands temperate grasslands', @afrotropicRealmId, @temperateGrasslandsId),
	('Tristan Da Cunha-Gough Islands shrub and grasslands', @afrotropicRealmId, @temperateGrasslandsId),
	('Araucaria moist forests', @neotropicRealmId, @tropicalMoistBroadleftForestsId),
	('Bahia coastal forests', @neotropicRealmId, @tropicalMoistBroadleftForestsId),
	('Bolivian Yungas', @neotropicRealmId, @tropicalMoistBroadleftForestsId),
	('Beni savanna', @neotropicRealmId, @tropicalGrasslandsSavannasId),
	('Campos rupestres montane savanna', @neotropicRealmId, @tropicalGrasslandsSavannasId),
	('Huon Peninsula montane rain forests', @australasiaId, @tropicalMoistBroadleftForestsId),
	('Japen rain forests', @australasiaId, @tropicalMoistBroadleftForestsId),
	('Queensland tropical rain forests', @australasiaId, @tropicalMoistBroadleftForestsId),
	('Solomon Islands rain forests', @australasiaId, @tropicalMoistBroadleftForestsId),
	('Central Range sub-alpine grasslands', @australasiaId, @montaneGrasslandsId),
	('South Island montane grasslands', @australasiaId, @montaneGrasslandsId),
	('Eyre and York mallee', @australasiaId, @mediterraneanForestsId)
GO

INSERT INTO "Country" ([Name])
VALUES 
	('Cape Verde'),
	('Madagascar'),
	('Angola'),
	('Zambia'),
	('Oman'),
	('United Arab Emirates'),
	('French Southern Territories'),
	('Saint Helena'),
	('Argentina'),
	('Brazil'),
	('Bolivia'),
	('Peru'),
	('Papua New Guinea'),
	('Indonesia'),
	('Australia'),
	('Solomon Islands'),
	('New Zealand')
GO

-------------

DECLARE @capeVerdeEcoregionId INT;
SET @capeVerdeEcoregionId = (SELECT TOP 1 Id FROM "Ecoregion" WHERE [Name] = 'Cape Verde Islands dry forests');

DECLARE @madagascarForestsEcoregionId INT;
SET @madagascarForestsEcoregionId = (SELECT TOP 1 Id FROM "Ecoregion" WHERE [Name] = 'Madagascar dry deciduous forests');

DECLARE @zambezianForestsEcoregionId INT;
SET @zambezianForestsEcoregionId = (SELECT TOP 1 Id FROM "Ecoregion" WHERE [Name] = 'Zambezian Cryptosepalum dry forests');

DECLARE @alHajarWoodlandsEcoregionId INT;
SET @alHajarWoodlandsEcoregionId = (SELECT TOP 1 Id FROM "Ecoregion" WHERE [Name] = 'Al Hajar Al Gharbi montane woodlands');

DECLARE @amsterdamGrasslandsEcoregionId INT;
SET @amsterdamGrasslandsEcoregionId = (SELECT TOP 1 Id FROM "Ecoregion" WHERE [Name] = 'Amsterdam and Saint-Paul Islands temperate grasslands');

DECLARE @tristanGrasslandsEcoregionId INT;
SET @tristanGrasslandsEcoregionId = (SELECT TOP 1 Id FROM "Ecoregion" WHERE [Name] = 'Tristan Da Cunha-Gough Islands shrub and grasslands');

DECLARE @araucariaForestsEcoregionId INT;
SET @araucariaForestsEcoregionId = (SELECT TOP 1 Id FROM "Ecoregion" WHERE [Name] = 'Araucaria moist forests');

DECLARE @bahiaForestsEcoregionId INT;
SET @bahiaForestsEcoregionId = (SELECT TOP 1 Id FROM "Ecoregion" WHERE [Name] = 'Bahia coastal forests');

DECLARE @bolivianYungasEcoregionId INT;
SET @bolivianYungasEcoregionId = (SELECT TOP 1 Id FROM "Ecoregion" WHERE [Name] = 'Bolivian Yungas');

DECLARE @beniSavannaEcoregionId INT;
SET @beniSavannaEcoregionId = (SELECT TOP 1 Id FROM "Ecoregion" WHERE [Name] = 'Beni savanna');

DECLARE @camposSavannaEcoregionId INT;
SET @camposSavannaEcoregionId = (SELECT TOP 1 Id FROM "Ecoregion" WHERE [Name] = 'Campos rupestres montane savanna');

DECLARE @huonPeninsulaForestsEcoregionId INT;
SET @huonPeninsulaForestsEcoregionId = (SELECT TOP 1 Id FROM "Ecoregion" WHERE [Name] = 'Huon Peninsula montane rain forests');

DECLARE @japenForestsEcoregionId INT;
SET @japenForestsEcoregionId = (SELECT TOP 1 Id FROM "Ecoregion" WHERE [Name] = 'Japen rain forests');

DECLARE @queenslandForestsEcoregionId INT;
SET @queenslandForestsEcoregionId = (SELECT TOP 1 Id FROM "Ecoregion" WHERE [Name] = 'Queensland tropical rain forests');

DECLARE @solomonIslandsForestsEcoregionId INT;
SET @solomonIslandsForestsEcoregionId = (SELECT TOP 1 Id FROM "Ecoregion" WHERE [Name] = 'Solomon Islands rain forests');

DECLARE @centralRangeSubAlpineGrasslandsEcoregionId INT;
SET @centralRangeSubAlpineGrasslandsEcoregionId = (SELECT TOP 1 Id FROM "Ecoregion" WHERE [Name] = 'Central Range sub-alpine grasslands');

DECLARE @southIslandsGrasslandsEcoregionId INT;
SET @southIslandsGrasslandsEcoregionId = (SELECT TOP 1 Id FROM "Ecoregion" WHERE [Name] = 'South Island montane grasslands');

DECLARE @eyreYorkMalleeEcoregionId INT;
SET @eyreYorkMalleeEcoregionId = (SELECT TOP 1 Id FROM "Ecoregion" WHERE [Name] = 'Eyre and York mallee');

--------

DECLARE @capeVerdeCountryId INT = (SELECT TOP 1 Id FROM "Country" WHERE [Name] = 'Cape Verde');

DECLARE @madagascarCountryId INT = (SELECT TOP 1 Id FROM "Country" WHERE [Name] = 'Madagascar');

DECLARE @angolaCountryId INT = (SELECT TOP 1 Id FROM "Country" WHERE [Name] = 'Angola');

DECLARE @zambiaCountryId INT = (SELECT TOP 1 Id FROM "Country" WHERE [Name] = 'Zambia');

DECLARE @omanCountryId INT = (SELECT TOP 1 Id FROM "Country" WHERE [Name] = 'Oman');

DECLARE @unitedArabEmiratesCountryId INT = (SELECT TOP 1 Id FROM "Country" WHERE [Name] = 'United Arab Emirates');

DECLARE @frenchSouthernTerritoriesCountryId INT = (SELECT TOP 1 Id FROM "Country" WHERE [Name] = 'French Southern Territories');

DECLARE @saintHelenaCountryId INT = (SELECT TOP 1 Id FROM "Country" WHERE [Name] = 'Saint Helena');

DECLARE @argentinaCountryId INT = (SELECT TOP 1 Id FROM "Country" WHERE [Name] = 'Argentina');

DECLARE @brazilCountryId INT = (SELECT TOP 1 Id FROM "Country" WHERE [Name] = 'Brazil');

DECLARE @boliviaCountryId INT = (SELECT TOP 1 Id FROM "Country" WHERE [Name] = 'Bolivia');

DECLARE @peruCountryId INT = (SELECT TOP 1 Id FROM "Country" WHERE [Name] = 'Peru');

DECLARE @papuaNewGuineaCountryId INT = (SELECT TOP 1 Id FROM "Country" WHERE [Name] = 'Papua New Guinea');

DECLARE @indonesiaCountryId INT = (SELECT TOP 1 Id FROM "Country" WHERE [Name] = 'Indonesia');

DECLARE @australiaCountryId INT = (SELECT TOP 1 Id FROM "Country" WHERE [Name] = 'Australia');

DECLARE @solomonIslandsCountryId INT = (SELECT TOP 1 Id FROM "Country" WHERE [Name] = 'Solomon Islands');

DECLARE @newZealandCountryId INT = (SELECT TOP 1 Id FROM "Country" WHERE [Name] = 'New Zealand');


INSERT INTO "EcoregionCountry" ([EcoregionId], [CountryId])
VALUES
	(@capeVerdeEcoregionId, @capeVerdeCountryId),
	(@madagascarForestsEcoregionId, @madagascarCountryId),
	(@zambezianForestsEcoregionId, @angolaCountryId),
	(@zambezianForestsEcoregionId, @zambiaCountryId),
	(@alHajarWoodlandsEcoregionId, @omanCountryId),
	(@alHajarWoodlandsEcoregionId, @unitedArabEmiratesCountryId),
	(@amsterdamGrasslandsEcoregionId, @frenchSouthernTerritoriesCountryId),
	(@tristanGrasslandsEcoregionId, @saintHelenaCountryId),
	(@araucariaForestsEcoregionId, @argentinaCountryId),
	(@araucariaForestsEcoregionId, @brazilCountryId),
	(@bahiaForestsEcoregionId, @brazilCountryId),
	(@bolivianYungasEcoregionId, @boliviaCountryId),
	(@bolivianYungasEcoregionId, @peruCountryId),
	(@beniSavannaEcoregionId, @boliviaCountryId),
	(@camposSavannaEcoregionId, @brazilCountryId),
	(@huonPeninsulaForestsEcoregionId, @papuaNewGuineaCountryId),
	(@japenForestsEcoregionId, @indonesiaCountryId),
	(@queenslandForestsEcoregionId, @australiaCountryId),
	(@solomonIslandsForestsEcoregionId, @solomonIslandsCountryId),
	(@centralRangeSubAlpineGrasslandsEcoregionId, @indonesiaCountryId),
	(@centralRangeSubAlpineGrasslandsEcoregionId, @papuaNewGuineaCountryId),
	(@southIslandsGrasslandsEcoregionId, @newZealandCountryId),
	(@eyreYorkMalleeEcoregionId, @australiaCountryId)


INSERT INTO "Species" ([CommonName], [ScientificName])
VALUES
	('White Hourse', 'Equus caballus'),
	('Kangaroo', 'Macropus rufus'),
	('Black Bear', 'Ursus americanus'),
	('Bonobo', 'Pan paniscus'),
	('Lemur', 'Lemuroidea'),
	('Elephant', 'Loxodonta'),
	('Zebra', 'Equus quagga'),
	('Vervet Monkey', 'Chlorocebus pygerythrus'),
	('Brown Fox', 'Vulpes'),
	('Gibbon', 'Hylobatidae'),
	('Gorilla', 'Gorilla'),
	('Lion', 'Panthera leo'),
	('Koala', 'Phascolarctos cinereus'),
	('White Tiger', 'Panthera tigris')


DECLARE @whiteHourseSpeciesId INT = (SELECT TOP 1 Id FROM "Species" WHERE [CommonName] = 'White Hourse');
DECLARE @kangarooSpeciesId INT = (SELECT TOP 1 Id FROM "Species" WHERE [CommonName] = 'Kangaroo');
DECLARE @blackBearSpeciesId INT = (SELECT TOP 1 Id FROM "Species" WHERE [CommonName] = 'Black Bear');
DECLARE @bonoboSpeciesId INT = (SELECT TOP 1 Id FROM "Species" WHERE [CommonName] = 'Bonobo');
DECLARE @lemurSpeciesId INT = (SELECT TOP 1 Id FROM "Species" WHERE [CommonName] = 'Lemur');
DECLARE @elephantSpeciesId INT = (SELECT TOP 1 Id FROM "Species" WHERE [CommonName] = 'Elephant');
DECLARE @zebraSpeciesId INT = (SELECT TOP 1 Id FROM "Species" WHERE [CommonName] = 'Zebra');
DECLARE @vervetMonkeySpeciesId INT = (SELECT TOP 1 Id FROM "Species" WHERE [CommonName] = 'Vervet Monkey');
DECLARE @brownFoxSpeciesId INT = (SELECT TOP 1 Id FROM "Species" WHERE [CommonName] = 'Brown Fox');
DECLARE @gibbonSpeciesId INT = (SELECT TOP 1 Id FROM "Species" WHERE [CommonName] = 'Gibbon');
DECLARE @gorillaSpeciesId INT = (SELECT TOP 1 Id FROM "Species" WHERE [CommonName] = 'Gorilla');
DECLARE @lionSpeciesId INT = (SELECT TOP 1 Id FROM "Species" WHERE [CommonName] = 'Lion');
DECLARE @koalaSpeciesId INT = (SELECT TOP 1 Id FROM "Species" WHERE [CommonName] = 'Koala');
DECLARE @whiteTigerSpeciesId INT = (SELECT TOP 1 Id FROM "Species" WHERE [CommonName] = 'White Tiger');

INSERT INTO "SpeciesDistribution" ([SpeciesId], [EcoregionId], [CountryId], [Population])
VALUES 
	(@whiteHourseSpeciesId, @capeVerdeEcoregionId, @capeVerdeCountryId, 900),
	(@kangarooSpeciesId, @madagascarForestsEcoregionId, @madagascarCountryId, 6200),
	(@blackBearSpeciesId, @zambezianForestsEcoregionId, @angolaCountryId, 5600),
	(@bonoboSpeciesId, @zambezianForestsEcoregionId, @zambiaCountryId, 7100),
	(@lemurSpeciesId, @alHajarWoodlandsEcoregionId, @omanCountryId, 3400),
	(@elephantSpeciesId, @alHajarWoodlandsEcoregionId, @unitedArabEmiratesCountryId, 4600),
	(@zebraSpeciesId, @amsterdamGrasslandsEcoregionId, @frenchSouthernTerritoriesCountryId, 2100),
	(@vervetMonkeySpeciesId, @tristanGrasslandsEcoregionId, @saintHelenaCountryId, 8300),
	(@brownFoxSpeciesId, @araucariaForestsEcoregionId, @argentinaCountryId, 2150),
	(@gibbonSpeciesId, @araucariaForestsEcoregionId, @brazilCountryId, 400),
	(@gorillaSpeciesId, @bahiaForestsEcoregionId, @brazilCountryId, 550),
	(@lionSpeciesId, @bolivianYungasEcoregionId, @boliviaCountryId, 700),
	(@koalaSpeciesId, @bolivianYungasEcoregionId, @peruCountryId, 5200),
	(@whiteTigerSpeciesId, @beniSavannaEcoregionId, @boliviaCountryId, 320),
	(@brownFoxSpeciesId, @camposSavannaEcoregionId, @brazilCountryId, 2150),
	(@bonoboSpeciesId, @huonPeninsulaForestsEcoregionId, @papuaNewGuineaCountryId, 7100),
	(@gibbonSpeciesId, @japenForestsEcoregionId, @indonesiaCountryId, 400),
	(@gorillaSpeciesId, @queenslandForestsEcoregionId, @australiaCountryId, 550),
	(@vervetMonkeySpeciesId, @solomonIslandsForestsEcoregionId, @solomonIslandsCountryId, 8300),
	(@lemurSpeciesId, @centralRangeSubAlpineGrasslandsEcoregionId, @indonesiaCountryId, 3400),
	(@whiteTigerSpeciesId, @centralRangeSubAlpineGrasslandsEcoregionId, @papuaNewGuineaCountryId, 3400),
	(@brownFoxSpeciesId, @southIslandsGrasslandsEcoregionId, @newZealandCountryId, 450),
	(@koalaSpeciesId, @eyreYorkMalleeEcoregionId, @australiaCountryId, 120)
GO