CREATE DATABASE SoftUni

--? Towns (Id, Name)
CREATE TABLE Towns(
Id INT NOT NULL PRIMARY KEY IDENTITY,
Name NVARCHAR(30) NOT NULL
)

INSERT INTO Towns(Name)
VALUES('Sofia'),
	  ('Plovdiv'),
	  ('Varna'),
	  ('Burgas')

--? Addresses (Id, AddressText, TownId)
CREATE TABLE Addresses(
Id INT NOT NULL PRIMARY KEY IDENTITY,
AddressText NVARCHAR(50) NOT NULL,
TownId INT NOT NULL FOREIGN KEY REFERENCES Towns(Id)
)

--? Departments (Id, Name)
CREATE TABLE Departments(
Id INT NOT NULL PRIMARY KEY IDENTITY,
Name NVARCHAR(30) NOT NULL
)

INSERT INTO Departments(Name)
VALUES('Engineering'),
	  ('Sales'),
	  ('Marketing'),
	  ('Software Development'),
	  ('Quality Assurance')


--? Employees (Id, FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)
CREATE TABLE Employees(
Id INT NOT NULL PRIMARY KEY IDENTITY,
FirstName NVARCHAR(25) NOT NULL,
MiddleName NVARCHAR(25),
LastName NVARCHAR(25) NOT NULL,
JobTitle NVARCHAR(25) NOT NULL,
DepartmentId INT NOT NULL REFERENCES Departments(Id),
HireDate DATE NOT NULL,
Salary DECIMAL(15,3) NOT NULL,
AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES('Ivan','Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00),
	  ('Petar','Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00),
	  ('Maria','Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25),
	  ('Georgi','Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00),
	  ('Peter','Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88)


SELECT Name FROM Towns ORDER BY Name
SELECT Name FROM Departments ORDER BY Name
SELECT FirstName, LastName, JobTitle, Salary FROM Employees ORDER BY Salary DESC

UPDATE Employees
SET Salary *= 1.1

SELECT Salary FROM Employees

