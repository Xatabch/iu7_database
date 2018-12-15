-- Выводит сведения о модели продукта
-- Ссылка на повторить https://docs.microsoft.com/ru-ru/sql/relational-databases/xml/example-retrieving-product-model-information-as-xml?view=sql-server-2017

USE testdb
GO

-- ELEMENTS - получение данных по элементам
SELECT Title, Price
FROM WINE
WHERE ID > 80
FOR XML RAW
GO
