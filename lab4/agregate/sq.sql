USE testdb
GO

CREATE ASSEMBLY MyAgg FROM '/home/ivan/db/lab4/agregate/agr.dll'
GO
CREATE AGGREGATE MyAgg (@input nvarchar(200)) RETURNS nvarchar(max)  
EXTERNAL NAME MyAgg.Concatenator; 
GO

SELECT Price, dbo.MyAgg(Title) FROM WINE GROUP BY Price HAVING Price = 15
GO

DROP AGGREGATE MyAgg 
GO
DROP ASSEMBLY MyAgg
GO

