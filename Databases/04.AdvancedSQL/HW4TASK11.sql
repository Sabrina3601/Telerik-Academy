-- TASK 11
-- Write a SQL query to find all managers that have exactly 5 employees. Display their first name last name.

USE TelerikAcademy
SELECT m.FirstName + ' ' + m.LastName AS [Manager Name]
FROM Employees e, Employees m
WHERE m.EmployeeID = e.ManagerID
GROUP BY m.FirstName, m.LastName
--GROUP BY m.FirstName + ' ' + m.LastName
HAVING COUNT(*) = 5

-- ALTERNATIVE SOLUTION
SELECT m.FirstName + ' ' + m.LastName AS [Manager Name]
FROM Employees em
JOIN Employees m
ON em.ManagerID = m.EmployeeID
GROUP BY m.FirstName + ' ' + m.LastName
HAVING COUNT(*) = 5