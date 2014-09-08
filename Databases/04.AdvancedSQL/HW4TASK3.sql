-- TASK 3
-- Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department. Use a nested SELECT statement.

USE TelerikAcademy
SELECT FirstName + ' ' + LastName AS [Full Name], Salary, DepartmentID
FROM Employees e
WHERE Salary =
(SELECT MIN(s.Salary) FROM Employees s
WHERE DepartmentID = e.departmentID)
ORDER BY DepartmentID