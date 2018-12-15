USE testdb
GO

SELECT ID, Description, (SELECT MAX(Price) FROM [WINE] WHERE Country_id BETWEEN 4 AND 8 ) AS MaxPrice, (SELECT MIN(Price) FROM [WINE] WHERE Country_id BETWEEN 4 AND 8) AS MinPrice FROM DESCRIPTION WHERE Description LIKE "%fresh%"
GO
