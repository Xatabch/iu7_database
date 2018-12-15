USE testdb
GO

-- Объявляю сам XML документ
DECLARE @idoc int, @doc varchar(1000)
SET @doc='
<ROOT>
<WINE WineID="VINET" Title="TitleWine">
</WINE>
<WINE WineID="ATTR" Title="SeconTitle">
</WINE>
</ROOT>'

EXEC sp_xml_preparedocument @idoc OUTPUT, @doc
SELECT *
FROM OPENXML(@idoc, '/ROOT/WINE', 1) WITH (WineID varchar(10), Title varchar(20))
EXEC sp_xml_removedocument @idoc
GO
