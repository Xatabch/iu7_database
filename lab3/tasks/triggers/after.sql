USE testdb
GO

CREATE TRIGGER Wine_INSERT
ON WINE
AFTER INSERT
AS
UPDATE WINE
SET Price = Price + Price * 0.38
WHERE Id = (SELECT Id FROM inserted)
GO

SELECT ID, Price FROM WINE WHERE Id > 99

INSERT INTO WINE Values(101, 'Title', 'Variety', 10, 10, 10)
GO

SELECT ID, Price FROM WINE WHERE Id > 99

DELETE WINE WHERE Id = 101
GO

DROP TRIGGER Wine_INSERT
GO
