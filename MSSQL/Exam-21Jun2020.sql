---- Trip Service

CREATE DATABASE TripService

USE TripService

-- Section 1. DDL 

CREATE TABLE Cities(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	CountryCode CHAR(2) NOT NULL
)

CREATE TABLE Hotels(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	CityId INT NOT NULL FOREIGN KEY REFERENCES Cities(Id),
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(18, 2)
)

CREATE TABLE Rooms(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(18, 2) NOT NULL,
	[Type] NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT NOT NULL FOREIGN KEY REFERENCES Hotels(Id)
)

CREATE TABLE Trips(
	Id INT PRIMARY KEY IDENTITY,
	RoomId INT NOT NULL FOREIGN KEY REFERENCES Rooms(Id),
	BookDate DATE NOT NULL,
	ArrivalDate DATE NOT NULL,
	ReturnDate DATE NOT NULL,
	CancelDate DATE,
	CHECK(BookDate < ArrivalDate),
	CHECK(ArrivalDate < ReturnDate)
)

CREATE TABLE Accounts(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName NVARCHAR(50) NOT NULL,
	CityId INT NOT NULL FOREIGN KEY REFERENCES Cities(Id),
	BirthDate DATE NOT NULL,
	Email VARCHAR(100) NOT NULL UNIQUE
)

CREATE TABLE AccountsTrips(
	AccountId INT NOT NULL FOREIGN KEY REFERENCES Accounts(Id),
	TripId INT NOT NULL FOREIGN KEY REFERENCES Trips(Id),
	Luggage INT NOT NULL CHECK(Luggage >= 0),
	PRIMARY KEY(AccountId, TripId)
)

-----------------------------------------------------
-- 2. Insert

INSERT INTO Accounts(
	FirstName, MiddleName, LastName, CityId, BirthDate, Email)
		VALUES
('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com'),
('Gosho', NULL,	'Petrov', 11, '1978-05-16', 'g_petrov@gmail.com'),
('Ivan', 'Petrovich', 'Pavlov', 59, '1849-09-26', 'i_pavlov@softuni.bg'),
('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips(
	RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate)
		VALUES
	(101, '2015-04-12', '2015-04-14', '2015-04-20', '2015-02-02'),
	(102, '2015-07-07', '2015-07-15', '2015-07-22', '2015-04-29'),
	(103, '2013-07-17', '2013-07-23', '2013-07-24',	NULL),
	(104, '2012-03-17', '2012-03-31', '2012-04-01', '2012-01-10'),
	(109, '2017-08-07', '2017-08-28', '2017-08-29',	NULL)

---------------------------------------------------
-- 3. Update

UPDATE Rooms
SET Price *= 1.14
WHERE HotelId IN (5, 7, 9)

----------------------------------------------------
-- 4. Delete

DELETE AccountsTrips WHERE AccountId = 47

---------------------------------------------------
-- Section 3. Querying

-- 5. EEE-Mails

SELECT  a.FirstName,
		a.LastName,
		FORMAT(a.BirthDate, 'MM-dd-yyyy'),
		c.[Name] AS Hometown,
		a.Email
	FROM Accounts a
	JOIN Cities c ON c.Id = a.CityId
	WHERE a.Email LIKE 'e%'
	ORDER BY Hometown ASC

-------------------------------------------------
-- 6. City Statistics

SELECT c.Name AS [City], COUNT(*) AS [Hotels]
	FROM Cities c
	JOIN Hotels h ON h.CityId = c.Id
	GROUP BY c.Name
	ORDER BY Hotels DESC, c.Name

-------------------------------------------------
-- 7. Longest and Shortest Trips

