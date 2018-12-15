-- Использование FOR XML EXPLICIT
-- EXPLICIT предоставляет более гибкую работу при формировании XML документа
USE testdb
GO

SELECT 1 as Tag,
	NULL as Parent,
	W.ID as [WINE!1!WineID],
	NULL as [Title!2!WineTitle],
	NULL as [Title!2!WineVariety]
FROM WINE AS W
WHERE W.ID = 1
UNION ALL
SELECT 2 as Tag,
	1 as Parent,
	W.ID,
	W.Title,
	W.Variety
FROM WINE AS W
WHERE ID = 2
FOR XML EXPLICIT
GO
