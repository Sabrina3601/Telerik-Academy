-- TASK 20
-- Write SQL statements to update some of the records in the Users and Groups tables.

UPDATE Users
SET FullName = 'Dimitar Petkanov'
WHERE Username = 'Pontiac'

UPDATE Groups
SET GroupName = 'Santa ' + GroupName
WHERE GroupName LIKE 'Marina%'