CREATE DATABASE EntityRelationsDemo

USE [EntityRelationsDemo]
-----------------------------------
-- Problem 1. One-To-One Relationship

CREATE TABLE Passports(
	PassportID INT PRIMARY KEY IDENTITY(101, 1),
	PassportNumber CHAR(8) NOT NULL
)

CREATE TABLE Persons(
	PersonID INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	Salary DECIMAL(7,2) NOT NULL,
	PassportID INT NOT NULL FOREIGN KEY REFERENCES Passports(PassportID) UNIQUE
)

INSERT INTO Passports(PassportNumber)
	VALUES
		('N34FG21B'),
		('K65LO4R7'),
		('ZE657QP2')

INSERT INTO Persons(FirstName, Salary, PassportID)
	VALUES
		('Roberto', 43300.00, 102),
		('Tom', 56100.00, 103),
		('Yana', 60200.00, 101)

--------------------------------------------
-- Problem 2. One-To-Many Relationship

CREATE TABLE Manufacturers(
	ManufacturerID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	EstablishedOn DATE NOT NULL
)

CREATE TABLE Models(
	ModelID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] VARCHAR(30) NOT NULL,
	ManufacturerID INT NOT NULL FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers([Name], EstablishedOn)
	VALUES
		('BMW', '03/07/1916'),
		('Tesla', '01/01/2003'),
		('Lada', '05/01/1966')

INSERT INTO Models([Name], ManufacturerID)
	VALUES
		('X1', 1),
		('i6', 1),
		('Model S', 2),
		('Model X', 2),
		('Model 3', 2),
		('Nova', 3)

------------------------------------------
-- Problem 3. Many-To-Many Relationship

CREATE TABLE Students(
	StudentID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE Exams(
	ExamID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE StudentsExams(
	StudentID INT NOT NULL FOREIGN KEY REFERENCES Students(StudentID),
	ExamID INT NOT NULL FOREIGN KEY REFERENCES Exams(ExamID),
	PRIMARY KEY(StudentID, ExamID)  -------- Composite Primary Key
)

INSERT INTO Students([Name])
	VALUES
		('Mila'),
		('Toni'),
		('Ron')

INSERT INTO Exams([Name])
	VALUES
		('SpringMVC'),
		('Neo4j'),
		('Oracle 11g')

INSERT INTO StudentsExams(StudentID, ExamID)
	VALUES
		(1, 101),
		(1, 102),
		(2, 101),
		(3, 103),
		(2, 102),
		(2, 103)

SELECT s.[Name], e.[Name]
	FROM StudentsExams AS se
	JOIN Students AS s ON se.StudentID = s.StudentID
	JOIN Exams AS e ON se.ExamID = e.ExamID

-------------------------------------------
-- Problem 4. Self-Referencing 

CREATE TABLE Teachers(
	TeacherID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] VARCHAR(30) NOT NULL,
	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers([Name], ManagerID)
	VALUES
		('John', NULL),
		('Maya', 106),
		('Silvia', 106),
		('Ted', 105),
		('Mark', 101),
		('Greta', 101)

----------------------------------------
-- Problem 5. Online Store Database

CREATE DATABASE OnlineStore

USE OnlineStore

CREATE TABLE Cities(
	CityID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Customers(
	CustomerID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Birthday DATE NOT NULL,
	CityID INT NOT NULL FOREIGN KEY REFERENCES Cities(CityID)
)

CREATE TABLE Orders(
	OrderID INT PRIMARY KEY IDENTITY,
	CustomerID INT NOT NULL FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE ItemTypes(
	ItemTypeID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Items(
	ItemID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	ItemTypeID INT NOT NULL FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems(
	OrderID INT NOT NULL FOREIGN KEY REFERENCES Orders(OrderID),
	ItemID INT NOT NULL FOREIGN KEY REFERENCES Items(ItemID),
	PRIMARY KEY(OrderID, ItemID)
)

----------------------------------------
-- Problem 6. University Database

CREATE DATABASE University

USE [University]

CREATE TABLE Majors(
	MajorID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Students(
	StudentID INT PRIMARY KEY IDENTITY,
	StudentNumber CHAR(10) NOT NULL,
	StudentName VARCHAR(50) NOT NULL,
	MajorID INT NOT NULL FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE Payments(
	PaymentID INT PRIMARY KEY IDENTITY,
	PaymentDate DATE NOT NULL,
	PaymentAmount DECIMAL(7,2) NOT NULL,
	StudentID INT NOT NULL FOREIGN KEY REFERENCES Students(StudentID)
)

CREATE TABLE Subjects(
	SubjectID INT PRIMARY KEY IDENTITY,
	SubjectName VARCHAR(50) NOT NULL
)

CREATE TABLE Agenda(
	StudentID INT NOT NULL FOREIGN KEY REFERENCES Students(StudentID),
	SubjectID INT NOT NULL FOREIGN KEY REFERENCES Subjects(SubjectID),
	PRIMARY KEY(StudentID, SubjectID)
)

-----------------------------------------
-- Problem 7. SoftUni Design

-----------------------------------------
-- Problem 8. Geography Design

----------------------------------------
-- Problem 9. *Peaks in Rila

USE [Geography]

SELECT m.MountainRange, p.PeakName, p.Elevation
	FROM Mountains AS m
	JOIN Peaks AS p ON m.Id = p.MountainId
	WHERE m.MountainRange = 'Rila'
	ORDER BY p.Elevation DESC