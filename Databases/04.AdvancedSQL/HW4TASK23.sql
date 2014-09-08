-- TASK 23
-- Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.

USE TelerikAcademy
UPDATE Users
SET Password = 'defaultpassword'
WHERE LastLoginTime <=
CAST('10.03.2010 00:00:00' AS smalldatetime)