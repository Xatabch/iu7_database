USE testdb
GO

/*Make separate table by join of WINE AND WINE_SOMMELIER*/
SELECT * into #Taster from wine join (select WINE_ID, TasterName from WINE_SOMMELIER JOIN SOMMELIER ON WINE_SOMMELIER.SOMMELIER_ID = SOMMELIER.ID) as SP on wine.id = sp.WINE_ID
SELECT ROW_NUMBER() OVER(ORDER BY TasterName) AS ID, TasterName, AVG(Price) OVER(PARTITION BY TasterName) AS AvgPrice, MIN(Price) OVER(PARTITION BY TasterName) AS MinPrice INTO #Filter from #Taster
SELECT * FROM #Filter
GO

/*Delete duplicates with ROW_NUMBER*/
WITH CTN AS
(
	SELECT ROW_NUMBER() OVER(PARTITION BY TasterName ORDER BY id) id, TasterName, AvgPrice, MinPrice from #Filter
)
DELETE FROM CTN WHERE id > 1
GO

SELECT * FROM #Filter
GO
