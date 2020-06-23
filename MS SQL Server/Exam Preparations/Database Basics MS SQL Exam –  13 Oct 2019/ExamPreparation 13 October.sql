CREATE DATABASE Bitbucket

--EXERCISE 1
CREATE TABLE Users(
Id INT PRIMARY KEY IDENTITY NOT NULL,
Username NVARCHAR(30) NOT NULL,
[Password] NVARCHAR(30)NOT NULL,
Email NVARCHAR(50) NOT NULL
)

CREATE TABLE Repositories(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors(
RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
PRIMARY KEY(RepositoryId, ContributorId)
)

CREATE TABLE Issues(
Id INT PRIMARY KEY IDENTITY NOT NULL,
Title NVARCHAR(255) NOT NULL,
IssueStatus CHAR(6) NOT NULL,
RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL, 
AssigneeId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Commits(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Message] NVARCHAR(255) NOT NULL,
IssueId INT FOREIGN KEY REFERENCES Issues(Id),
RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Files(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] NVARCHAR(100) NOT NULL,
Size DECIMAL(15,2) NOT NULL,
ParentId INT FOREIGN KEY REFERENCES Files(Id),
CommitId INT FOREIGN KEY REFERENCES Commits(Id) NOT NULL
)

--EXERCISE 2
INSERT INTO Files([Name], Size,ParentId,CommitId)
VALUES('Trade.idk',2598.0, 1,1),
	  ('menu.net',9238.31, 2,2),
	  ('Administrate.soshy',1246.93, 3,3),
	  ('Controller.php',7353.15, 4,4),
	  ('Find.java',9957.86, 5,5),
	  ('Controller.json',14034.87, 3,6),
	  ('Operate.xix',7662.92, 7,7)

INSERT INTO Issues(Title, IssueStatus, RepositoryId,AssigneeId)
VALUES('Critical Problem with HomeController.cs file','open',1,4),
	  ('Typo fix in Judge.html','open',4,3),
	  ('Implement documentation for UsersService.cs','closed',8,2),
	  ('Unreachable code in Index.cs','open',9,8)


--EXERCISE 3
UPDATE Issues
SET IssueStatus ='closed'
WHERE AssigneeId = 6

--EXERCISE 4
DELETE FROM Issues
WHERE RepositoryId = (SELECT Id FROM Repositories WHERE [Name] = 'Softuni-Teamwork')
DELETE FROM RepositoriesContributors
WHERE RepositoryId = (SELECT Id FROM Repositories WHERE [Name] = 'Softuni-Teamwork')

--EXERCISE 5
SELECT Id, Message, RepositoryId, ContributorId 
FROM Commits 
ORDER BY Id, [Message], RepositoryId, ContributorId

--EXERCISE 6
SELECT Id, [Name], Size 
FROM Files
WHERE Size > 1000 AND [Name] LIKE '%html%'
ORDER BY Size DESC, Id, [Name]

--EXERCISE 7
SELECT i.Id ,u.Username + ' : ' +i.Title AS [IssueAssignee] 
FROM Users AS u
JOIN Issues AS i ON u.Id = i.AssigneeId
ORDER BY i.Id DESC, IssueAssignee

--EXERCISE 8
SELECT Id, [Name], CONCAT(Size ,'KB') AS [Size]
FROM Files AS f
WHERE Id NOT IN  (SELECT ParentId FROM Files WHERE ParentId IS NOT NULL)
ORDER BY Id, [Name], f.Size DESC

--EXERCISE 9
SELECT TOP(5) r.Id, r.Name,COUNT(c.RepositoryId) AS Commits FROM Repositories AS r
JOIN Commits AS c ON r.Id = c.RepositoryId
JOIN RepositoriesContributors AS rc ON rc.RepositoryId = r.Id
GROUP BY r.Id, r.[Name]
ORDER BY Commits DESC,r.Id, r.[Name]

--EXERCISE 10
SELECT u.Username, AVG(f.Size) AS [Size] FROM Users AS u
JOIN Commits AS c ON u.Id = c.ContributorId
JOIN Files AS f ON c.Id = f.CommitId
GROUP BY u.Username
ORDER BY Size DESC, u.Username

--EXERCISE 11
CREATE FUNCTION udf_UserTotalCommits(@username NVARCHAR(MAX))
RETURNS INT
AS
BEGIN
	DECLARE @userId INT= (SELECT Id FROM Users WHERE Username = @username);
	DECLARE @commitsCount INT = (SELECT COUNT(*) FROM Commits WHERE ContributorId = @userId)

	RETURN @commitsCount
END

--EXERCISE 12
CREATE PROC usp_FindByExtension(@extension NVARCHAR(MAX))
AS
	SELECT Id, [Name], CONCAT(Size, 'KB') AS [Size] 
	FROM Files 
	WHERE  [Name] LIKE '%' + @extension
	ORDER BY Id, [Name], Size DESC

EXEC usp_FindByExtension 'txt'