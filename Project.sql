USE master
GO

IF EXISTS (SELECT * FROM sysdatabases WHERE name = 'College1en')
BEGIN
	DROP DATABASE College1en
END
GO

CREATE DATABASE College1en;
GO

USE College1en;
GO


CREATE TABLE Programs(ProgId VARCHAR(5) NOT NULL, 
											ProgName VARCHAR(50) NOT NULL,
                      CONSTRAINT PK_Programs PRIMARY KEY (ProgId));

CREATE TABLE Courses(CId VARCHAR(7) NOT NULL,
                     CName VARCHAR(50) NOT NULL,
                     ProgId VARCHAR(5) NOT NULL,
                     CONSTRAINT PK_Courses PRIMARY KEY (CId),
                     CONSTRAINT FK_Programs_Courses FOREIGN KEY (ProgId) REFERENCES Programs(ProgId) 
                     ON DELETE CASCADE 
                     ON UPDATE CASCADE);

CREATE TABLE Students(StId VARCHAR(10) NOT NULL,
                      StName VARCHAR(50) NOT NULL,
                      ProgId VARCHAR(5) NOT NULL,
                      CONSTRAINT PK_Students PRIMARY KEY (StId),
                      CONSTRAINT FK_Programs_Students FOREIGN KEY (ProgId) REFERENCES Programs(ProgId) 
                      ON DELETE NO ACTION
                      ON UPDATE CASCADE);

CREATE TABLE Enrollments(StId VARCHAR(10) NOT NULL,
                         CId VARCHAR(7) NOT NULL,
                         FinalNote INT,
                         CONSTRAINT PK_Enrolments PRIMARY KEY (StId, CId),
                         CONSTRAINT FK_Enrolments_Students FOREIGN KEY (StId) REFERENCES Students(StId)
                         ON DELETE CASCADE 
                         ON UPDATE CASCADE,
                         CONSTRAINT FK_Enrolments_Courses FOREIGN KEY (CId) REFERENCES Courses(CId)
                         ON DELETE NO ACTION
                         ON UPDATE NO ACTION);


INSERT INTO Programs (ProgId, ProgName)
VALUES ('P0010', 'Computer Science'),
       ('P0020', 'Bussiness Administration'),
       ('P0030', 'Cooking'),
       ('P0040', 'Fashion Design');

INSERT INTO Courses (CId, CName, ProgId)
VALUES ('C010101', 'Introduction to Computer Science', 'P0010'),
       ('C020202', 'OOP', 'P0010'),
       ('C030303', 'Bussiness and Managment', 'P0020'),
       ('C040404', 'Introduction to Marketing', 'P0020'),
       ('C050505', 'Introduction to Cooking', 'P0030'),
       ('C060606', 'Healthy Food', 'P0030'),
       ('C070707', 'Study and Utilization of Raw Materials', 'P0040'),
       ('C080808', 'History of Fashion', 'P0040');

INSERT INTO Students (StId, StName, ProgId)
VALUES ('S111111111', 'Steve Wozniak', 'P0010'),
       ('S222222222', 'Elon Mask', 'P0010'),
       ('S333333333', 'Jeff Bezos', 'P0020'),
       ('S444444444', 'Larry Ellison', 'P0020'),
       ('S555555555', 'Gordon Ramsay', 'P0030'),
       ('S666666666', 'Guy Fieri', 'P0030'),
       ('S777777777', 'Donna Karan', 'P0040'),
       ('S888888888', 'Giorgio Armani', 'P0040');

INSERT INTO Enrollments (StId, CId, FinalNote)
VALUES ('S111111111', 'C010101', 60),
       ('S333333333', 'C030303', 100)
GO
