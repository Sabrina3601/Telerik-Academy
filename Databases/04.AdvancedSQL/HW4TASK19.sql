-- TASK 19
-- Write SQL statements to insert several records in the Users and Groups tables.

INSERT INTO Users (Username, Password, FullName, LastLoginTime, GroupID)
VALUES
('Pontiac', '2590801480', 'Dimitar Petkov', GETDATE(), '3'),
('Mercedes', '96968520', 'Nikolay Koshnicharov', GETDATE(), '1'),
('SPDpilot', '123606090', 'Georgi Nikolov', GETDATE(), '1'),
('OrangeFlysLeader', '353520104070', 'Martin Drandarov', GETDATE(), '3'),
('TigerWolf', '958575654030', 'Kostadin Marinov', GETDATE(), '2');

INSERT INTO Groups (GroupName)
VALUES
('Marina Cantona'),
('Santa Gorgia'),
('Pirinski Voini');
