USE testdb
GO

DECLARE @idoc int
DECLARE @doc xml
SELECT @doc = c FROM OPENROWSET(BULK '/home/ivan/db/lab5/tasks/2/file.xml', SINGLE_BLOB) AS TEMP(c)
EXEC sp_xml_preparedocument @idoc OUTPUT, @doc
SELECT *
FROM OPENXML (@idoc, '/root/WINE')
WITH (ID INT,
      Title NVARCHAR(50),
      Country_id INT)
EXEC sp_xml_removedocument @idoc
