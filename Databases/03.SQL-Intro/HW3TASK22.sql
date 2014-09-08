-- TASK 22
-- Write a SQL query to find all departments and all town names as a single list. Use UNION.

SELECT Name AS [New List Name] FROM Departments
UNION
SELECT Name AS [New List Name] FROM Towns