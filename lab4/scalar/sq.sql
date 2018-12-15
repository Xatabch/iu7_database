use scalar
go

create assembly UDF from '/home/ivan/db/lab4/scalar/scalar.dll'
GO

CREATE FUNCTION GetRandomNumber(@min int, @max int)
RETURNS int
AS
EXTERNAL NAME UDF.[HandWrittenUDF.RandomRange].GetRandomFromGap
GO

SELECT dbo.GetRandomNumber(1,20) AS Random
GO

DROP FUNCTION GetRandomNumber
GO

DROP ASSEMBLY UDF
GO
