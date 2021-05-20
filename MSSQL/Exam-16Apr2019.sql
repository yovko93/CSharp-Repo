-- Database Basics MS SQL Exam – 16 Apr 2019

-- Airport

CREATE DATABASE Airport

USE [Airport]

-- Section 1. DDL 

CREATE TABLE Planes(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	Seats INT NOT NULL,
	[Range] INT NOT NULL
)

CREATE TABLE Flights(
	Id INT PRIMARY KEY IDENTITY,
	DepartureTime DATETIME,
	ArrivalTime DATETIME,
	Origin VARCHAR(50) NOT NULL,
	Destination VARCHAR(50) NOT NULL,
	PlaneId INT NOT NULL FOREIGN KEY REFERENCES Planes(Id)
)

CREATE TABLE Passengers(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Age INT NOT NULL,
	[Address] VARCHAR(30) NOT NULL,
	PassportId CHAR(11) NOT NULL
)

CREATE TABLE LuggageTypes(
	Id INT PRIMARY KEY IDENTITY,
	[Type] VARCHAR(30) NOT NULL
)

CREATE TABLE Luggages(
	Id INT PRIMARY KEY IDENTITY,
	LuggageTypeId INT NOT NULL FOREIGN KEY REFERENCES LuggageTypes(Id),
	PassengerId INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id)
)

CREATE TABLE Tickets(
	Id INT PRIMARY KEY IDENTITY,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
	FlightId INT NOT NULL FOREIGN KEY REFERENCES Flights(Id),
	LuggageId INT NOT NULL FOREIGN KEY REFERENCES Luggages(Id),
	Price DECIMAL(15, 2) NOT NULL
)

---------------------------------------------------------
-- Section 2. DML 

-- 2. Insert

INSERT INTO Planes(Name, Seats, Range)
	VALUES
		('Airbus 336', 112,	5132),
		('Airbus 330', 432,	5325),
		('Boeing 369', 231, 2355),
		('Stelt 297', 254, 2143),
		('Boeing 338', 165, 5111),
		('Airbus 558', 387, 1342),
		('Boeing 128', 345, 5541)

INSERT INTO LuggageTypes([Type])
	VALUES
		('Crossbody Bag'),
		('School Backpack'),
		('Shoulder Bag')

-------------------------------------------------
-- 3. Update

UPDATE Tickets
SET Price *= 1.13
WHERE FlightId = 41

---------------------------------------------------
-- 4. Delete
DELETE FROM Tickets
WHERE FlightId = 30

DELETE FROM Flights
WHERE Destination LIKE 'Ayn Halagim'

----------------------------------------------------
-- Section 3. Querying 

-- 5. The "Tr" Planes

SELECT *
	FROM Planes
	WHERE [Name] LIKE '%tr%'
	ORDER BY Id ASC, [Name] ASC, Seats ASC, [Range] ASC

------------------------------------------------------
-- 6. Flight Profits

SELECT f.Id AS FlightId, SUM(t.Price) Price
	FROM Flights f
	JOIN Tickets t ON t.FlightId = f.Id
	GROUP BY f.Id
	ORDER BY Price DESC, FlightId ASC

---------------------------------------------------
-- 7. Passenger Trips

SELECT p.FirstName + ' ' + p.LastName AS [Full Name],
		f.Origin,
		f.Destination
	FROM Passengers p
	JOIN Tickets t ON t.PassengerId = p.Id
	JOIN Flights f ON f.Id = t.FlightId
	ORDER BY [Full Name] ASC, f.Origin ASC, f.Destination

---------------------------------------------------
-- 8. Non Adventures People

SELECT p.FirstName AS [First Name],
		p.LastName AS [Last Name],
		p.Age
	FROM Passengers p
	LEFT JOIN Tickets t ON t.PassengerId = p.Id
	WHERE t.PassengerId IS NULL
	ORDER BY p.Age DESC, [First Name] ASC, [LastName] ASC

----------------------------------------------------
-- 9. Full Info

SELECT p.FirstName + ' ' + p.LastName AS [Full Name],
		pl.[Name] AS [Plane Name],
		f.Origin + ' - ' + f.Destination AS [Trip],
		lt.[Type] AS [Luggage Type]
	FROM Passengers p
	JOIN Tickets t ON t.PassengerId = p.Id
	JOIN Flights f ON f.Id = t.FlightId
	JOIN Planes pl ON pl.Id = f.PlaneId
	JOIN Luggages l ON l.Id = t.LuggageId
	JOIN LuggageTypes lt ON lt.Id = l.LuggageTypeId
	ORDER BY [Full Name] ASC, [Plane Name] ASC, f.Origin ASC, f.Destination ASC, [Luggage Type] ASC

---------------------------------------------------
-- 10. PSP

SELECT pl.[Name] AS [Name],
		pl.Seats AS [Seats],
		COUNT(t.Id) AS [Passengers Count]
	FROM Planes pl
	LEFT JOIN Flights f ON f.PlaneId = pl.Id
	LEFT JOIN Tickets t ON t.FlightId = f.Id
	GROUP BY pl.Name, pl.Seats
	ORDER BY [Passengers Count] DESC, pl.[Name] ASC, pl.Seats ASC

-----------------------------------------------------
-- Section 4. Programmability 

-- 11. Vacation

CREATE FUNCTION udf_CalculateTickets(@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT)
RETURNS VARCHAR(50)
AS
BEGIN
DECLARE @Result VARCHAR(50);

IF (@peopleCount <= 0)
	RETURN 'Invalid people count!'

DECLARE @FlightId INT = (SELECT Id FROM Flights
							WHERE Origin = @origin
							AND Destination = @destination);
						
IF (@FlightId IS NULL)
	RETURN 'Invalid flight!'

DECLARE @TicketPrice DECIMAL(15, 2) = (SELECT t.Price FROM Tickets t
								JOIN Flights f ON f.Id = t.FlightId
								WHERE f.Origin = @origin
								AND f.Destination = @destination)

SET @Result = @TicketPrice * @peopleCount;
RETURN 'Total price ' + @Result;
END

------------------------------------------------------
-- 12. Wrong Data

CREATE PROC usp_CancelFlights
AS
BEGIN 
UPDATE Flights
SET DepartureTime = NULL, ArrivalTime = NULL
WHERE DepartureTime < ArrivalTime

END

EXEC usp_CancelFlights
