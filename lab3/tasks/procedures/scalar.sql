USE testdb
GO

CREATE PROCEDURE AveragePrice
AS
BEGIN
	SELECT AVG(Price) FROM WINE
END
GO

EXEC AverageCountryPrice
