USE testdb
GO

SELECT AVG(TotalPrice) AS 'Actual AVG', SUM(TotalPrice) / COUNT(ID) AS 'Calc AVG' 
FROM ( SELECT ID, SUM(Price) AS TotalPrice FROM [WINE] GROUP BY ID 
) AS TotOrders

GO
