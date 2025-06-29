USE SQLTestDB;
GO

-- Drop Views if exist
IF OBJECT_ID('vw_EmployeeReport', 'V') IS NOT NULL DROP VIEW vw_EmployeeReport;
IF OBJECT_ID('vw_EmployeeAnnualSalary', 'V') IS NOT NULL DROP VIEW vw_EmployeeAnnualSalary;
IF OBJECT_ID('vw_EmployeeFullName', 'V') IS NOT NULL DROP VIEW vw_EmployeeFullName;
IF OBJECT_ID('vw_EmployeeBasicInfo', 'V') IS NOT NULL DROP VIEW vw_EmployeeBasicInfo;
GO

-- Drop Function if exists
IF OBJECT_ID('fn_CalculateAnnualSalary', 'FN') IS NOT NULL DROP FUNCTION fn_CalculateAnnualSalary;
GO

-- Drop Tables if exist
IF OBJECT_ID('Employees', 'U') IS NOT NULL DROP TABLE Employees;
IF OBJECT_ID('Departments', 'U') IS NOT NULL DROP TABLE Departments;
GO

-- 1. Departments Table
CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100) NOT NULL
);
GO

-- 2. Employees Table
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    DepartmentID INT NOT NULL FOREIGN KEY REFERENCES Departments(DepartmentID),
    Salary DECIMAL(10, 2) NOT NULL,
    JoinDate DATE NOT NULL
);
GO

-- 3. Sample Data for Departments
INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, 'HR'),
(2, 'IT'),
(3, 'Finance');
GO

-- 4. Sample Data for Employees
INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
(101, 'Alice', 'Smith', 1, 50000, '2022-01-15'),
(102, 'Bob', 'Johnson', 2, 60000, '2021-03-20'),
(103, 'Charlie', 'Williams', 3, 55000, '2020-06-10');
GO

-- 5. View: Employee Basic Info
CREATE VIEW vw_EmployeeBasicInfo AS
SELECT 
    e.EmployeeID,
    e.FirstName,
    e.LastName,
    d.DepartmentName
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID;
GO

-- 6. View: Employee Full Name
CREATE VIEW vw_EmployeeFullName AS
SELECT 
    e.EmployeeID,
    e.FirstName,
    e.LastName,
    (e.FirstName + ' ' + e.LastName) AS FullName,
    d.DepartmentName
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID;
GO

-- 7. View: Employee Annual Salary
CREATE VIEW vw_EmployeeAnnualSalary AS
SELECT 
    e.EmployeeID,
    e.FirstName,
    e.LastName,
    d.DepartmentName,
    (e.Salary * 12) AS AnnualSalary
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID;
GO

-- 8. View: Employee Report (FullName, Annual Salary, Bonus)
CREATE VIEW vw_EmployeeReport AS
SELECT 
    e.EmployeeID,
    (e.FirstName + ' ' + e.LastName) AS FullName,
    d.DepartmentName,
    (e.Salary * 12) AS AnnualSalary,
    (e.Salary * 12) * 0.10 AS Bonus
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID;
GO

-- 9. Scalar Function: Calculate Annual Salary
CREATE FUNCTION fn_CalculateAnnualSalary (@EmployeeID INT)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @AnnualSalary DECIMAL(10, 2);

    SELECT @AnnualSalary = Salary * 12
    FROM Employees
    WHERE EmployeeID = @EmployeeID;

    RETURN @AnnualSalary;
END;
GO
