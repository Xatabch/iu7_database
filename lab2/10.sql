USE testdb
GO

SELECT Title, Variety, "PriceRange" = CASE when Price < 5 then "Cheap" when Price > 5 and Price < 12 then "Not expensive" when Price > 12 then "Expencive" else "Very expensive" END from WINE

GO
