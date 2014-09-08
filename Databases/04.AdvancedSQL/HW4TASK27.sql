-- TASK 27
-- Write a SQL query to display the town where maximal number of employees work.

SELECT TOP 1 t.Name, COUNT(*)
FROM Employees e
JOIN Addresses a ON a.AddressID = e.AddressID
JOIN Towns t ON t.TownID = a.TownID
GROUP BY t.Name
ORDER BY COUNT(*) DESC