USE testdb
GO

SELECT Title, SUM(Price) AS SP INTO #SumPrice FROM WINE WHERE Price > 5 GROUP BY Title

SELECT * FROM #SumPrice
GO
