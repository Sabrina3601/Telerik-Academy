-- TASK 9
-- Write a SQL query to find all departments and the average salary for each of them.

USE TelerikAcademy
SELECT d.Name AS [Department Name], AVG(e.Salary) AS [Average Salary]
FROM Departments d
JOIN Employees e
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name

-- ALTERNATIVE SOLUTION
USE TelerikAcademy
SELECT d.Name AS [Department Name], AVG(e.Salary) AS [Average Salary]
FROM Departments d, Employees e
WHERE e.DepartmentID = d.DepartmentID
GROUP BY d.Name
ORDER BY [Average Salary] DESC