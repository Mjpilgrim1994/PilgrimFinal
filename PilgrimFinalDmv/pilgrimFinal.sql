USE master;
GO

CREATE DATABASE PilgrimFinal;
GO 

USE PilgrimFinal;
GO

CREATE TABLE Employees(
	EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
	DepartmentID VARCHAR(255),
	FirstName VARCHAR(255) NOT NULL,
	LastName VARCHAR(255) NOT NULL
);

CREATE TABLE Drivers(
	SocialNumber VARCHAR(255) PRIMARY KEY NOT NULL,
	FirstName VARCHAR(255) NOT NULL,
	LastName VARCHAR(255) NOT NULL,
	PlateNumber VARCHAR(255) NOT NULL,
	VIN VARCHAR(255) NOT NULL,
	DepartmentID VARCHAR(255)
);

CREATE TABLE DriverInfractions(
	InfractionID INT IDENTITY(1,1) PRIMARY KEY,
	SocialNumber VARCHAR(255),
	DepartmentID VARCHAR(255),
	Infraction VARCHAR(255)
);

INSERT INTO Employees(DepartmentID, FirstName, LastName) VALUES
('LAW01', 'Dan', 'Smith'),
('LAW02', 'Amy', 'Johnson'),
('LAW03', 'Bill', 'Brothers'),
('LAW04', 'Cassidy', 'Conners'),
('LAW05', 'Terry', 'Crews'),
('DMV01', 'Lilly', 'Miller'),
('DMV02', 'James', 'Nelson'),
('DMV03', 'Mary', 'Greld'),
('DMV04', 'Cory', 'Webster'),
('DMV05', 'Amanda', 'Frank');

INSERT INTO Drivers VALUES
('0000000000', 'Francis', 'Ingles', '000000', '00000000000000000', 'DMV01'),
('1111111111', 'Greg', 'Medows', '111111', '11111111111111111', 'DMV01'),
('2222222222', 'Velma', 'Doo', '222222', '22222222222222222', 'DMV03'),
('3333333333', 'Hannah', 'Pilgrim', '333333', '33333333333333333', 'DMV02'),
('4444444444', 'Jeana', 'Snively', '444444', '44444444444444444', 'DMV02'),
('5555555555', 'Matthew', 'Pilgrim', '555555', '55555555555555555', 'DMV01'),
('6666666666', 'Caleb', 'Oberg', '666666', '66666666666666666', 'DMV04'),
('7777777777', 'Laurie', 'Snively', '777777', '77777777777777777', 'DMV05'),
('8888888888', 'Guster', 'Buster', '888888', '88888888888888888', 'DMV04'),
('9999999999', 'Sha', 'Boodles', '999999', '99999999999999999', 'DMV05');

INSERT INTO DriverInfractions(SocialNumber, DepartmentID, Infraction) VALUES
('1111111111','LAW01','Speeding'),
('4444444444','LAW02','Speeding'),
('7777777777','LAW02','DUI'),
('6666666666','LAW05','Wreckless'),
('3333333333','LAW02','Speeding'),
('2222222222','LAW05','Tabs'),
('4444444444','LAW01','Speeding'),
('0000000000','LAW03','Parking'),
('9999999999','LAW04','Speeding'),
('3333333333','LAW05','DUI');