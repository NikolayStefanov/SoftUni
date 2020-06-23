--EXERCISE 9
CREATE PROC usp_GetHoldersFullName 
AS 
	SELECT (FirstName+' '+ LastName) AS [Full Name] FROM AccountHolders
GO
--EXERCISE 10
CREATE PROC usp_GetHoldersWithBalanceHigherThan @Number DECIMAL(18,4)
AS
	SELECT ah.FirstName, ah.LastName FROM AccountHolders AS ah
	JOIN Accounts AS a ON ah.Id = a.AccountHolderId
	GROUP BY a.AccountHolderId, ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @Number
	ORDER BY FirstName, LastName

EXEC usp_GetHoldersWithBalanceHigherThan @Number = 500000
GO

--EXERCISE 11
CREATE FUNCTION ufn_CalculateFutureValue (@Sum DECIMAL(18,4), @YearlyInterestRate FLOAT, @Years INT)
RETURNS DECIMAL(18,4)
AS 
BEGIN 
	DECLARE @result DECIMAL(18,4) = @Sum * (POWER(1+ @YearlyInterestRate, @Years))
	RETURN @result
END
GO
SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)
GO
--EXERCISE 12
CREATE PROC usp_CalculateFutureValueForAccount @AccountId INT, @InterestRate FLOAT
AS 
BEGIN
	SELECT a.Id AS [Account Id],
		   ah.FirstName AS [First Name],
		   ah.LastName AS [Last Name],
		   a.Balance AS [Current Balance],
		   dbo.ufn_CalculateFutureValue(a.Balance, @InterestRate, 5) AS [Balance in 5 years]
	FROM AccountHolders AS ah
	JOIN Accounts AS a ON ah.Id = a.AccountHolderId
	WHERE a.Id = @AccountId 
END

EXEC usp_CalculateFutureValueForAccount 2, 0.5