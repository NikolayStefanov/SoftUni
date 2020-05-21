--EXERCISE 13
CREATE DATABASE Movies

CREATE TABLE Directors(
Id INT  PRIMARY KEY IDENTITY,
DirectorName NVARCHAR(30) NOT NULL,
Notes NTEXT
)

INSERT INTO Directors(DirectorName, Notes)
VALUES('Nikolay Stefanov', 'C# Developer'),
	  ('Stefan Stefanov', 'VET'),
	  ('Paolina Stefanova', 'Children Teacher'),
	  ('Plamen Stefanov', 'Export AND Import'),
	  ('Daniel Kotsev', 'I LOVEC SYM I RIBAR SUM')

CREATE TABLE Genres(
Id INT  PRIMARY KEY IDENTITY,
GenreName NVARCHAR(30) NOT NULL,
Notes NTEXT
)

INSERT INTO Genres(GenreName, Notes)
VALUES('Comedy', 'For Fun'),
	  ('Action', 'For Motivation'),
	  ('Drama', 'For Cry'),
	  ('Fantasy', 'For Dreams'),
	  ('Porn', 'For EVERYTHING')


CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
CategoryName NVARCHAR(30) NOT NULL,
Notes NTEXT
)

INSERT INTO Categories(CategoryName, Notes)
VALUES('Comedies', NULL),
	  ('ActionS', NULL),
	  ('DramaS', NULL),
	  ('Fantasies', NULL),
	  ('PornS', NULL)


CREATE TABLE Movies(
Id INT  PRIMARY KEY IDENTITY,
Title NVARCHAR(50) NOT NULL,
DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
CopyrightYear DATE NOT NULL,
[Length] TIME(2) NOT NULL,
GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
Rating  INT CHECK(Rating>=1 AND Rating <= 10) NOT NULL,
Notes NTEXT
)


INSERT INTO Movies(Title,DirectorId,CopyrightYear,Length, GenreId,CategoryId,Rating,Notes)
VALUES('Blood Diamond', 1, '2009-10-10', '02:23:43.34', 2, 2, 9, 'AMAZING ACTOR PLAYING FROM LEONARDO DI CAPRIO'),
	  ('ELSA JEAN', 1, '2020-05-10', '00:23:43.34', 5, 5, 8, NULL),
	  ('ALLIED', 1, '2015-05-26', '02:29:43.34', 3, 3, 9, 'THE POWER OF LOVE'),
	  ('Spiderman', 1, '2009-10-10', '02:23:43.34', 4, 4, 4, NULL),
	  ('Vikings', 1, '2010-10-10', '00:45:43.34', 2, 2, 9, NULL)