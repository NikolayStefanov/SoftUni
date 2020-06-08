--EXERCISE 1
SELECT COUNT(*) AS [Count]
FROM WizzardDeposits

--EXERCISE 2
SELECT MAX(MagicWandSize) AS [LongestMagicWand] FROM WizzardDeposits

--EXERCISE 3
SELECT DepositGroup, MAX(MagicWandSize) AS [LongestMagicWand] FROM WizzardDeposits
GROUP BY DepositGroup

--EXERCISE 4
SELECT r.DepositGroup
FROM (SELECT TOP(2) DepositGroup, DENSE_RANK() OVER(ORDER BY AVG(MagicWandSize))AS [Rank] FROM WizzardDeposits  GROUP BY DepositGroup) AS r
WHERE [Rank] = 1

--EXERCISE 5
SELECT DepositGroup, SUM(DepositAmount) AS [TotalSum] FROM WizzardDeposits
GROUP BY DepositGroup

--EXERCISE 6
SELECT DepositGroup, SUM(DepositAmount) AS [TotalSum] FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

--EXERCISE 7
SELECT DepositGroup, SUM(DepositAmount) AS [TotalSum] FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

--EXERCISE 8
SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS MinDepositCharge FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator,DepositGroup 

--EXERCISE 9
SELECT AgeGroup, COUNT(Age) AS [WizardCount] FROM (SELECT Age,
CASE
WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
WHEN Age BETWEEN 11  AND 20 THEN '[11-20]'
WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
WHEN AGE BETWEEN 31 AND 40 THEN '[31-40]'
WHEN AGE BETWEEN 41 AND 50 THEN '[41-50]'
WHEN AGE BETWEEN 51 AND 60 THEN '[51-60]'
ELSE '[61+]'
END AS [AgeGroup]
FROM WizzardDeposits) AS a
GROUP BY AgeGroup

--EXERCISE 10
SELECT * 
FROM (SELECT LEFT(FirstName, 1) AS FirstLetter 
	FROM WizzardDeposits 
	WHERE DepositGroup = 'Troll Chest') AS f 
GROUP BY f.FirstLetter

--EXERCISE 11
SELECT f.DepositGroup, f.IsDepositExpired, AVG(f.DepositInterest) AS  [AverageInterest] 
	FROM  (SELECT DepositGroup, IsDepositExpired, DepositInterest 
		   FROM WizzardDeposits 
		   WHERE DepositStartDate > '1985-01-01') AS f
	GROUP BY DepositGroup, IsDepositExpired
	ORDER BY DepositGroup DESC, IsDepositExpired

--EXERCISE 12

