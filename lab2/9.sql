USE testdb
GO

SELECT Title, Variety, Country = CASE country when "Italy" then "IT" when "Portugal" then "PR" when "Spain" then "SP" when "France" then "FR" else "Another country" END FROM WINE JOIN COUNTRY ON WINE.Country_id = COUNTRY.ID

GO
