--EXERCISE 12
SELECT CountryName AS [Country Name], IsoCode AS [ISO Code] 
FROM Countries
WHERE LEN(CountryName)-LEN(REPLACE(CountryName, 'A', '')) >=3
ORDER BY IsoCode
--EXERCISE 13
SELECT PeakName, RiverName, LOWER(PeakName + SUBSTRING(RiverName, 2, LEN(RiverName) -1)) AS Mix 
FROM Peaks, Rivers
WHERE RIGHT (PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix
