-- TASK 17
-- Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint). Define primary key and identity column.

CREATE TABLE Groups (
GroupID int IDENTITY,
GroupName nvarchar(30) NOT NULL,
CONSTRAINT PK_Groups PRIMARY KEY(GroupID),
CONSTRAINT AK_Groups UNIQUE(GroupName)
)
GO