USE triggerdb
GO

CREATE ASSEMBLY UserTrigger FROM '/home/ivan/db/lab4/trigger/trigger.dll'
GO

CREATE TRIGGER DropTrigger
ON DATABASE
FOR DROP_TABLE
AS
EXTERNAL NAME UserTrigger.CLRTriggers.DropTableTrigger
GO

CREATE TABLE TEST (id int, name varchar(200))
GO

DROP TABLE TEST
GO

DROP TRIGGER DropTrigger ON DATABASE
GO
DROP ASSEMBLY UserTrigger
GO
