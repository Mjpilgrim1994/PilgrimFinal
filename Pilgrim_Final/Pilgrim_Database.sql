USE master;
GO

CREATE DATABASE pilgrim_dmv;
GO

USE pilgrim_dmv;
GO

CREATE TABLE Employee (
	EmployeeID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Badge_Number varchar(255),
	First_Name varchar(255) NOT NULL,
	Last_Name varchar(255) NOT NULL
);

INSERT INTO Employee (Badge_Number, First_Name, Last_Name) VALUES
	(NULL, 'Bob', 'Hope'),
	(NULL, 'Gracie', 'Fink'),
	(NULL, 'Fred', 'Flinstone'),
	(NULL, 'Meg', 'Griffin'),
	(NULL, 'Patty', 'Cakes'),
	('BN001', 'Julia', 'Mars'),
	('BN002', 'Alice', 'Cooper'),
	('BN003', 'Dwayne', 'Johnson'),
	('BN004', 'Under', 'Taker'),
	('BN8264', 'Jason', 'Momoa')
;

CREATE TABLE Driver_Infractions (
	InfractionID int  NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Social_Number varchar(255) NOT NULL,
	Badge_Number varchar(255) NOT NULL,
	Infraction varchar(255)
);
	
INSERT INTO Driver_Infractions (Social_Number, Badge_Number, Infraction) VALUES
	('1112223344', 'BN001', 'Speeding'),
	('9988776655', 'BN002', 'DUI'),
	('1234567890', 'BN003', 'Reckless'),
	('1112223344', 'BN004', 'DUI'),
	('1112223344', 'BN002', 'Tabs'),
	('8374625162', 'BN002', 'Speeding'),
	('0002299384', 'BN8264', 'Speeding'),
	('2222222221', 'BN8264', 'Speeding'),
	('3628918342', 'BN8264', 'Reckless'),
	('2134292736', 'BN8264', 'Speeding')
;

CREATE TABLE Drivers (
	Social_Number varchar(255) NOT NULL PRIMARY KEY,
	First_Name varchar(255) NOT NULL,
	Last_Name varchar(255) NOT NULL,
	Plate_Number varchar(255) NOT NULL,
	VIN varchar(255) NOT NULL,
	Employee_ID varchar(255) NOT NULL
);

INSERT INTO Drivers VALUES
	('1112223344', 'Pickle', 'Rick', 'PKLR1CK', '123ABC456DEF789GH', 2),
	('9988776655', 'SpongeBob', 'Squarepants', 'P4TT135', 'ONETWOTHREE123456', 3),
	('0002299384', 'Walt', 'Disney', 'MGCM4N', 'SEVENTEEN09876543', 5),
	('9382917375', 'Olivia', 'Johnson', '123ABC', '129864G72J9D0L9RN', 2),
	('1245268345', 'Veronica', 'Steele', '356B3J', '555NHU32O1ND098J5', 7),
	('2222222221', 'James', 'Bowman', 'PK1M42', '123123NKPIH432NB4', 1),
	('3628918342', 'Tony', 'Stark', '840UNJ', '452674L7K432N64N7', 6),
	('2134292736', 'Aqua', 'Man', 'D42F456', '12KJ5ND93N22B34K5', 8),
	('1234567890', 'Mr', 'Beast', 'LIP392', 'B5K3B2O47BO243B5K', 7),
	('8374625162', 'Tammy', 'Jamenez', '432NHY', '9Z98FG98324BO987F', 4)
;
