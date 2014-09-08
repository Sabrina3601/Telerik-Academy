-- TASK 28
-- Write a SQL query to display the number of managers from each town.

USE TelerikAcademy
SELECT t.Name AS [Town Name], COUNT(e.ManagerID) AS [Number Of Managers]
FROM Employees e
JOIN Addresses a ON e.AddressID = a.AddressID
JOIN Towns t ON t.TownID = a.TownID
WHERE e.EmployeeID IN (SELECT DISTINCT ManagerID FROM Employees)
GROUP BY t.Name