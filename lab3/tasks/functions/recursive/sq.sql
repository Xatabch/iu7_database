USE testdb
GO

CREATE FUNCTION ProcRecursion(@Max INT)
RETURNS TABLE AS RETURN
(
        WITH CTE(Price, Title)
        AS
        (
                SELECT 1 AS Price, Title FROM WINE WHERE Price = 1
                UNION ALL
                SELECT Price + 1, Title FROM WINE  WHERE Price < @Max
        )
	SELECT Price, Title FROM CTE
)
GO
Select * from ProcRecursion(30) ORDER BY Price
go

DROP FUNCTION ProcRecursion
GO
