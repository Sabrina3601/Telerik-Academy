-- TASK 30
-- Start a database transaction, delete all employees from the 'Sales' department along with all
-- dependent records from the other tables. At the end rollback the transaction.

BEGIN TRAN
DELETE FROM Employees
SELECT d.Name
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
GROUP BY d.Name
ROLLBACK TRAN
