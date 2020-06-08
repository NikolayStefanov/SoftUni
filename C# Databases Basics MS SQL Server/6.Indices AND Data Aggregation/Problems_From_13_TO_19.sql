--EXERCISE 13
SELECT DepartmentID, SUM(Salary) AS [TotalSalary]
FROM Employees
GROUP BY DepartmentID

--EXERCISE 14
SELECT f.DepartmentID, MIN(f.Salary) AS [MinimumSalary]
FROM  (SELECT DepartmentID, Salary 
	   FROM Employees 
	   WHERE HireDate > '2000-01-01' AND DepartmentID IN (2,5,7)) AS f 
GROUP BY f.DepartmentID

--EXERCISE 15
SELECT *  INTO temp_table FROM Employees WHERE Salary > 30000 

DELETE  FROM temp_table WHERE ManagerID = 42

UPDATE temp_table
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS AverageSalary FROM temp_table GROUP BY DepartmentID

--EXERCISE 16
SELECT DepartmentID, MAX(Salary) AS MaxSalary 
FROM Employees 
GROUP BY DepartmentID 
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--EXERCISE 17
SELECT COUNT(*) AS [Count] FROM Employees WHERE ManagerID IS NULL

--EXERCISE 18

--EXERCISE 19