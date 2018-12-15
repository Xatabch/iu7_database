USE testdb
GO

SELECT Title, AVG(Price) AS AveragePrice, MIN(Price) AS MinPrice FROM WINE GROUP BY Title

GO
