----1. Create a database with two tables:
--Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance).
--Insert few records for testing. Write a stored procedure that selects the full names of all persons.
CREATE DATABASE BankAccount
GO
 
USE BankAccount
CREATE TABLE Persons (
  PersonID INT IDENTITY,
  FirstName nvarchar(100) NOT NULL,
  LastName nvarchar(100) NOT NULL,
  SSN INT NOT NULL
  CONSTRAINT PK_PersonID PRIMARY KEY(PersonID),
)
GO
CREATE TABLE Accounts (
  AccountID INT IDENTITY,
  Balance money DEFAULT 0,
  PersonId INT NULL
  CONSTRAINT PK_AccountID PRIMARY KEY(AccountID),
  CONSTRAINT FK_Accounts_Persons
  FOREIGN KEY (PersonId)
  REFERENCES Persons(PersonId)
)
GO
 
INSERT INTO Persons(FirstName, LastName, SSN)
VALUES ('Milcho', 'Ivanov', 41223234)
INSERT INTO Persons(FirstName, LastName, SSN)
VALUES ('Penyo', 'Todorov', 42342345)
INSERT INTO Persons(FirstName, LastName, SSN)
VALUES ('Angel', 'Petkov', 36346456)
INSERT INTO Persons(FirstName, LastName, SSN)
VALUES ('Milka', 'Muncheva', 3123123)
INSERT INTO Accounts(Balance, PersonId)
VALUES (200, 2)
INSERT INTO Accounts(Balance, PersonId)
VALUES (300, 3)
INSERT INTO Accounts(Balance, PersonId)
VALUES (400, 4)
GO
 
CREATE PROC dbo.usp_SelectFullNames
AS
  SELECT  concat(FirstName, ' ', LastName) AS [FULL Name]
  FROM Persons
GO
 
EXEC usp_SelectFullNames
GO
 
-- Create a stored procedure that accepts a number as a parameter and returns
--all persons who have more money in their accounts than the supplied number.
CREATE PROC dbo.usp_SelectPersonMoreMoney (@moneybalance money)
AS
  SELECT  concat(FirstName, ' ', LastName) AS [FULL Name], acc.Balance
  FROM Persons p
  JOIN Accounts acc
  ON acc.PersonId = p.PersonID
  WHERE acc.Balance > @moneybalance
  ORDER BY acc.Balance
GO
 
--DROP PROC dbo.usp_SelectPersonMoreMoney
 
EXEC usp_SelectPersonMoreMoney 200
GO
 
----3. Create a function that accepts as parameters – sum, yearly interest rate and number of months.
--It should calculate and return the new sum. Write a SELECT to test whether the function works as expected.
CREATE FUNCTION ufn_CalcInterest(@SUM money, @yearlyInterest NUMERIC(18, 2), @months INT)
  RETURNS NUMERIC(18, 2)
AS
BEGIN
  RETURN (@yearlyInterest / 12) * @months * @SUM + @SUM
END
GO
 
--drop function ufn_CalcInterest
 
SELECT dbo.ufn_CalcInterest(200, 0.2, 5)
GO
 
--4. Create a stored procedure that uses the function from the previous example
--to give an interest to a person's account for one month.
--It should take the AccountId and the interest rate as parameters.
CREATE PROC dbo.usp_CalculateInterest (@accountID INT, @yearlyInterest NUMERIC(18, 2))
AS
 UPDATE Accounts
 SET Balance = CONVERT (money,dbo.ufn_CalcInterest(Balance, @yearlyInterest, 1))
 WHERE AccountID = @accountID
GO
 
EXEC dbo.usp_CalculateInterest 2,0.2
GO
 
--5. Add two more stored procedures WithdrawMoney( AccountId, money) and
--DepositMoney (AccountId, money) that operate in transactions.
CREATE PROC dbo.usp_WithdrawMoney (@accountID INT, @money money)
AS
BEGIN TRAN
 UPDATE Accounts
 SET Balance = Balance - @money
 WHERE AccountID = @accountID
