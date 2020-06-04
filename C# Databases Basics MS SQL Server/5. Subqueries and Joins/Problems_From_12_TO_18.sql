--EXERCISE 12
SELECT mc.CountryCode ,m.MountainRange ,p.PeakName, p.Elevation
FROM Peaks AS p
JOIN Mountains AS m ON p.MountainId = m.Id
JOIN MountainsCountries AS mc ON mc.MountainId = m.Id
WHERE mc.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--EXERCISE 13
SELECT mc.CountryCode, COUNT(m.MountainRange) FROM Mountains AS m 
JOIN MountainsCountries AS mc ON mc.MountainId = m.Id
WHERE mc.CountryCode IN ('BG', 'RU', 'US')
GROUP BY mc.CountryCode

--EXERCISE 14
SELECT TOP(5) c.CountryName, r.RiverName
FROM (SELECT TOP(5) CountryName, CountryCode FROM Countries WHERE ContinentCode ='AF' ORDER BY CountryName) AS c
LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r ON  cr.RiverId = r.Id

--EXERCISE 15
SELECT k.ContinentCode, k.CurrencyCode, k.CurrencyUsage 
FROM (SELECT  c.ContinentCode, 
			  c.CurrencyCode,
			  COUNT(c.CurrencyCode) AS [CurrencyUsage],
			  DENSE_RANK() OVER(PARTITION BY c.ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS CurrencyRank
		FROM Countries AS c
		GROUP BY c.ContinentCode, c.CurrencyCode
		HAVING COUNT(c.CurrencyCode) > 1) AS k
WHERE k.CurrencyRank = 1
ORDER BY k.ContinentCode



