-- TASK 4
-- Write a SQL query to find the average salary in department #1.

USE TelerikAcademy
SELECT AVG(Salary)
FROM Employees e
WHERE DepartmentID = '1'