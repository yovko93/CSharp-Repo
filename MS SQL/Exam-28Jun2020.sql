-- Database Basics (MSSQL) Exam 
-- Colonial Journey

CREATE DATABASE ColonialJourney

USE [ColonialJourney]

-- Section 1. DDL

CREATE TABLE Planets(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE Spaceports(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PlanetId INT NOT NULL FOREIGN KEY REFERENCES Planets(Id)
)

CREATE TABLE Spaceships(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Manufacturer VARCHAR(30) NOT NULL,
	LightSpeedRate INT DEFAULT 0
)

CREATE TABLE Colonists(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Ucn VARCHAR(10) NOT NULL UNIQUE,
	BirthDate DATE NOT NULL
)

CREATE TABLE Journeys(
	Id INT PRIMARY KEY IDENTITY,
	JourneyStart DATETIME NOT NULL,
	JourneyEnd DATETIME NOT NULL,
	Purpose VARCHAR(11) CHECK(Purpose IN ('Medical', 'Technical', 'Educational', 'Military')),
	DestinationSpaceportId INT NOT NULL FOREIGN KEY REFERENCES Spaceports(Id),
	SpaceshipId INT NOT NULL FOREIGN KEY REFERENCES Spaceships(Id)
)

CREATE TABLE TravelCards(
	Id INT PRIMARY KEY IDENTITY,
	CardNumber CHAR(10) NOT NULL UNIQUE,
	JobDuringJourney VARCHAR(8) 
	CHECK(JobDuringJourney IN ('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook')),
	ColonistId INT NOT NULL FOREIGN KEY REFERENCES Colonists(Id),
	JourneyId INT NOT NULL FOREIGN KEY REFERENCES Journeys(Id)
)

-------------------------------------------------
-- Section 2. DML

-- 2. Insert

INSERT INTO Planets([Name])
	VALUES
		('Mars'),
		('Earth'),
		('Jupiter'),
		('Saturn')

INSERT INTO Spaceships([Name], Manufacturer, LightSpeedRate)
	VALUES
		('Golf', 'VW', 3),
		('WakaWaka', 'Wakanda', 4),
		('Falcon9', 'SpaceX', 1),
		('Bed', 'Vidolov', 6)
		
--------------------------------------------------
-- 3. Update

UPDATE Spaceships
SET LightSpeedRate += 1
WHERE Id BETWEEN 8 AND 12

-------------------------------------------------
-- 4. Delete

DELETE FROM TravelCards
WHERE JourneyId IN (1, 2, 3)

DELETE FROM Journeys
WHERE Id IN (1, 2 , 3)

-------------------------------------------------
-- 5. Select all military journeys

SELECT  Id, 
		FORMAT(JourneyStart, 'dd/MM/yyyy') AS JourneyStart,
		FORMAT(JourneyEnd, 'dd/MM/yyyy') AS JourneyEnd
	FROM Journeys
	WHERE Purpose LIKE 'Military'
	ORDER BY JourneyStart

--------------------------------------------------
-- 6. Select all pilots

SELECT c.Id,
		c.FirstName + ' ' + c.LastName AS [full_name]
	FROM Colonists c
	JOIN TravelCards tc ON tc.ColonistId = c.Id
	WHERE tc.JobDuringJourney LIKE 'Pilot'
	ORDER BY c.Id

--------------------------------------------------
-- 7. Count colonists

SELECT COUNT(*) AS [count]
	FROM TravelCards tc
	JOIN Journeys j ON j.Id = tc.JourneyId
	WHERE j.Purpose LIKE 'Technical'

---------------------------------------------------
-- 8. Select spaceships with pilots younger than 30 years

SELECT s.Name, s.Manufacturer
	FROM TravelCards tc
	JOIN Colonists c ON c.Id = tc.ColonistId
	JOIN Journeys j ON j.Id = tc.JourneyId
	JOIN Spaceships s ON s.Id = j.SpaceshipId
	WHERE c.BirthDate > '1989/01/01' 
		AND tc.JobDuringJourney LIKE 'Pilot'
		ORDER BY s.Name

-------------------------------------------------
-- 9. Select all planets and their journey count

SELECT p.Name AS PlanetName, COUNT(*) AS JourneysCount
	FROM Planets p
	JOIN Spaceports sp ON sp.PlanetId = p.Id
	JOIN Journeys j ON j.DestinationSpaceportId = sp.Id
	GROUP BY p.Name
	ORDER BY JourneysCount DESC, PlanetName ASC

------------------------------------------------
-- 10. Select Second Oldest Important Colonist

SELECT * FROM (
SELECT tc.JobDuringJourney AS [JobDuringJourney],
		c.FirstName + ' ' + c.LastName AS [FullName],
		DENSE_RANK() OVER(PARTITION BY tc.JobDuringJourney ORDER BY c.Birthdate) AS [Rank]
	FROM Colonists c
	JOIN TravelCards tc ON tc.ColonistId = c.Id
	JOIN Journeys j ON j.Id = tc.JourneyId) AS MainQuery
	WHERE [Rank] = 2

--------------------------------------------------
-- Section 4. Programmability

-- 11. Get Colonists Count

CREATE FUNCTION udf_GetColonistsCount(@PlanetName VARCHAR(30))
RETURNS INT
AS
BEGIN
DECLARE @Count INT = ( SELECT COUNT(*)
				FROM Planets p
				JOIN Spaceports sp ON sp.PlanetId = p.Id
				JOIN Journeys j ON j.DestinationSpaceportId = sp.Id
				JOIN TravelCards tc ON tc.JourneyId = j.Id
				JOIN Colonists c ON c.Id = tc.ColonistId
				WHERE p.Name = @PlanetName
)

RETURN @Count;
END

--------------------------------------------------
-- 12. Change Journey Purpose

CREATE PROC usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(20))
AS
BEGIN
DECLARE @CurrentJourneyId INT = (SELECT Id FROM Journeys
								WHERE Id = @JourneyId)

IF (@CurrentJourneyId IS NULL)
	THROW 50001, 'The journey does not exist!', 1

DECLARE @CurrentJourneyPurpose VARCHAR(20) = (SELECT Purpose FROM Journeys
											WHERE Id = @JourneyId)

IF (@CurrentJourneyPurpose = @NewPurpose)
	THROW 50002, 'You cannot change the purpose!', 1

UPDATE Journeys
SET Purpose = @NewPurpose
WHERE Id = @JourneyId

END

EXEC usp_ChangeJourneyPurpose 4, 'Technical'
EXEC usp_ChangeJourneyPurpose 2, 'Educational'
EXEC usp_ChangeJourneyPurpose 196, 'Technical'
