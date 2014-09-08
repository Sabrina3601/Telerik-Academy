-- TASK 18
-- Write a SQL query to find all employees along with their address. Use inner join with ON clause.

USE TelerikAcademy
SELECT e.FirstName, e.LastName, a.AddressText, a.TownID FROM Employees e
INNER JOIN Addresses a
ON e.AddressID = a.AddressID