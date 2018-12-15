USE testdb
GO

INSERT WINE(Id, Title, Variety, Price, Country_id, Description_id) VALUES('101', 'Acrobat 2013 Pinot Noir (Oregon)', 'Pinot Noire', '40','1', NULL)
GO

SELECT * FROM WINE
GO
