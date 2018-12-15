USE testdb
GO

SELECT Title, Variety, Price FROM WINE WHERE Country_id IN ( SELECT ID FROM COUNTRY WHERE Country="Portugal") AND Price BETWEEN 5 AND 20

GO
