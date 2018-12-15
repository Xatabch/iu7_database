use testdb
go

create assembly MyProc from '/home/ivan/db/lab4/procedure/proc.dll'
GO

create procedure GetAvgPrice(@Price INT) AS EXTERNAL NAME MyProc.[MyClass].GetAvgPrice
GO

exec GetAvgPrice 15
GO

DROP PROCEDURE GetAvgPrice
GO
DROP assembly MyProc
GO
