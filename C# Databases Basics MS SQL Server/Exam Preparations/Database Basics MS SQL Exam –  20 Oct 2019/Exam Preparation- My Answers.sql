USE Service

--EXERCISE 1
CREATE TABLE Users(
Id INT PRIMARY KEY IDENTITY NOT NULL,
Username NVARCHAR(30) UNIQUE NOT NULL,
[Password] NVARCHAR(50) NOT NULL,
[Name] NVARCHAR(50),
Birthdate DATETIME2,
Age INT CHECK(Age >= 14 AND Age <=110),
Email NVARCHAR(50) NOT NULL
)

CREATE TABLE Departments(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] NVARCHAR(50) NOT NULL 
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY NOT NULL,
FirstName NVARCHAR(25),
LastName NVARCHAR(25),
Birthdate DATETIME2,
Age INT CHECK(Age >= 18 AND Age<= 110),
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] NVARCHAR(50) NOT NULL,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE [Status](
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Label] NVARCHAR(30) NOT NULL
)

CREATE TABLE Reports(
Id INT PRIMARY KEY IDENTITY NOT NULL,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
StatusId INT FOREIGN KEY REFERENCES [Status](Id) NOT NULL,
OpenDate DATETIME2 NOT NULL,
CloseDate DATETIME2,
[Description] NVARCHAR(200) NOT NULL,
UserId  INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

--EXERCISE 2
INSERT INTO Employees(FirstName, LastName, Birthdate, DepartmentId)
VALUES('Marlo', 'O''Malley', '1958-09-21', 1),
	  ('Niki', 'Stranaghan', '1969-11-26', 4),
	  ('Ayrton', 'Senna', '1960-03-21', 9),
	  ('Ronnie', 'Peterson', '1944-02-14', 9),
	  ('Giovanna', 'Amati', '1959-07-20', 5)

INSERT INTO Reports
VALUES(1,1,'2017-04-13',NULL, 'Stuck Road on Str.133', 6,2),
	  (6,3, '2015-09-05', '2015-12-06', 'Charity trail running',3,5),
	  (14,2,'2015-09-07',NULL, 'Falling bricks on Str.58',5,2),
	  (4,3, '2017-07-03','2017-07-06','Cut off streetlight on Str.11',1,1)

--EXERCISE 3
UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

--EXERCISE 4
DELETE FROM Reports WHERE StatusId = 4

--EXERCISE 5
SELECT [Description], FORMAT(OpenDate, 'dd-MM-yyyy') AS OpenDate
FROM Reports
WHERE EmployeeId IS NULL
ORDER BY YEAR(OpenDate), MONTH(OpenDate), Description 

--EXERCISE 6
SELECT r.Description, c.Name AS [CategoryName] FROM Reports AS r
JOIN Categories AS c ON r.CategoryId = c.Id
ORDER BY r.Description, c.Name

--EXERCISE 7
SELECT TOP(5) c.Name AS CategoryName ,COUNT(*) ReportsNumber 
FROM Reports AS r
JOIN Categories AS c ON r.CategoryId = c.Id
GROUP BY CategoryId, c.[Name]
ORDER BY ReportsNumber DESC, c.Name

--EXERCISE 8
SELECT u.Username, c.Name AS [CategoryName] FROM Reports AS r
JOIN Users AS u ON r.UserId = u.Id
JOIN Categories AS c ON c.Id = r.CategoryId
WHERE MONTH(u.Birthdate) = MONTH(r.OpenDate) AND DAY(u.Birthdate) = DAY(r.OpenDate)
ORDER BY u.Username, c.Name

--EXERCISE 9
SELECT ft.FullName, COUNT(ft.EmployeeId) AS [UsersCount] FROM (SELECT (e.FirstName + ' ' +e.LastName) AS [FullName], r.EmployeeId, r.UserId FROM Reports AS r
RIGHT JOIN Employees AS e ON r.EmployeeId = e.Id
GROUP BY r.EmployeeId, r.UserId, e.FirstName, e.LastName) AS ft
GROUP BY ft.FullName
ORDER BY COUNT(ft.EmployeeId) DESC, FullName

--EXERCISE 10
SELECT 
		CASE
			WHEN CONCAT(e.FirstName, ' ', e.LastName) = '' THEN 'None'
 
            ELSE
                CONCAT(e.FirstName, ' ', e.LastName)
		END AS [Employee],
	   ISNULL(d.[Name], 'None') AS [Department],
	   c.[Name] AS [Category],
	   r.[Description]  AS [Description],
	   FORMAT(r.OpenDate, 'dd.MM.yyyy')  AS [OpenDate],
	   s.[Label] AS [Status],
	   u.[Name] AS [User]
FROM Reports AS r
	LEFT JOIN Employees AS e ON e.Id = r.EmployeeId
	LEFT JOIN Departments AS d ON d.Id = e.DepartmentId
	LEFT JOIN Categories AS c ON c.Id = r.CategoryId
	LEFT JOIN Status AS s ON s.Id = r.StatusId
	LEFT JOIN Users AS u ON u.Id = r.UserId
ORDER BY e.FirstName DESC, e.LastName DESC, d.Name, c.Name, r.Description, r.OpenDate, s.Label, u.Name


--AGAIN EXERCISE 10
SELECT ISNULL((e.FirstName+ ' '+ e.LastName), 'None') AS [Employee],
	   ISNULL(d.[Name], 'None') AS [Department],
	   ISNULL(c.[Name],'None') AS [Category],
	   ISNULL(r.[Description], 'None') AS [Description],
	   ISNULL(FORMAT(r.OpenDate, 'dd.MM.yyyy'), 'None') AS [OpenDate],
	   ISNULL(s.[Label], 'None') AS [Status],
	   ISNULL(u.[Name], 'None') AS [User]
FROM Reports AS r
	LEFT JOIN Employees AS e ON r.EmployeeId = e.Id
	LEFT JOIN Categories AS c ON r.CategoryId = c.Id
	LEFT JOIN [Status] AS s ON r.StatusId = s.Id
	LEFT JOIN Users AS u ON r.UserId = u.Id
	LEFT JOIN Departments AS d ON e.DepartmentId = d.Id
ORDER BY e.FirstName DESC, e.LastName DESC, Department, Category, [Description], OpenDate, [Status], [User]

--EXERCISE 11
CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME) 
RETURNS BIGINT
AS 
BEGIN
	DECLARE @result BIGINT;

	IF(@StartDate IS NULL OR @EndDate IS NULL)
	BEGIN
	SET @result = 0;
	END

	ELSE
	BEGIN 
	SET @result = DATEDIFF(HOUR, @StartDate, @EndDate);
	END

	RETURN @result;
END

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours FROM Reports

--EXERCISE 12
GO
CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS 
	DECLARE @departmentOfEmployee INT;
	DECLARE @departmentOfCategory INT;

	SELECT @departmentOfEmployee = DepartmentId FROM Employees WHERE @EmployeeId = Id
	SELECT @departmentOfCategory = c.DepartmentId FROM Reports AS r JOIN Categories AS c ON r.CategoryId = c.Id WHERE r.Id = @ReportId

	IF(@departmentOfEmployee = @departmentOfCategory)
	BEGIN
	UPDATE Reports
	SET EmployeeId = @EmployeeId
	WHERE Id =@ReportId
	END

	ELSE
	BEGIN
	THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1;  
	END

EXEC usp_AssignEmployeeToReport 17, 2