COMMIT TRAN
GO
 
--drop proc dbo.usp_WithdrawMoney
 
CREATE PROC dbo.usp_DepositMoney (@accountID INT, @money money)
AS
BEGIN TRAN
 UPDATE Accounts
 SET Balance = Balance + @money
 WHERE AccountID = @accountID
 COMMIT TRAN
GO
 
EXEC dbo.usp_WithdrawMoney 2, 50
EXEC dbo.usp_WithdrawMoney 1, 50
EXEC dbo.usp_DepositMoney 1, 200
GO
 
--6.Create another table – Logs(LogID, AccountID, OldSum, NewSum).
--Add a trigger to the Accounts table that enters a new entry into
--the Logs table every time the sum on an account changes.
CREATE TABLE Logs (
  LogID INT IDENTITY,
  OldSum money NOT NULL,
  NewSum money NOT NULL,
  AccountID INT NOT NULL,
  CONSTRAINT PK_LogID PRIMARY KEY(LogID),
  CONSTRAINT FK_Logs_Accounts
  FOREIGN KEY (AccountID)
  REFERENCES Accounts(AccountID)
)
GO
 
CREATE TRIGGER tr_AccountsUpdate ON Accounts FOR UPDATE
AS
 
INSERT INTO Logs (OldSum, NewSum, AccountID)
SELECT d.Balance,
           i.Balance,
           d.AccountID
  FROM deleted AS d
  JOIN inserted AS i
    ON d.AccountID = i.AccountID
GO
 
EXEC dbo.usp_DepositMoney 1, 200
GO
 
