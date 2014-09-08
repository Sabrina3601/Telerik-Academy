-- TASK 26
-- Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.

USE TelerikAcademy
SELECT d.Name, e.JobTitle, e.FirstName, e.LastName, e.Salary
FROM Employees e
JOIN Departments d
ON d.DepartmentID = e.DepartmentID
WHERE e.Salary IN (SELECT MIN(emp.Salary)
	FROM Employees emp
	JOIN Departments dep
	ON dep.DepartmentID = emp.DepartmentID
	WHERE d.DepartmentID = dep.DepartmentID AND e.JobTitle = emp.JobTitle
	GROUP BY dep.Name, emp.JobTitle
)
