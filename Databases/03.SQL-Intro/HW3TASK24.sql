-- TASK 24
-- Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005.

USE TelerikAcademy
SELECT e.FirstName, e.LastName, d.Name, e.HireDate FROM Employees e
JOIN Departments d
--WHERE d.Name = 'Sales' AND d.Name = 'Finance' 
--AND e.HireDate BETWEEN 1995-01-01 AND 2014-01-01
ON (e.DepartmentID = d.DepartmentID AND d.Name IN ('Sales', 'Finance') 
AND (YEAR(e.HireDate) > 1995) AND (YEAR(e.HireDate) < 2005))