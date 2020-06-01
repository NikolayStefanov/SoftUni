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
WHERE DepartmentID IN(3, 10) AND HireDate BETWEEN '1995-01-01' AND '2006-01-01'

--EXERCISE 4
SELECT FirstName, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'