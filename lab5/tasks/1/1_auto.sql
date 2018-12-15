-- В режиме AUTO результаты запросов возвращаются в виде вложенных XML-элементов

USE testdb
GO

SELECT COUNTRY.ID, Title, Country_id
FROM WINE JOIN COUNTRY ON WINE.Country_id = COUNTRY.ID
FOR XML AUTO
GO
