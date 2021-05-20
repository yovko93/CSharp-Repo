
-- Section 1. DDL 

CREATE DATABASE WMS

USE [WMS]

CREATE TABLE Clients(
	ClientId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Phone CHAR(12) CHECK(LEN(Phone) = 12) NOT NULL
)

CREATE TABLE Mechanics(
	MechanicId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	[Address] VARCHAR(255) NOT NULL
)

CREATE TABLE Models(
	ModelId INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL,
)

CREATE TABLE Jobs(
	JobId INT PRIMARY KEY IDENTITY,
	ModelId INT NOT NULL FOREIGN KEY REFERENCES Models(ModelId),
	[Status] VARCHAR(11) DEFAULT 'Pending' CHECK([Status] IN ('Pending', 'In Progress', 'Finished')) NOT NULL,
	ClientId INT NOT NULL FOREIGN KEY REFERENCES Clients(ClientId),
	MechanicId INT FOREIGN KEY REFERENCES Mechanics(MechanicId),
	IssueDate DATE NOT NULL,
	FinishDate DATE
)

CREATE TABLE Orders(
	OrderId INT PRIMARY KEY IDENTITY,
	JobId INT NOT NULL FOREIGN KEY REFERENCES Jobs(JobId),
	IssueDate DATE,
	Delivered BIT DEFAULT 0
)

