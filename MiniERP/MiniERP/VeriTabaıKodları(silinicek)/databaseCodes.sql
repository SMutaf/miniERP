CREATE TABLE Firms (
    FirmID INT PRIMARY KEY IDENTITY,
    FirmName NVARCHAR(100) NOT NULL,
    CreatedDate DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1
);
CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY IDENTITY,
    DepartmentName NVARCHAR(100) NOT NULL
);
CREATE TABLE Roles (
    RoleID INT PRIMARY KEY IDENTITY,
    RoleName NVARCHAR(100) NOT NULL
);
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY,
    FirmID INT NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100),
    PhoneNumber NVARCHAR(20),
    Address NVARCHAR(250),

    DepartmentID INT,
    RoleID INT,

    CreatedDate DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1,

    FOREIGN KEY (FirmID) REFERENCES Firms(FirmID),
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID),
    FOREIGN KEY (RoleID) REFERENCES Roles(RoleID)
);

CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(50) NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    IsAdmin BIT DEFAULT 0,
    CreatedDate DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1
);

CREATE TABLE UserFirms (
    UserFirmID INT PRIMARY KEY IDENTITY,
    UserID INT NOT NULL,
    FirmID INT NOT NULL,
    IsActive BIT DEFAULT 1,
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (FirmID) REFERENCES Firms(FirmID),
    CONSTRAINT UQ_UserFirm UNIQUE (UserID, FirmID)
);

INSERT INTO Departments (DepartmentName) VALUES ('Satýþ');
INSERT INTO Departments (DepartmentName) VALUES ('Pazarlama');
INSERT INTO Departments (DepartmentName) VALUES ('Ýnsan Kaynaklarý');
INSERT INTO Departments (DepartmentName) VALUES ('IT');

INSERT INTO Roles (RoleName) VALUES ('Yönetici');
INSERT INTO Roles (RoleName) VALUES ('Çalýþan');
INSERT INTO Roles (RoleName) VALUES ('Stajyer');
INSERT INTO Roles (RoleName) VALUES ('Uzman');



