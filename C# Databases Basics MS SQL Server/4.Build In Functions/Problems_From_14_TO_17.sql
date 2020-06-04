--EXERCISE 14
SELECT TOP(50) [Name],  FORMAT([Start], 'yyyy-MM-dd') AS [Start]
FROM Games
WHERE YEAR([Start]) IN (2011,2012)
ORDER BY [Start], [Name]

--EXERCISE 15
SELECT Username, SUBSTRING(Email, CHARINDEX('@', Email)+1, LEN(Email)) AS [Email Provider] 
FROM Users
ORDER BY [Email Provider], Username

--EXERCISE 16
SELECT Username, IpAddress AS [IP Address] 
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

--EXERCISE 17
SELECT [Name] AS Game, 
CASE
	WHEN DATEPART(HOUR, Start) >= 0 AND DATEPART(HOUR, Start) < 12 THEN 'Morning'
	WHEN DATEPART(HOUR, Start) >= 12 AND DATEPART(HOUR, Start) < 18 THEN 'Afternoon'
	ELSE 'Evening'
END AS [Part of the Day]
, 
CASE
	WHEN Duration <= 3 THEN 'Extra Short'
	WHEN Duration <= 6 THEN 'Short'
	WHEN Duration > 6 THEN 'Long'
	ELSE 'Extra Long'
END AS Duration
FROM Games
ORDER BY [Name],Duration, [Part of the Day]