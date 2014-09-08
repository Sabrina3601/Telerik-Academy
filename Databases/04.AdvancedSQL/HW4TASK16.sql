-- TASK 16
-- Write a SQL statement to create a view that displays the users from the Users table that have been in the system today. Test if the view works correctly.

CREATE VIEW [Today's Users] AS
SELECT *
FROM dbo.Users
WHERE DAY(LastLoginTime) = DAY(GETDATE())