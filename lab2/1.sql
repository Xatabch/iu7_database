USE testdb
GO

SELECT ALL P1.Country, P2.Title FROM COUNTRY P1 JOIN WINE AS P2 ON P2.Country_id = P1.ID WHERE P1.Country = 'Portugal' ORDER BY P1.Country, P2.Title

GO
