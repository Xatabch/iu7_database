USE testdb
GO

-- Например рассмотрим применение PATH со столбцами без имени
-- Т.е. мы не присвиваем какое-либо имя для наших атрибутов
SELECT ID, Title
FROM WINE
WHERE ID = 5
FOR XML PATH
GO

-- Для того, чтобы задать столбцу имя, нужно использовать символ @
SELECT ID as "@WineID",
	Title as "@WineTitle"
FROM WINE
WHERE ID = 5
FOR XML PATH
GO
