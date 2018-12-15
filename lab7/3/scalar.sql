USE testdb
GO

--IF OBJECT_ID ( N'dbo.AveragePrice', 'P' ) IS NOT NULL
--      DROP PROCEDURE dbo.AveragePrice
--GO

CREATE PROCEDURE AveragePrice
AS
BEGIN	
	RETURN(SELECT AVG(Price) FROM WINE) 
END
GO

EXEC AveragePrice 
