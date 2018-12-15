USE testdb
GO

WITH Name(ID, Title)
AS
(
	SELECT 1 AS ID, Title
	FROM WINE WHERE ID = 1
	UNION ALL
	SELECT t1.ID + 1, t1.Title
	FROM WINE AS t1-- JOIN Name t2 ON t1.ID = t2.ID
	WHERE t1.ID < 20
)
SELECT ID, Title FROM Name
--OPTION (MAXRECURSION 7)

GO
