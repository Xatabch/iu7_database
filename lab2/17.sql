USE testdb
GO

INSERT [WINE] (Id, Title, Variety, Price, COuntry_id, Description_id) SELECT 102,Title,Variety,(SELECT MAX(Price) FROM WINE WHERE Price > 25 AND Price < 70), 6, NULL FROM WINE WHERE Title='Henry Fessy 2015  Régnié'
GO

SELECT * FROM WINE
GO
