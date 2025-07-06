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


INSERT INTO Departments (DepartmentName) VALUES ('Satýþ');
INSERT INTO Departments (DepartmentName) VALUES ('Pazarlama');
INSERT INTO Departments (DepartmentName) VALUES ('Ýnsan Kaynaklarý');
INSERT INTO Departments (DepartmentName) VALUES ('IT');

INSERT INTO Roles (RoleName) VALUES ('Yönetici');
INSERT INTO Roles (RoleName) VALUES ('Çalýþan');
INSERT INTO Roles (RoleName) VALUES ('Stajyer');
INSERT INTO Roles (RoleName) VALUES ('Uzman');

INSERT INTO Employees (FirmID, FullName, Email, PhoneNumber, Address, DepartmentID, RoleID)
VALUES 
(1, 'Ahmet Yýlmaz', 'ahmet.yilmaz@deneme3.com', '05551234567', 'Ýstanbul, Türkiye', 1, 2),
(1, 'Ayþe Demir', 'ayse.demir@deneme3.com', '05557654321', 'Ankara, Türkiye', 2, 3);

SELECT * FROM Firms;