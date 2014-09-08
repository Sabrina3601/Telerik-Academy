-- TASK 20
-- Write a SQL query to find all employees along with their manager.

USE TelerikAcademy
SELECT e.FirstName + ' ' + e.LastName AS [Employee Name], m.FirstName + ' ' + m.LastName AS [Manager Name]
FROM Employees e
INNER JOIN Employees m
ON e.ManagerID = m.EmployeeID