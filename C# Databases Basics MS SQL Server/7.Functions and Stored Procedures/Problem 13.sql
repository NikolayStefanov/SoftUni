--EXERCISE 13

CREATE FUNCTION ufn_CashInUsersGames (@GameName VARCHAR(30))
RETURNS @output TABLE(SumCash DECIMAL(18,2))
AS
BEGIN 
	INSERT INTO @output SELECT (
	SELECT SUM(Cash) AS [SumCash] FROM (SELECT *, ROW_NUMBER() OVER(ORDER BY Cash DESC) AS [RowNumber] FROM UsersGames
	WHERE GameId IN (
					SELECT Id 
					FROM Games
					WHERE [Name] = @GameName
 					)) AS [RowNumTable]
					WHERE RowNumber % 2 != 0
						)
	RETURN;
END

SELECT * FROM DBO.ufn_CashInUsersGames('Saponaria')

