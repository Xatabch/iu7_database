USE testdb
GO

CREATE PROCEDURE ProcRecursion
AS
BEGIN
	WITH CTE(Price, Title)
	AS
	(
        	SELECT 1 AS Price, Title FROM WINE WHERE Price = 1
        	UNION ALL
        	SELECT Price + 1, Title FROM WINE  WHERE Price < 15
	)
	SELECT Price, Title FROM CTE ORDER BY Price
END
GO

EXEC ProcRecursion
GO

DROP PROCEDURE ProcRecursion
GO
