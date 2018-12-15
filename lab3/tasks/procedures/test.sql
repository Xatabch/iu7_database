use testdb
go

with cte(Price, Title)
AS
(
	Select 1 AS Price, Title FROM WINE WHERE Price = 1
	UNION ALL
	SELECT Price + 1, Title FROM WINE  WHERE Price < 15
)
Select Price, Title FROM CTE ORDER BY Price
GO
