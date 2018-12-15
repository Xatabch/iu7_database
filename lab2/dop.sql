USE testdb
GO

WITH CTE_TABLE1 (id, var1, vfd)
AS
(
	SELECT DISTINCT id, var1, valid_from_dttm AS vfd FROM table1
	UNION ALL
	SELECT id, var2, valid_from_dttm AS vfd FROM table2 
)
SELECT * INTO #firstTable FROM CTE_TABLE1
GO

WITH CTE_TABLE2 (id, var2, vtd)
AS
(
	SELECT DISTINCT id, var1, valid_to_dttm AS vtd FROM table1
	UNION ALL
	SELECT id, var2, valid_to_dttm AS vtd FROM table2
)
SELECT * INTO #secondTable FROM CTE_TABLE2
GO

SELECT * from #firstTable
SELECT * from #secondTable
GO

/*        SELECT DISTINCT ROW_NUMBER() OVER(PARTITION BY id ORDER BY id) i, id, var1, vfd AS valid_from_dttm FROM #firstTable
        WHERE EXISTS
        (
                SELECT DISTINCT ROW_NUMBER() 
                OVER
                (
                        PARTITION BY f.vfd ORDER BY f.vfd
                ) i, f.vfd  
                FROM #firstTable AS f
        )

*/

SELECT * FROM #firstTable T1 LEFT OUTER JOIN #secondTable T2 ON T1.id = T2.id WHERE vtd >= vfd
GO

/*SELECT st.id, var1, var2, valid_from_dttm, valid_to_dttm FROM 
(
	SELECT DISTINCT ROW_NUMBER() OVER(PARTITION BY id ORDER BY id) i, id, var1, vfd AS valid_from_dttm FROM #firstTable
	WHERE EXISTS
	(
		SELECT DISTINCT ROW_NUMBER() 
		OVER
		(
			PARTITION BY f.vfd ORDER BY f.vfd
		) i, f.vfd  
		FROM #firstTable AS f
	)
) AS ft 
JOIN 
(
	SELECT DISTINCT ROW_NUMBER() OVER(PARTITION BY id ORDER BY id) i, id, var2, vtd AS valid_to_dttm FROM #secondTable 
	WHERE EXISTS
	(
		SELECT DISTINCT ROW_NUMBER() 
		OVER
		(
			PARTITION BY s.vtd ORDER BY s.vtd
		) i, s.vtd FROM #secondTable AS s
	)
) AS st ON ft.i=st.i
GO

select distinct row_number() over(partition by id order by id) i, id, var1, vfd from #firstTable where EXISTS(select distinct row_number() over(partition by f.vfd order by f.vfd) i, f.vfd from #firstTable as f )
go*/

/*SELECT id, var1, var2, valid_from_dttm, valid_to_dttm 
FROM (SELECT DISTINCT f.vfd as valid_from_dttm, ROW_NUMBER() OVER(PARTITION BY f.id ORDER BY f.id, f.vfd) i, f.id AS id, var1 FROM #firstTable AS f) AS ft 
JOIN (SELECT DISTINCT vtd as valid_to_dttm, ROW_NUMBER() OVER(PARTITION BY s.id ORDER BY s.id, s.vtd) i, var2 
FROM #secondTable AS s) AS st ON ft.i=st.i
GO*/
