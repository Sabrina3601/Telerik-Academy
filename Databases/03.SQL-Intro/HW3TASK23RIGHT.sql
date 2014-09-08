-- TASK 23 RIGHT OUTER JOIN
-- Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. Use right outer join. Rewrite the query to use left outer join.

USE TelerikAcademy
SELECT m.FirstName + ' ' + m.LastName AS [Manager Name], e.FirstName + ' ' + e.LastName AS [Employee Name]
FROM Employees e
RIGHT OUTER JOIN Employees m
ON m.EmployeeID = e.ManagerID