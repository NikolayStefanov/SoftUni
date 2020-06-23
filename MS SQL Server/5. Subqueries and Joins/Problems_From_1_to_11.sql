--EXERCISE 1
SELECT TOP(5) e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText
FROM Employees AS e
JOIN Addresses AS a
ON e.AddressID = a.AddressID
ORDER BY AddressID

--EXERCISE 2
SELECT TOP(50) e.FirstName, e.LastName,t.Name, a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY FirstName, LastName

--EXERCISE 3
SELECT e.EmployeeID, e.FirstName, e.LastName, d.[Name]
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY EmployeeID

--EXERCISE 4
SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.[Name]
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY d.DepartmentID

--EXERCISE 5
SELECT TOP(3) e.EmployeeID, e.FirstName
FROM Employees AS e
WHERE e.EmployeeID NOT IN  (SELECT DISTINCT EmployeeID FROM EmployeesProjects)
ORDER BY e.EmployeeID

--EXERCISE 6
SELECT e.FirstName, e.LastName, e.HireDate,  d.[Name] AS [DeptName]
FROM Employees AS e 
JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
WHERE e.HireDate > '1999-01-01' AND d.[Name] IN ('Sales', 'Finance')
ORDER BY e.HireDate

--EXERCISE 7
SELECT TOP(5) e.EmployeeID ,e.FirstName, p.[Name] AS ProjectName 
FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

--EXERCISE 8
SELECT e.EmployeeID ,e.FirstName, 
CASE 
WHEN YEAR(p.StartDate) >= 2005 THEN NULL
ELSE p.[Name]
END AS [ProjectName]
FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24
ORDER BY e.EmployeeID

--EXERCISE 9
SELECT e.EmployeeID, e.FirstName, e.ManagerID, m.FirstName AS [ManagerName]
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID IN (3, 7)
ORDER BY e.EmployeeID

--EXERCISE 10
SELECT TOP(50) e.EmployeeID, (e.FirstName+' '+ e.LastName) AS [EmployeeName] , (m.FirstName+' '+ m.LastName) AS [ManagerName], d.[Name] AS [DepartmentName] 
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

--EXERCISE 11
SELECT TOP(1) AVG(e.Salary) AS [MinAverageSalary]
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
GROUP BY d.[Name]
ORDER BY AVG(e.Salary)



