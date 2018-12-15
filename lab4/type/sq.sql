USE testdb
GO

CREATE ASSEMBLY UserType FROM '/home/ivan/db/lab4/type/tt.dll'
GO

CREATE TYPE dbo.Email EXTERNAL NAME UserType.Email
GO

CREATE TABLE dbo.TestTable(
                id int,
                mail dbo.Email)
GO

INSERT INTO dbo.TestTable (id,mail) VALUES (1,'ivan.morozov@list.ru')
GO

SELECT id, CAST(mail AS nvarchar(max)) mail FROM TestTable WHERE CAST(mail AS nvarchar(max)) ='ivan.morozov@list.ru'

DROP TABLE TestTable
GO

DROP TYPE dbo.Email
GO

DROP ASSEMBLY UserType
GO
