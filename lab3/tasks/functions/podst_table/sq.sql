use testdb
go

CREATE FUNCTION dbo.GetSommelierAveragePrice()
RETURNS TABLE AS RETURN
(
	SELECT TasterName, AVG(Price) AS AveragePrice FROM WINE AS W JOIN (SELECT WINE_ID, TasterName FROM WINE_SOMMELIER AS WS JOIN SOMMELIER AS S ON WS.SOMMELIER_ID = S.ID) AS WSS ON W.ID = WSS.WINE_ID GROUP BY TasterName
)
go

SELECT * FROM dbo.GetSommelierAveragePrice()
go

IF EXISTS (SELECT name FROM sysobjects WHERE name = 'GetSommelierAveragePrice')  
   DROP FUNCTION GetSommelierAveragePrice;  
go  