SELECT  at.AccountId,
		a.FirstName + ' ' + a.LastName AS [FullName],
		MAX(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS [LongestTrip],
		MIN(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS [ShortestTrip]
	FROM Accounts a
	JOIN AccountsTrips [at] ON at.AccountId = a.Id
	JOIN Trips t ON t.Id = at.TripId
	WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL
	GROUP BY at.AccountId, a.FirstName + ' ' + a.LastName
	ORDER BY [LongestTrip] DESC, [ShortestTrip] ASC

--------------------------------------------------
-- 8. Metropolis

SELECT TOP(10)  c.Id,
		c.Name AS City,
		c.CountryCode AS Country,
		COUNT(*) AS Accounts
	FROM Cities c
	JOIN Accounts a ON a.CityId = c.Id
	GROUP BY c.Id, c.Name, c.CountryCode
	ORDER BY Accounts DESC

--------------------------------------------------
-- 9. Romantic Getaways

SELECT at.AccountId AS Id, a.Email, ac.Name, COUNT(*) AS Trips
	FROM AccountsTrips at
	JOIN Accounts a ON a.Id = at.AccountId
	JOIN Cities ac ON ac.Id = a.CityId
	JOIN Trips t ON t.Id = at.TripId
	JOIN Rooms r ON r.Id = t.RoomId
	JOIN Hotels h ON h.Id = r.HotelId
	WHERE h.CityId = a.CityId
	GROUP BY at.AccountId, a.Email, ac.Name
	ORDER BY Trips DESC, at.AccountId

------------------------------------------------
-- 10. GDPR Violation

SELECT  t.Id,
		a.FirstName + ' ' + ISNULL(a.MiddleName + ' ', '') + a.LastName AS [Full Name],
		ac.Name AS [From],
		hc.Name AS [To],
		CASE 
			WHEN t.CancelDate IS NULL THEN CONVERT(NVARCHAR(MAX), DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) + ' days'
			ELSE CONVERT(VARCHAR(20), 'Canceled')
		END AS [Duration]
	FROM AccountsTrips at
	JOIN Accounts a ON a.Id = at.AccountId
	JOIN Cities ac ON ac.Id = a.CityId
	JOIN Trips t ON t.Id = at.TripId
	JOIN Rooms r ON r.Id = t.RoomId
	JOIN Hotels h ON h.Id = r.HotelId
	JOIN Cities hc ON hc.Id = h.CityId
	ORDER BY [Full Name] ASC, t.Id

-------------------------------------------------
-- Section 4. Programmability

-- 11. Available Room

CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR(MAX)
BEGIN
	DECLARE @RoomInfo VARCHAR(MAX) = (SELECT TOP(1) 'Room ' + CONVERT(VARCHAR, r.Id) + ': ' + r.Type + ' (' + CONVERT(VARCHAR, r.Beds) + ' beds) - $' + CONVERT(VARCHAR, (BaseRate + Price) * @People)
		FROM Rooms r
		JOIN Hotels h ON r.HotelId = h.Id
		WHERE Beds >= @People AND HotelId = @HotelId AND
			NOT EXISTS (SELECT * FROM Trips t WHERE t.RoomId = r.Id 
										AND CancelDate IS NULL
										AND @Date BETWEEN ArrivalDate AND ReturnDate)
		ORDER BY (BaseRate + Price) * @People DESC);

		IF (@RoomInfo IS NULL)
			RETURN 'No rooms available';
		RETURN @RoomInfo;
END
GO

SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)

---------------------------------------------------
-- 12. Switch Room

CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
-- If the target room ID is in a different hotel, than the trip is in, raise an exception with the message “Target room is in another hotel!”.
DECLARE @tripHotelId INT = (SELECT r.HotelId FROM Trips t 
							JOIN Rooms r ON r.Id = t.RoomId
							WHERE t.Id = @TripId);
DECLARE @targetRoomHotelId INT = (SELECT HotelId FROM Rooms r
							WHERE r.Id = @TargetRoomId);

IF(@tripHotelId != @targetRoomHotelId)
	THROW 50001, 'Target room is in another hotel!', 1

-- If the target room doesn’t have enough beds for all the trip’s accounts, raise an exception with the message “Not enough beds in target room!”.
DECLARE @TripAccounts INT = (SELECT COUNT(*) FROM AccountsTrips
							WHERE TripId = @TripId);
DECLARE @TargetRoomBeds INT = (SELECT Beds FROM Rooms
								WHERE Id = @TargetRoomId);

IF(@TripAccounts > @TargetRoomBeds)
	THROW 50002, 'Not enough beds in target room!', 1

-- If all the above conditions pass, change the trip’s room ID to the target room ID.
UPDATE Trips
SET RoomId = @TargetRoomId
WHERE Id = @TripId


EXEC usp_SwitchRoom 10, 8
