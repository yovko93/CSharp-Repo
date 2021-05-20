
-- Section 1. DDL

-- 1. Database design

CREATE DATABASE Bakery

USE [Bakery]

-- Section 1. DDL

CREATE TABLE Countries (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Customers(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(25) NOT NULL,
	LastName NVARCHAR(25) NOT NULL,
	Gender CHAR(1) NOT NULL CHECK(Gender IN ('M', 'F')),
	Age INT NOT NULL,
	PhoneNumber CHAR(10) NOT NULL CHECK(LEN(PhoneNumber) = 10),
	CountryId INT NOT NULL FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Products(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) NOT NULL UNIQUE,
	[Description] NVARCHAR(250) NOT NULL,
	Recipe NVARCHAR(MAX) NOT NULL,
	Price MONEY NOT NULL CHECK(Price >= 0)
)

CREATE TABLE Feedbacks(
	Id INT PRIMARY KEY IDENTITY,
	[Description] NVARCHAR(255),
	Rate DECIMAL(4, 2) NOT NULL CHECK(Rate BETWEEN 0 AND 10),
	ProductId INT NOT NULL FOREIGN KEY REFERENCES Products(Id),
	CustomerId INT NOT NULL FOREIGN KEY REFERENCES Customers(Id)
)

CREATE TABLE Distributors(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) NOT NULL UNIQUE,
	AddressText NVARCHAR(30) NOT NULL,
	Summary NVARCHAR(200) NOT NULL,
	CountryId INT NOT NULL FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Ingredients(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	[Description] NVARCHAR(200) NOT NULL,
	OriginCountryId INT NOT NULL FOREIGN KEY REFERENCES Countries(Id),
	DistributorId INT NOT NULL FOREIGN KEY REFERENCES Distributors(Id)
)

CREATE TABLE ProductsIngredients (
	ProductId INT NOT NULL FOREIGN KEY REFERENCES Products(Id),
	IngredientId INT NOT NULL FOREIGN KEY REFERENCES Ingredients(Id),
	PRIMARY KEY(ProductId, IngredientId)
)

------------------------------------------------
-- Section 2. DML 

-- 2. Insert

INSERT INTO Distributors([Name], CountryId, AddressText, Summary)
	VALUES
		('Deloitte & Touche', 2, '6 Arch St #9757', 'Customizable neutral traveling'),
		('Congress Title', 13, '58 Hancock St', 'Customer loyalty'),
		('Kitchen People', 1, '3 E 31st St #77', 'Triple-buffered stable delivery'),
		('General Color Co Inc', 21, '6185 Bohn St #72', 'Focus group'),
		('Beck Corporation', 23, '21 E 64th Ave', 'Quality-focused 4th generation hardware')

INSERT INTO Customers(FirstName, LastName, Age, Gender, PhoneNumber, CountryId)
	VALUES
	('Francoise', 'Rautenstrauch', 15, 'M', '0195698399', 5),
	('Kendra', 'Loud', 22, 'F', '0063631526', 11),
	('Lourdes', 'Bauswell', 50, 'M', '0139037043', 8),
	('Hannah', 'Edmison', 18, 'F', '0043343686', 1),
	('Tom', 'Loeza', 31, 'M', '0144876096', 23),
	('Queenie', 'Kramarczyk', 30, 'F', '0064215793', 29),
	('Hiu', 'Portaro', 25, 'M', '0068277755', 16),
	('Josefa', 'Opitz', 43, 'F', '0197887645', 17)

-------------------------------------------------------
-- 3. Update

UPDATE Ingredients
SET DistributorId = 35
WHERE Name IN ('Bay Leaf', 'Paprika', 'Poppy')

UPDATE Ingredients
SET OriginCountryId = 14
WHERE OriginCountryId = 8

-------------------------------------------------------
-- 4. Delete

DELETE Feedbacks
WHERE CustomerId = 14 OR ProductId = 5

------------------------------------------------------
-- Section 3. Querying

-- 5. Products by Price

SELECT Name, Price, Description
	FROM Products
	ORDER BY Price DESC, Name ASC

----------------------------------------------------
-- 6. Negative Feedback

SELECT f.ProductId, f.Rate, f.Description, f.CustomerId, c.Age, c.Gender
	FROM Feedbacks f
	JOIN Customers c ON c.Id = f.CustomerId
	WHERE f.Rate < 5.0
	ORDER BY f.ProductId DESC, f.Rate ASC

--------------------------------------------------
-- 7. Customers without Feedback

SELECT  CONCAT(c.FirstName, ' ', c.LastName) AS [CustomerName],
		c.PhoneNumber AS PhoneNumber,
		c.Gender AS Gender
	FROM Customers c 
	LEFT JOIN Feedbacks f ON c.Id = f.CustomerId
	WHERE f.Id IS NULL
	ORDER BY c.Id ASC

--------------------------------------------------
-- 8. Customers by Criteria

SELECT c.FirstName, c.Age, c.PhoneNumber
	FROM Customers c
	JOIN Countries ct ON ct.Id = c.CountryId
	WHERE (c.Age >= 21 AND c.FirstName LIKE '%an%') 
		OR (c.PhoneNumber LIKE '%38' AND ct.Name != 'Greece')
		ORDER BY c.FirstName ASC, c.Age DESC

-------------------------------------------------
-- 9. Middle Range Distributors

SELECT d.Name AS DistributorName, 
		i.Name AS IngredientName, 
		p.Name AS ProductName,
		AVG(f.Rate) AS AverageRate
	FROM Products p
	JOIN Feedbacks f ON f.ProductId = p.Id
	JOIN ProductsIngredients pin ON pin.ProductId = p.Id
	JOIN Ingredients i ON i.Id = pin.IngredientId
	JOIN Distributors d ON d.Id = i.DistributorId
	GROUP BY d.Name, i.Name, p.Name
	HAVING AVG(f.Rate) BETWEEN 5 AND 8
	ORDER BY DistributorName, IngredientName, ProductName

------------------------------------------------
-- 10. Country Representative

SELECT CountryName, DisributorName FROM ( SELECT 
		c.Name AS CountryName,
		d.Name AS DisributorName,
		DENSE_RANK() OVER(PARTITION BY c.[Name] ORDER BY COUNT(i.Id) DESC) AS [Rank]
	FROM Countries c
	JOIN Distributors d ON d.CountryId = c.Id
	LEFT JOIN Ingredients i ON i.DistributorId = d.Id
	GROUP BY c.Name, d.Name) AS MainQuery
	WHERE [Rank] = 1
	ORDER BY CountryName, DisributorName

----------------------------------------------------------
-- Section 4. Programmability 

-- 11. Customers with Countries

CREATE VIEW v_UserWithCountries
AS
SELECT c.FirstName + ' ' + c.LastName AS CustomerName,
	c.Age,
	c.Gender,
	ct.Name AS CountryName
	FROM Customers c
	JOIN Countries ct ON ct.Id = c.CountryId

-----------------------------------------------------
-- 12. Delete Products

CREATE TRIGGER tr_DeleteRelations
ON dbo.Products INSTEAD OF DELETE
AS
DECLARE @ProductId INT = 
	(SELECT p.Id 
		FROM Products p 
		JOIN deleted d ON d.Id = p.Id)

DELETE FROM ProductsIngredients
WHERE ProductId = @ProductId 

DELETE FROM Feedbacks
WHERE ProductId = @ProductId

DELETE FROM Products
WHERE Id = @ProductId
