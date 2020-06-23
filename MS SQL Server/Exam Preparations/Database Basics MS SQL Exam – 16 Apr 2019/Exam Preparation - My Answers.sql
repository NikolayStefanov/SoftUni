CREATE DATABASE Airport
USE Airport

--EXERCISE 1
CREATE TABLE Planes(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(30) NOT NULL,
Seats INT NOT NULL,
[Range] INT NOT NULL
) 

CREATE TABLE Flights(
Id INT PRIMARY KEY IDENTITY NOT NULL,
DepartureTime DATETIME2 ,
ArrivalTime DATETIME2,
Origin VARCHAR(50) NOT NULL,
Destination VARCHAR(50) NOT NULL,
PlaneId INT FOREIGN KEY REFERENCES Planes(Id) NOT NULL
) 
CREATE TABLE Passengers (
Id INT PRIMARY KEY IDENTITY NOT NULL,
FirstName VARCHAR(30) NOT NULL,
LastName VARCHAR(30) NOT NULL,
Age INT NOT NULL,
[Address] VARCHAR(30) NOT NULL,
PassportId CHAR(11)  NOT NULL
) 
CREATE TABLE LuggageTypes (
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Type] NVARCHAR(30) NOT NULL
) 
CREATE TABLE Luggages (
Id INT PRIMARY KEY IDENTITY NOT NULL,
LuggageTypeId INT FOREIGN KEY REFERENCES LuggageTypes(Id) NOT NULL,
PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
) 
CREATE TABLE Tickets (
Id INT PRIMARY KEY IDENTITY NOT NULL,
PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
FlightId INT FOREIGN KEY REFERENCES Flights(Id) NOT NULL,
LuggageId INT FOREIGN KEY REFERENCES Luggages(Id) NOT NULL,
Price DECIMAL(15,2) NOT NULL
) 

--EXERCISE 2
INSERT INTO Planes
VALUES('Airbus 336',112,5132),
	  ('Airbus 330', 432, 5325),
	  ('Boeing 369', 231, 2355),
	  ('Stelt 297',254, 2143),
	  ('Boeing 338',165,5111),
	  ('Airbus 558', 387, 1342),
	  ('Boeing 128', 345, 5541)

INSERT INTO LuggageTypes
VALUES('Crossbody Bag'),
	  ('School Backpack'),
	  ('Shoulder Bag')


--EXERCISE 3

UPDATE Tickets
SET Price *= 1.13
WHERE FlightId IN (SELECT TOP(1) FlightId FROM Flights WHERE Destination = 'Carlsbad')

--EXERCISE 4
DELETE FROM Tickets WHERE (SELECT Destination FROM Flights WHERE Destination = 'Ayn Halagim') IN ('Ayn Halagim')
DELETE FROM Flights WHERE Destination ='Ayn Halagim'

--EXERCISE 5
SELECT * 
FROM Planes 
WHERE [Name] LIKE '%tr%' 
ORDER BY Id, [Name], Seats, [Range]

--EXERCISE 6
SELECT FlightId,SUM(Price) AS [Price] 
FROM Tickets 
GROUP BY FlightId 
ORDER BY SUM(Price) DESC, FlightId

--EXERCISE 7
SELECT (p.FirstName +' '+ p.LastName) AS [Full Name], f.Origin, f.Destination
FROM Passengers AS p
JOIN Tickets AS t ON p.Id=t.PassengerId
JOIN Flights AS f ON t.FlightId = f.Id
ORDER BY [Full Name], Origin, Destination

--EXERCISE 8
SELECT FirstName AS [First Name], LastName AS [Last Name], Age 
FROM Passengers 
WHERE Id NOT IN (SELECT PassengerId FROM Tickets) 
ORDER BY Age DESC, FirstName, LastName

--EXERCISE 9
SELECT (p.FirstName+ ' '+ p.LastName) AS [Full Name],
	   pl.[Name] AS  [Plane Name],
	   (f.Origin + ' - ' + f.Destination) AS [Trip],
	   lt.[Type] AS [Luggage Type]
FROM Passengers AS p 
JOIN Tickets AS t ON p.Id = t.PassengerId
JOIN Flights AS f ON t.FlightId = f.Id
JOIN Planes AS pl ON f.PlaneId = pl.Id
JOIN Luggages AS l ON t.LuggageId = l.Id
JOIN LuggageTypes AS lt ON l.LuggageTypeId = lt.Id
ORDER BY [Full Name], [Plane Name], f.Origin, f.Destination, [Luggage Type]

--EXERCISE 10
SELECT p.Name, p.Seats, COUNT(t.PassengerId) AS [Passenger Count] FROM Planes AS p
LEFT JOIN Flights AS f ON p.Id = f.PlaneId
LEFT JOIN Tickets AS t ON f.Id = t.FlightId
LEFT JOIN Passengers AS pass ON t.PassengerId = pass.Id
GROUP BY p.Name, p.Seats
ORDER BY [Passenger Count] DESC, p.Name, p.Seats

--EXERCISE 11
CREATE FUNCTION udf_CalculateTickets(@origin NVARCHAR(30), @destination NVARCHAR(30), @peopleCount INT )
RETURNS NVARCHAR(MAX)
AS 
BEGIN
	DECLARE @invalidCountMessage NVARCHAR(21) = 'Invalid people count!';
	DECLARE @invalidFlightMessage NVARCHAR(21) = 'Invalid flight!';
	IF(@peopleCount <= 0)
	BEGIN;
	RETURN @invalidCountMessage;
	END
	
	IF (NOT EXISTS(SELECT * FROM Flights WHERE Origin = @origin AND Destination = @destination))
	BEGIN;
	RETURN @invalidFlightMessage;
	END

	DECLARE  @targetFlightId INT = (SELECT Id FROM Flights WHERE Origin = @origin AND Destination = @destination);
	DECLARE @flightPrice DECIMAL(15,2) = (SELECT Price FROM Tickets WHERE FlightId = @targetFlightId) * @peopleCount

	RETURN CONCAT('Total price', ' ',@flightPrice)
END
SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)
--OUTPUT - 'Total price 2419.89'
SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', -1)
--OUTPUT - 'Invalid people count!'
SELECT dbo.udf_CalculateTickets('Invalid','Rancabolang', 33)
--OUTPUT - 'Invalid flight!'

--EXERCISE 12
CREATE PROC usp_CancelFlights
AS
	UPDATE Flights
	SET DepartureTime = NULL, ArrivalTime = NULL
	WHERE DepartureTime < ArrivalTime  

	EXEC usp_CancelFlights
	SELECT * FROM Flights