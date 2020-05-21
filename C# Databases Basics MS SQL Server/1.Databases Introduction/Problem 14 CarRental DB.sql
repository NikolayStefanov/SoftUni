CREATE DATABASE CarRental

--Categories (Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY NOT NULL,
CategoryName NVARCHAR(25) NOT NULL,
DailyRate INT CHECK(DailyRate>= 0 AND DailyRate <= 10) ,
WeeklyRate INT CHECK(WeeklyRate>= 0 AND WeeklyRate <= 10) ,
MonthlyRate INT CHECK(MonthlyRate>= 0 AND MonthlyRate <= 10) ,
WeekendRate INT CHECK(WeekendRate>= 0 AND WeekendRate <= 10) 
)

INSERT INTO Categories(CategoryName,DailyRate,WeeklyRate,MonthlyRate,WeekendRate)
VALUES('FIRST CATEGORY', 5,6,7,8),
	  ('SECOND CATEGORY', 1,2,3,4),
	  ('THIRD CATEGORY', 4,6,7,5)

-- Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
CREATE TABLE Cars(
Id INT PRIMARY KEY IDENTITY NOT NULL,
PlateName NVARCHAR(25) NOT NULL,
Manufacturer NVARCHAR(30) NOT NULL,
Model NVARCHAR(20) NOT NULL,
CarYear DATE NOT NULL,
CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
Doors INT CHECK (Doors = 3 OR Doors = 5) NOT NULL,
Picture VARBINARY(MAX),
Condition NVARCHAR(50) NOT NULL,
Available BIT NOT NULL
)

INSERT INTO Cars(PlateName,Manufacturer,Model,CarYear,CategoryId,Doors,Picture,Condition,Available)
VALUES('MONGO', 'MERTSEDES', 'AMG', '2019-03-17', 1, 5, NULL, 'PERFECT', 1),
	  ('BONGO', 'FIAT', 'STILO', '2003-05-12', 2, 3, NULL, 'GORE DOLE', 1),
	  ('DONGO', 'KIA', 'SPORTAGE', '2015-08-13', 3, 5, NULL, 'CELOTO V RAJDA BATE', 1)


-- Employees (Id, FirstName, LastName, Title, Notes)
CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY NOT NULL,
FirstName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20) NOT NULL,
Title NVARCHAR(15),
Notes NTEXT
)

INSERT INTO Employees(FirstName, LastName, Title, Notes)
VALUES('NIKOLAY', 'STEFANOV', 'TSAR', 'NIKVI NOTES NEMA DA KAJA'),
	  ('POLI', 'GEORGIEVA', 'SIR', NULL),
	  ('STEFAN', 'STEFANOV', NULL, NULL)

-- Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
CREATE TABLE Customers(
Id INT PRIMARY KEY IDENTITY NOT NULL,
DriverLicenceNumber INT NOT NULL,
FullName NVARCHAR(50) NOT NULL,
Address NVARCHAR(50) NOT NULL,
City NVARCHAR(25) NOT NULL,
ZIPCode INT NOT NULL,
Notes NTEXT
)

INSERT INTO  Customers(DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
VALUES(101, 'Nikolay Stefanov', 'PETKO VOIVODA 23', 'QMBOL', 133, NULL),
	  (102, 'Paolina Georgieva', 'SHIPKA 33', 'SMOLYAN', 144, NULL),
	  (193, 'Daniel Kotsev', 'SVOBODA 23', 'TRUDOVEC', 155, NULL)

-- RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd,
-- TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
CREATE TABLE RentalOrders(
Id INT PRIMARY KEY IDENTITY NOT NULL,
EmployeeId INT NOT NULL FOREIGN KEY REFERENCES Employees(Id),
CustomerId INT NOT NULL FOREIGN KEY REFERENCES Customers(Id),
CarId INT NOT NULL FOREIGN KEY REFERENCES Cars(Id),
TankLevel DECIMAL(10, 4) NOT NULL CHECK (TankLevel >= 0 AND TankLevel <=100),
KilometrageStart INT NOT NULL,
KilometrageEnd INT NOT NULL,
TotalKilometrage AS (KilometrageEnd-KilometrageStart) PERSISTED,
StartDate DATETIME2(3) NOT NULL,
EndDate DATETIME2(3)NOT NULL,
TotalDays AS (DATEDIFF(day, StartDate, EndDate)) PERSISTED,
RateApplied INT NOT NULL,
TaxRate INT NOT NULL,
OrderStatus BIT NOT NULL,
Notes NTEXT
)

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, StartDate, EndDate, RateApplied,TaxRate, OrderStatus,Notes)
VALUES(2, 1,2, 55.55, 10000, 15000, '2020-03-17 09:12:58.924', '2020-04-01 23:23:58.99223', 10, 10, 1, NULL),
	  (1, 2,1, 63.55, 15000, 23456, '2019-12-17 16:12:58.924', '2020-04-01 06:23:58.99223', 10, 10, 0, NULL),
	  (3, 3,3, 99.55, 10000, 34323, '2020-01-17 09:12:58.924', '2020-05-19 23:19:58.99223', 10, 10, 1, NULL)