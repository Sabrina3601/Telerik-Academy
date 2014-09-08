-- TASK 8
-- Write a SQL query to find the number of all employees that have no manager.

USE TelerikAcademy
SELECT COUNT(*)
FROM Employees
WHERE ManagerID IS NULL

-- ALTERNATIVE SOLUTION
SELECT COUNT(em.FirstName) - COUNT(m.FirstName) 
FROM Employees em
LEFT JOIN Employees m ON em.ManagerID = m.EmployeeID