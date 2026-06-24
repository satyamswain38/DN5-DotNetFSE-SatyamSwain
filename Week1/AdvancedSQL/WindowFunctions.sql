-- Exercise 1: Ranking and Window Functions

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    EmployeeName VARCHAR(50),
    Department VARCHAR(50),
    Salary DECIMAL(10,2)
);

INSERT INTO Employees VALUES
(1,'Satyam','IT',50000),
(2,'Rahul','IT',60000),
(3,'Amit','HR',45000),
(4,'Priya','HR',55000),
(5,'Neha','Finance',70000);

SELECT
    EmployeeID,
    EmployeeName,
    Department,
    Salary,
    RANK() OVER (
        PARTITION BY Department
        ORDER BY Salary DESC
    ) AS SalaryRank
FROM Employees;