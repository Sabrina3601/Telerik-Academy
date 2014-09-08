-- TASK 19
-- Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).

USE 
TelerikAcademy
SELECT e.FirstName + ' ' + e.LastName AS [Employee Name], a.AddressText AS [Employee Address]
FROM Employees e, Addresses a
WHERE e.AddressID = a.AddressID
