--EXERCISE 1
SELECT FirstName, LastName 
FROM Employees 
WHERE  LEFT(FirstName, 2) = 'Sa'

--EXERCISE 2
SELECT FirstName, LastName 
FROM Employees 
WHERE  LastName LIKE '%ei%'

--EXERCISE 3
SELECT FirstName
FROM Employees
WHERE DepartmentID IN(3, 10) AND YEAR(HireDate) BETWEEN 1995 AND 2005

--EXERCISE 4
SELECT FirstName, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

--EXERCISE 5
SELECT [Name] 
FROM Towns
WHERE LEN([Name]) IN (5,6)
ORDER BY [Name] 

--EXERCISE 6
SELECT * 
FROM Towns
WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
ORDER BY [Name]

--EXERCISE 7
SELECT * 
FROM Towns
WHERE LEFT([Name], 1) NOT IN ('R', 'B', 'D')
ORDER BY [Name]

--EXERCISE 8
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName 
FROM Employees
WHERE YEAR(HireDate) > 2000

--EXERCISE 9
SELECT FirstName, LastName 
FROM Employees
WHERE LEN(LastName) = 5

--EXERCISE 10
SELECT EmployeeID, FirstName, LastName, Salary  
    ,DENSE_RANK() OVER   
    (PARTITION BY Salary ORDER BY EmployeeID) AS Rank  
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000
	ORDER BY Salary DESC

--EXERCISE 11
SELECT *
FROM (SELECT EmployeeID, FirstName, LastName, Salary  
    ,DENSE_RANK() OVER   
    (PARTITION BY Salary ORDER BY EmployeeID) AS Rank  
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000) r
WHERE Rank = 2
ORDER BY Salary DESC