--Task 7 (regularExpresions for SQL http://www.codeproject.com/Articles/42764/Regular-Expressions-in-MS-SQL-Server-2005-2008)
sp_configure 'clr enabled', 1
GO
RECONFIGURE
GO
 
USE TelerikAcademy
CREATE ASSEMBLY
--assembly name for references from SQL script
SqlRegularExpressions
-- assembly name and full path to assembly dll,
-- SqlRegularExpressions in this case
FROM 'D:\4. T-SQL\SqlRegularExpressions.dll'  --change path to dll
WITH PERMISSION_SET = SAFE
GO
--function signature
CREATE FUNCTION RegExpLike(@Text nvarchar(MAX), @Pattern nvarchar(255)) RETURNS BIT
--function external name
AS EXTERNAL NAME SqlRegularExpressions.SqlRegularExpressions.[LIKE]
 
GO
 
CREATE FUNCTION fn_RegularExpressionFind ( @regularExpression nvarchar(30) )
RETURNS TABLE
AS
RETURN SELECT Emp.FirstName,
           Emp.MiddleName,
           Emp.LastName,
           Towns.Name
  FROM Employees AS Emp
  JOIN Addresses AS Addr
    ON Emp.AddressID = Addr.AddressID
  JOIN Towns
    ON Addr.TownID = Towns.TownID
 WHERE 1 = dbo.RegExpLike(LOWER(Towns.Name), @regularExpression)
   AND (1 = dbo.RegExpLike(LOWER(Emp.FirstName), @regularExpression)
    OR 1 = dbo.RegExpLike(LOWER(ISNULL(Emp.MiddleName, '')), @regularExpression)
        OR 1 = dbo.RegExpLike(LOWER(Emp.LastName), @regularExpression))
GO
 
SELECT * FROM fn_RegularExpressionFind('^[oistmiahf]+$')
 
--Task 8
DECLARE empCursor CURSOR READ_ONLY FOR
 
SELECT a.FirstName, a.LastName, t1.Name, b.FirstName, b.LastName
FROM Employees a
JOIN Addresses adr
ON a.AddressID = adr.AddressID
JOIN Towns t1
ON adr.TownID = t1.TownID,
 Employees b
JOIN Addresses ad
ON b.AddressID = ad.AddressID
JOIN Towns t2
ON ad.TownID = t2.TownID
WHERE t1.Name = t2.Name
  AND a.EmployeeID <> b.EmployeeID
ORDER BY a.FirstName, b.FirstName
 
OPEN empCursor
DECLARE @firstName1 NVARCHAR(50)
DECLARE @lastName1 NVARCHAR(50)
DECLARE @town NVARCHAR(50)
DECLARE @firstName2 NVARCHAR(50)
DECLARE @lastName2 NVARCHAR(50)
FETCH NEXT FROM empCursor
        INTO @firstName1, @lastName1, @town, @firstName2, @lastName2
 
WHILE @@FETCH_STATUS = 0
        BEGIN
                PRINT @firstName1 + ' ' + @lastName1 +
                        '     ' + @town + '      ' + @firstName2 + ' ' + @lastName2
                FETCH NEXT FROM empCursor
                        INTO @firstName1, @lastName1, @town, @firstName2, @lastName2
        END
 
CLOSE empCursor
DEALLOCATE empCursor
 
--Task 9
USE TelerikAcademy
DECLARE empCursor CURSOR READ_ONLY FOR
SELECT Name FROM Towns
OPEN empCursor
DECLARE @townName VARCHAR(50), @userNames VARCHAR(MAX)
FETCH NEXT FROM empCursor INTO @townName
 
 
WHILE @@FETCH_STATUS = 0
  BEGIN
                BEGIN
                DECLARE nameCursor CURSOR READ_ONLY FOR
                SELECT a.FirstName, a.LastName
                FROM Employees a
                JOIN Addresses adr
                ON a.AddressID = adr.AddressID
                JOIN Towns t1
                ON adr.TownID = t1.TownID
                WHERE t1.Name = @townName
                OPEN nameCursor
               
                DECLARE @firstName VARCHAR(50), @lastName VARCHAR(50)
                FETCH NEXT FROM nameCursor INTO @firstName,  @lastName
                WHILE @@FETCH_STATUS = 0
                        BEGIN
                                SET @userNames = CONCAT(@userNames, @firstName, ' ', @lastName, ', ')
                                FETCH NEXT FROM nameCursor
                                INTO @firstName,  @lastName
                        END
        CLOSE nameCursor
        DEALLOCATE nameCursor
                END
                SET @userNames = LEFT(@userNames, LEN(@userNames) - 1)
    PRINT @townName + ' -> ' + @userNames
    FETCH NEXT FROM empCursor
    INTO @townName
  END
CLOSE empCursor
DEALLOCATE empCursor
 
GO
 
--Task 10
--from http://www.mssqltips.com/sqlservertip/2022/concat-aggregates-sql-server-clr-function/ is describe it how to --make dll
--Check CLR Framework version if is not 2 rebiuld project from VS to your Framework and SQL version (mine is 2008 with framework 2.0)
--change it from properties in project Concatination
--select * from sys.dm_clr_properties
 
-- Remove the aggregate and assembly if they're there
 
IF OBJECT_ID('dbo.concat') IS NOT NULL DROP Aggregate concat
GO
 
IF EXISTS (SELECT * FROM sys.assemblies WHERE name = 'concat_assembly')
       DROP assembly concat_assembly;
GO    
 
CREATE Assembly concat_assembly
   AUTHORIZATION dbo
   FROM 'C:\Users\geri\Documents\SQL Server Management Studio\Projects\4. T-SQL\Concatination.dll'
   WITH PERMISSION_SET = SAFE;
GO
 
CREATE AGGREGATE dbo.concat (
 
    @VALUE NVARCHAR(MAX)
  , @Delimiter NVARCHAR(4000)
 
) RETURNS NVARCHAR(MAX)
EXTERNAL Name concat_assembly.concat;
GO
 
--If execution of user code in the .NET Framework is disabled
sp_configure 'clr enabled', 1
GO
RECONFIGURE
GO
 
SELECT dbo.concat(FirstName + ' ' +LastName,', ')
   FROM Employees
GO