CREATE DATABASE miniErpDB;
USE miniErpDB;
CREATE TABLE Firms (
    FirmID INT IDENTITY(1,1) PRIMARY KEY,
    FirmName VARCHAR(100),
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Periods (
    PeriodID INT PRIMARY KEY,   
    PeriodName VARCHAR(50)     
);

CREATE TABLE Admins (
    AdminID INT IDENTITY(1,1) PRIMARY KEY,
    UserName VARCHAR(50) NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL,
    FirmID INT UNIQUE,
    CreatedAt DATETIME DEFAULT GETDATE(),

    FOREIGN KEY (FirmID) REFERENCES Firms(FirmID)
);

CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeName VARCHAR(50) NOT NULL,
    EmployeeSurName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    FirmID INT NOT NULL,
    PeriodID INT NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),

    FOREIGN KEY (FirmID) REFERENCES Firms(FirmID),
    FOREIGN KEY (PeriodID) REFERENCES Periods(PeriodID)
);
-- projede kullandýðým veri tabaný kodlarý aklýmda tam bi iskelet canlamdýðýndan kendi kafamdan tasarladým employe felan 
-- projeye devam edersem kullanýcýðým tablolar