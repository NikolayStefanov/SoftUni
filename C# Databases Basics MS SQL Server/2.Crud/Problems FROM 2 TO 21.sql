--EXERCISE 2
SELECT * FROM Departments

--EXERCISE 3
SELECT Name FROM Departments

--EXERCISE 4
SELECT FirstName, LastName, Salary FROM Employees

--EXERCISE 5
SELECT FirstName, MiddleName, LastName FROM Employees

--EXERCISE 6
SELECT CONCAT(FirstName, '.', LastName, '@', 'softuni.bg') AS [Full Email Address] FROM Employees

--EXERCISE 7
SELECT DISTINCT Salary FROM Employees

--EXERCISE 8
SELECT * 
FROM Employees
WHERE JobTitle = 'Sales Representative'

--EXERCISE 9
SELECT FirstName, LastName, JobTitle
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000

--EXERCISE 10
SELECT (FirstName+ ' '+ MiddleName + ' ' + LastName) AS [Full Name]
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600) AND MiddleName IS NOT NULL

--EXERCISE 11
SELECT FirstName, LastName 
FROM Employees
WHERE ManagerID IS NULL

--EXERCISE 12
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

--EXERCISE 13
SELECT TOP(5) FirstName, LastName 
FROM Employees
ORDER BY Salary DESC

--EXERCISE 14
SELECT FirstName, LastName 
FROM Employees
WHERE DepartmentID != 4

--EXERCISE 15
SELECT * 
FROM Employees 
ORDER BY Salary DESC, FirstName, LastName DESC, MiddleName

--EXERCISE 16
CREATE VIEW V_EmployeesSalaries AS
SELECT FirstName, LastName, Salary
FROM Employees


--EXERCISE 17
CREATE VIEW V_EmployeeNameJobTitle AS
SELECT (FirstName + ' ' + (ISNULL(MiddleName, '')) + ' '+ LastName) AS [Full Name], JobTitle
FROM Employees

--EXERCISE 18
SELECT DISTINCT JobTitle FROM Employees

--EXERCISE 19
SELECT TOP(10) * 
FROM Projects
ORDER BY StartDate, [Name] 

--EXERCISE 20
SELECT TOP(7) FirstName, LastName, HireDate 
FROM Employees
ORDER BY HireDate DESC

--EXERCISE 21
UPDATE Employees
SET Salary += Salary * 0.12
WHERE DepartmentID IN (1,2,4,11)

SELECT Salary FROM Employees WHERE DepartmentID IN (1,2,4,11)

