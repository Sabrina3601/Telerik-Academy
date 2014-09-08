-- TASK 21
-- Write SQL statements to delete some of the records from the Users and Groups tables.

DELETE 
FROM Users
WHERE Username = 'OrangeFlysLeader'

--DELETE 
--FROM Groups
--WHERE GroupName='Santa Gorgia'
-- This deletion creates conflicts due to reference relations.