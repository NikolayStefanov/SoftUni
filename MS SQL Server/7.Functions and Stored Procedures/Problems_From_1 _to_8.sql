--EXERCISE 1
CREATE PROC usp_GetEmployeesSalaryAbove35000  
AS 
	SELECT FirstName, LastName 
	FROM Employees 
	WHERE Salary > 35000 

EXEC usp_GetEmployeesSalaryAbove35000
GO

--EXERCISE 2
CREATE PROC usp_GetEmployeesSalaryAboveNumber @Number DECIMAL(18,4) 
AS
	SELECT FirstName, LastName
	FROM Employees
	WHERE Salary >= @Number

EXEC usp_GetEmployeesSalaryAboveNumber @Number = 48100
GO

--EXERCISE 3
CREATE PROC usp_GetTownsStartingWith @Contained NVARCHAR(25)
AS
	 SELECT [Name] AS Town 
	 FROM Towns
	 WHERE [Name] LIKE @Contained+'%'

EXEC usp_GetTownsStartingWith 'b'
GO

--EXERCISE 4
CREATE PROC usp_GetEmployeesFromTown @TownName NVARCHAR(50)
AS
	SELECT e.FirstName, e.LastName FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID= a.AddressID
	JOIN Towns AS t ON a.TownID = t.TownID
	WHERE @TownName = t.Name

EXEC usp_GetEmployeesFromTown @TownName = 'Sofia'
GO

--EXERCISE 5
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
RETURNS NVARCHAR(20)
AS
BEGIN
	DECLARE @result NVARCHAR(20);

	IF(@salary < 30000)
	BEGIN
	SET @result = 'Low'
	END

	ELSE IF(@salary <= 50000)
	BEGIN
	SET @result = 'Average'
	END

	ELSE
	BEGIN
	SET @result = 'High'
	END

	RETURN @result;
END

SELECT Salary, dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level] FROM Employees
GO

--EXERCISE 6
CREATE PROC usp_EmployeesBySalaryLevel @SalaryLevel VARCHAR(8)
AS
	SELECT FirstName AS [First Name], LastName AS [Last Name] 
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel

EXEC usp_EmployeesBySalaryLevel @SalaryLevel = 'high'
GO

--EXERCISE 7
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(50), @word NVARCHAR(25)) 
RETURNS BIT
AS
BEGIN
	DECLARE @result BIT = 1;
	DECLARE @counter INT = 1;
	DECLARE @wordLen INT = LEN(@word);
		WHILE(@counter <= @wordLen)
		BEGIN
		DECLARE @currentLetter CHAR(1)= SUBSTRING(@word, @counter, 1);
			IF(@setOfLetters NOT LIKE '%'+@currentLetter + '%')
			BEGIN
			SET @result = 0;
			END
		SET @counter += 1;
		END

	RETURN @result;
END

SELECT FirstName, dbo.ufn_IsWordComprised('j', FirstName) AS [Result] FROM Employees
GO

--EXERCISE 8