CREATE TABLE Vendors(
	VendorId INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Parts(
	PartId INT PRIMARY KEY IDENTITY,
	SerialNumber VARCHAR(50) UNIQUE NOT NULL,
	[Description] VARCHAR(255),
	Price DECIMAL(6, 2) NOT NULL
	CHECK(Price > 0 AND Price <= 9999.99),
	VendorId INT NOT NULL FOREIGN KEY REFERENCES Vendors(VendorId),
	StockQty INT NOT NULL DEFAULT 0 CHECK(StockQty >= 0)
)

CREATE TABLE OrderParts(
	OrderId INT NOT NULL FOREIGN KEY REFERENCES Orders(OrderId),
	PartId INT NOT NULL FOREIGN KEY REFERENCES Parts(PartId),
	Quantity INT NOT NULL CHECK(Quantity > 0) DEFAULT 1
	PRIMARY KEY(OrderId, PartId)
)

CREATE TABLE PartsNeeded(
	JobId INT NOT NULL FOREIGN KEY REFERENCES Jobs(JobId),
	PartId INT NOT NULL FOREIGN KEY REFERENCES Parts(PartId),
	Quantity INT NOT NULL CHECK(Quantity > -1) DEFAULT 1,
	PRIMARY KEY(JobId, PartId)
)

---------------------------------------------------
-- 2. Insert

INSERT INTO Clients(FirstName, LastName, Phone)
	VALUES
		('Teri', 'Ennaco', '570-889-5187'),
		('Merlyn', 'Lawler', '201-588-7810'),
		('Georgene', 'Montezuma', '925-615-5185'),
		('Jettie', 'Mconnell', '908-802-3564'),
		('Lemuel', 'Latzke', '631-748-6479'),
		('Melodie', 'Knipp', '805-690-1682'),
		('Candida', 'Corbley', '908-275-8357')

INSERT INTO Parts(SerialNumber, [Description], Price, VendorId)
	VALUES
		('WP8182119', 'Door Boot Seal', 117.86, 2),
		('W10780048', 'Suspension Rod', 42.81, 1),
		('W10841140', 'Silicone Adhesive ', 6.77, 4),
		('WPY055980', 'High Temperature Adhesive', 13.94, 3)

------------------------------------------------
-- 3. Update

UPDATE Jobs
SET MechanicId = 3, [Status] = 'In Progress'
WHERE [Status] LIKE 'Pending'

-------------------------------------------------
-- 4. Delete

DELETE OrderParts WHERE OrderId = 19
DELETE Orders WHERE OrderId = 19

-------------------------------------------------
-- 5. Mechanic Assignments

SELECT CONCAT(m.FirstName, ' ', m.LastName) AS [Mechanic], j.[Status], j.IssueDate
	FROM Mechanics m
	JOIN Jobs j ON m.MechanicId = j.MechanicId
	ORDER BY m.MechanicId, j.IssueDate, j.JobId

-------------------------------------------------
-- 6. Current Clients

SELECT c.FirstName + ' ' + c.LastName AS [Client],
	DATEDIFF(DAY, j.IssueDate, '2017-04-24') AS [Days going], 
	j.[Status]
		FROM Jobs j
		JOIN Clients c ON j.ClientId = c.ClientId
		WHERE j.[Status] NOT LIKE 'Finished'
		ORDER BY [Days going] DESC, c.ClientId ASC

-------------------------------------------------
-- 7. Mechanic Performance

SELECT  m.FirstName + ' ' + m.LastName AS [Mechanic], 
		AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS [Average Days]
	FROM Jobs j
	JOIN Mechanics m ON m.MechanicId = j.MechanicId
	GROUP BY j.MechanicId, (m.FirstName + ' ' + m.LastName)
	ORDER BY j.MechanicId

---------------------------------------------------
-- 8. Available Mechanics

SELECT m.FirstName + ' ' + m.LastName AS [Available]
	FROM Mechanics m
	LEFT JOIN Jobs j ON j.MechanicId = m.MechanicId
	WHERE j.JobId IS NULL OR (SELECT COUNT(JobId)
						FROM Jobs
						WHERE [Status] <> 'Finished' AND MechanicId = m.MechanicId
						GROUP BY MechanicId, [Status]) IS NULL
	GROUP BY m.MechanicId, (m.FirstName + ' ' + m.LastName) 

----------------------------------------------------
-- 9. Past Expenses

SELECT j.JobId, ISNULL(SUM(p.Price * op.Quantity), 0) AS [Total]
	FROM Jobs j
	LEFT JOIN Orders o ON j.JobId = o.JobId
	LEFT JOIN OrderParts op ON op.OrderId = o.OrderId
	LEFT JOIN Parts p ON p.PartId = op.PartId
	WHERE j.[Status] = 'Finished'
	GROUP BY j.JobId
	ORDER BY Total DESC, j.JobId

----------------------------------------------------
-- 10. Missing Parts

SELECT p.PartId, 
		p.Description, 
		pn.Quantity AS [Required],
		p.StockQty AS [InStock],
		IIF(o.Delivered = 0, op.Quantity, 0) AS [Ordered]
	FROM Parts p
	LEFT JOIN PartsNeeded pn ON pn.PartId = p.PartId
	LEFT JOIN OrderParts op ON op.PartId = p.PartId
	LEFT JOIN Jobs j ON j.JobId = pn.JobId
	LEFT JOIN Orders o ON o.JobId = j.JobId
	WHERE j.Status <> 'Finished' AND p.StockQty + IIF(o.Delivered = 0, op.Quantity, 0) < pn.Quantity
	ORDER BY PartId

-- 2nd way

SELECT p.PartId, p.[Description],
		SUM(pn.Quantity) AS [Required],
		SUM(p.StockQty) AS [InStock]
	FROM Jobs j
FULL JOIN Orders o ON j.JobId = o.JobId
	JOIN PartsNeeded pn ON pn.JobId = j.JobId
	JOIN Parts p ON p.PartId = pn.PartId
	WHERE j.Status <> 'Finished' AND o.Delivered IS NULL
	GROUP BY p.PartId, p.Description
	HAVING SUM(p.StockQty) < SUM(pn.Quantity)

-------------------------------------------------
-- 11. Place Order

CREATE PROC usp_PlaceOrder (
	@jobID INT, 
	@serialNumber VARCHAR(50),
	@quantity INT
)
AS

DECLARE @status VARCHAR(10) = 
	(SELECT [Status] FROM Jobs WHERE JobId = @jobID)
DECLARE @partId VARCHAR(10) = 
	(SELECT PartId FROM Parts WHERE SerialNumber = @serialNumber)

IF(@quantity <= 0)
THROW 50012, 'Part quantity must be more than zero!', 1
ELSE IF(@status IS NULL)
THROW 50013, 'Job not found!', 1
ELSE IF(@status = 'Finished')
THROW 50011, 'This job is not active!', 1
ELSE IF(@partId IS NULL)
THROW 50014, 'Part not found!', 1

DECLARE @orderId INT = (SELECT o.OrderId 
	FROM Orders o
	WHERE JobId = @jobID AND o.IssueDate IS NULL)

IF(@orderId IS NULL)
BEGIN
	INSERT INTO Orders (JobId, IssueDate) VALUES (@jobID, NULL)
END

SET @orderId = 
(SELECT o.OrderId FROM Orders o WHERE JobId = @jobID AND o.IssueDate IS NULL)
DECLARE @orderPartExists INT = (SELECT OrderId FROM OrderParts WHERE OrderId = @orderId AND PartId = @partId)

IF (@orderPartExists IS NULL)
BEGIN
	INSERT INTO OrderParts (OrderId, PartId, Quantity) VALUES
		(@orderId, @partId, @quantity)
END

ELSE
BEGIN
	UPDATE OrderParts
	SET Quantity += @quantity
	WHERE OrderId = @orderId AND PartId = @partId
END

DECLARE @err_msg AS NVARCHAR(MAX);
BEGIN TRY
  EXEC usp_PlaceOrder 1, 'ZeroQuantity', 0
END TRY

BEGIN CATCH
  SET @err_msg = ERROR_MESSAGE();
  SELECT @err_msg
END CATCH


------------------------------------------------------
-- 12. Cost Of Order

CREATE FUNCTION udf_GetCost (@jobID INT)
RETURNS DECIMAL(15, 2)
AS
BEGIN
DECLARE @result DECIMAL(15, 2);
SET @result = (SELECT SUM(p.Price * op.Quantity) AS totalSum
		FROM Jobs j
		JOIN Orders o ON o.JobId = j.JobId
		JOIN OrderParts op ON op.OrderId = o.OrderId
		JOIN Parts p ON p.PartId = op.PartId
		WHERE j.JobId = @jobID
		GROUP BY j.JobId)

IF(@result IS NULL)
	SET @result = 0;

RETURN @result

END

SELECT dbo.udf_GetCost(1)