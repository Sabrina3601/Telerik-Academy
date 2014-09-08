-- TASK 25
-- Write a SQL query to display the average employee salary by department and job title.

USE TelerikAcademy
SELECT d.Name, e.JobTitle, AVG(e.Salary) AS [Average Salary]
FROM Employees e
JOIN Departments d
ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name, e.JobTitle
--ORDER BY AVG(e.Salary) DESC
ORDER BY d.Name