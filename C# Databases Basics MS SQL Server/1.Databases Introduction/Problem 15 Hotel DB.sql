CREATE DATABASE Hotel

--Employees (Id, FirstName, LastName, Title, Notes)
CREATE TABLE Employees(
Id INT NOT NULL PRIMARY KEY IDENTITY,
FirstName NVARCHAR(25) NOT NULL,
LastName NVARCHAR(25) NOT NULL,
Title NVARCHAR(15),
Notes NTEXT
)

INSERT INTO Employees(FirstName,LastName,Title,Notes)
VALUES('NIKOLAY', 'STEFANOV', 'PROGRAMMER', 'I WILL BE THE BEST'),
	  ('PAOLINKA', 'STEFANOVA', NULL, NULL),
	  ('PLAMEN', 'STEFANOV', 'FOREIGNER', NULL)


--? Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber,Notes)
CREATE TABLE Customers(
AccountNumber INT UNIQUE NOT NULL,
FirstName NVARCHAR(25) NOT NULL,
LastName NVARCHAR(25) NOT NULL,
PhoneNumber BIGINT ,
EmergencyName NVARCHAR(30) NOT NULL,
EmergencyNumber BIGINT NOT NULL,
Notest NTEXT
)

INSERT INTO Customers
VALUES(100, 'NIKOLAY', 'STEFANOV', 0876757337, 'SUPERMAN', 12345, 'IM THE BEST'),
	  (101, 'PLAMEN', 'STEFANOV', 0983424423, 'SPIDERMAN', 12345, NULL),
	  (131, 'STEFAN', 'STEFANOV', 0881234567, 'POLICE', 911, 'HERE IS POLICE OFFICER')

--? RoomStatus (RoomStatus, Notes)
CREATE TABLE RoomStatus(
RoomStatus NVARCHAR(30) NOT NULL UNIQUE,
Notest NTEXT
)

INSERT INTO RoomStatus
VALUES('ZAETA', 'V MOMENTA IMA HORA V TAQ STAQ'),
	  ('NAETA', 'V MOMENTA SE SNIMA FILM TUKA'),
	  ('SVOBODNA', NULL)


--? RoomTypes (RoomType, Notes)
CREATE TABLE RoomTypes(
RoomType NVARCHAR(30) NOT NULL UNIQUE,
Notest NTEXT
)
INSERT INTO RoomTypes
VALUES('APARTMENT', '4 ROOMS, 2 BATHROOMS, 1 KITCHEN, BIG BALCON'),
	  ('MOTEL', '1 ROOM AND 1 BATHROOM FOR LOVERS'),
	  ('MAZE', NULL)

--? BedTypes (BedType, Notes)
CREATE TABLE BedTypes(
BedType NVARCHAR(30) NOT NULL UNIQUE,
Notest NTEXT
)
INSERT INTO BedTypes
VALUES('KING BED', 'THE BIGGEST BED IN THE WORLD'),
	  ('NORMAL BED', 'NORMAL BED FOR 2 PEOPLE'),
	  ('DUSHEK', 'SAMO EDIN DIUSHEK E TVA')

--? Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
CREATE TABLE Rooms(
RoomNumber INT NOT NULL UNIQUE,
RoomType NVARCHAR(30) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL,
BedType NVARCHAR(30) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL,
Rate INT CHECK (Rate >= 0 AND Rate <= 10),
RoomStatus NVARCHAR(30) FOREIGN KEY REFERENCES RoomStatus(RoomStatus)NOT NULL,
Notes NTEXT
)

INSERT INTO Rooms
VALUES(500, 'APARTMENT', 'KING BED', 10, 'SVOBODNA', 'THE BEST ROOM EVER'),
	  (501, 'MOTEL', 'NORMAL BED', 7, 'ZAETA', 'GOOD FOR LOVERS'),
	  (502, 'MAZE', 'DUSHEK', 1, 'SVOBODNA', 'NAI GADNATA STAQ EVER')

--? Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
CREATE TABLE Payments(
Id INT PRIMARY KEY IDENTITY NOT NULL,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
PaymentDate DATETIME2(2) NOT NULL,
AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
FirstDateOccupied DATE NOT NULL,
LastDateOccupied DATE NOT NULL,
TotalDays AS DATEDIFF(day, FirstDateOccupied, LastDateOccupied) PERSISTED,
AmountCharged DECIMAL (10, 3) NOT NULL,
TaxRate DECIMAL(18, 4) CHECK(TaxRate >= 0.01 AND TaxRate <= 1.000),
TaxAmount AS (AmountCharged*TaxRate) PERSISTED NOT NULL,
PaymentTotal AS (AmountCharged + AmountCharged*TaxRate) PERSISTED NOT NULL,
Notes NTEXT
)

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, AmountCharged, TaxRate, Notes)
VALUES(1, '2020-05-19 20:20:20.20', 100, '2020-03-17', '2020-03-28', 888.88, 0.25, 'NQMAM ZABELEJKI'),
	  (2, '2010-03-17 10:20:45.2423', 101, '2010-03-18', '2015-11-07', 100002.943, 0.07, 'NQMAM ZABELEJKI'),
	  (3, '2016-01-01 00:01:00.00', 131, '2016-01-02', '2016-02-28', 2434.88, 1, 'NQMAM ZABELEJKI')

--? Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
CREATE TABLE Occupancies(
Id INT PRIMARY KEY IDENTITY NOT NULL,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
DateOccupied DATE NOT NULL,
AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber) NOT NULL,
RateApplied INT NOT NULL,
PhoneCharge BIT NOT NULL,
Notes NTEXT
)

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
VALUES(1, '2020-03-17', 100, 500, 10, 0, NULL),
	  (2, '2010-03-18', 131, 501, 8, 1, NULL),
	  (3, '2016-01-02', 101, 502, 5, 1, NULL)

UPDATE Payments
SET TaxRate -= 0.03

SELECT TaxRate FROM Payments
DELETE FROM Occupancies