USE testdb
GO

SELECT ALL Title, Description FROM DESCRIPTION JOIN WINE ON WINE.Description_id = DESCRIPTION.ID WHERE Description LIKE "%fresh%"

GO
