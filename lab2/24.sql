USE testdb

/*Make separate table by join of WINE AND WINE_SOMMELIER*/
SELECT * into #Taster from wine join (select WINE_ID, TasterName from WINE_SOMMELIER JOIN SOMMELIER ON WINE_SOMMELIER.SOMMELIER_ID = SOMMELIER.ID) as SP on wine.id = sp.WINE_ID
GO

SELECT TasterName, AVG(Price) OVER(PARTITION BY TasterName) AS AvgPrice into #Test FROM #Taster
GO

SELECT TasterName, Count(AvgPrice) from #Test group by TasterName

GO
