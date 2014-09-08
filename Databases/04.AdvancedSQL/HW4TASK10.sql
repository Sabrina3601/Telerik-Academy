-- TASK 10
-- Write a SQL query to find the count of all employees in each department and for each town.

USE TelerikAcademy
SELECT d.Name AS [Department Name], t.Name, COUNT(e.EmployeeID) AS [Number Of Employees]
FROM Departments d, Addresses a, Towns t, Employees e
WHERE d.DepartmentID = e.DepartmentID AND e.AddressID = a.AddressID AND t.TownID = a.TownID
GROUP BY t.Name, d.Name

-- ALTERNATIVE SOLUTION
SELECT d.Name, t.Name, Count(em.FirstName) 
FROM Employees em
JOIN Departments d ON d.DepartmentID = em.DepartmentID
JOIN Addresses a ON a.AddressID = em.AddressID
JOIN Towns t ON t.TownID = a.TownID
GROUP BY t.Name, d.Name