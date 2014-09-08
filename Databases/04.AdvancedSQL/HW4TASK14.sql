-- TASK 14
-- Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds". Search in Google to find how to format dates in SQL Server.

-- 4 ALTERNATIVES:

USE TelerikAcademy
SELECT CONVERT(VARCHAR(24), GETDATE(), 113)

SELECT CONVERT(VARCHAR(25), GETDATE(), 131)

SELECT CONVERT(VARCHAR(23), GETDATE(), 121)

SELECT FORMAT(GETDATE(), 'dd.mm.yyyy hh:mm:ss:fff')