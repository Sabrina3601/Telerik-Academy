-- TASK 2
-- Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.

USE TelerikAcademy
SELECT FirstName, LastName, Salary 
FROM Employees
WHERE Salary BETWEEN (SELECT MIN(Salary) FROM Employees) AND (SELECT MIN(Salary) FROM Employees) * 1.1
