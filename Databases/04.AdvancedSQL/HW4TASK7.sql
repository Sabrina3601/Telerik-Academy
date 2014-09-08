-- TASK7
-- Write a SQL query to find the number of all employees that have manager.

USE TelerikAcademy
SELECT COUNT(*)
FROM Employees
WHERE ManagerID IS NOT Null

-- ALTERNATIVE SOLUTION
SELECT COUNT(m.FirstName) 
FROM Employees em
LEFT JOIN Employees m ON em.ManagerID = m.EmployeeID