-- TASK 31
-- Start a database transaction and drop the  EmployeesProjects. Now how you could restore back the lost table data?

BEGIN TRAN
DROP TABLE EmployeesProjects
ROLLBACK TRAN