USE master
GO

DROP DATABASE IF EXISTS MoviesDatabase
GO

CREATE DATABASE MoviesDatabase
GO

USE MoviesDatabase
GO

DROP TABLE IF EXISTS Movies
CREATE TABLE Movies 
(
	MovieId		int				PRIMARY KEY	IDENTITY NOT NULL,
	MovieName	varchar(50)		NOT NULL,
	MovieGenre	varchar(10)		NOT NULL CHECK (MovieGenre in('Crime', 'Drama', 'Comedy', 'Horror', 'Action')),
	MovieStatus	varchar(9)		NOT NULL CHECK (MovieStatus in('Planning', 'Watching', 'Finished', 'Dropped')),
	ReleaseYear smalldatetime	NOT NULL,
	RunTime		time			NOT NULL
)

DROP TABLE IF EXISTS Actors
CREATE TABLE Actors
(
	ActorId			int				PRIMARY KEY IDENTITY NOT NULL,
	ActorFirstName	varchar(30)		NOT NULL,
	ActorLastName	varchar(40)		NOT NULL,
	ActorFollowed	bit				NOT NULL					
)

DROP TABLE IF EXISTS MoviesWithActors
CREATE TABLE MoviesWithActors
(
	MovieId		int		FOREIGN KEY REFERENCES Movies(MovieID),
	ActorId		int		FOREIGN KEY REFERENCES Actors(ActorId)
)

INSERT INTO Movies(MovieName, MovieGenre, MovieStatus, ReleaseYear, RunTime) -- 'Crime', 'Drama', 'Comedy', 'Horror', 'Action'
													   -- 'Planning', 'Watching', 'Finished', 'Dropped'
	VALUES('The GodFather', 'Crime', 'Planning', '1972-01-01  00:00:00', '02:55:00'),
	('The Shawshank Redemption', 'Drama', 'Watching', '1994-01-01  00:00:00', '02:22:00')
	,('Schindler''s List ', 'Drama', 'Finished', '1993-01-01  00:00:00', '03:15:00')
	,('Raging Bull', 'Drama', 'Dropped', '1980-01-01  00:00:00', '02:09:00')

INSERT INTO Actors(ActorFirstName, ActorLastName, ActorFollowed) -- 1 or 0 == t or f
	VALUES('Marlon', 'Brando', 1), ('Al', 'Pachino', 0), 
	('Tim', 'Robbins', 0), ('Morgan', 'Freeman', 1)
	,('Liam', 'Neeson', 1), ('Ralph', 'Fiennes', 0)
	,('Robert', 'De Niro', 1), ('Joe', 'Pesci', 0)

INSERT INTO MoviesWithActors (MovieId, ActorId)
	VALUES(1, 1), (1, 2), (2, 3), (2, 4), (3, 5), (3, 6), (4, 7), (4, 8)

SELECT * 
FROM Movies

SELECT * 
FROM Actors

SELECT *
FROM MoviesWithActors



	
	
	

