USE testdb
GO

CREATE TABLE Table1 (
    id INT, 
    var1 NVARCHAR(25),
    valid_from_dttm DATE, 
    valid_to_dttm DATE
);
GO

CREATE TABLE Table2 (
    id INT, 
    var2 NVARCHAR(25),
    valid_from_dttm DATE, 
    valid_to_dttm DATE
);
GO

INSERT INTO Table1 VALUES (1,'A','2018-09-01','2018-09-15')
INSERT INTO Table1 VALUES (1,'B','2018-09-16','2018-09-30')
INSERT INTO Table1 VALUES (1,'C','2018-10-01','2018-10-10')
INSERT INTO Table2 VALUES (1,'A','2018-09-01','2018-09-18')
INSERT INTO Table2 VALUES (1,'B','2018-09-19','2018-09-23')
INSERT INTO Table2 VALUES (1,'C','2018-09-24','2018-09-28')
INSERT INTO Table2 VALUES (1,'D','2018-09-29','2018-10-10')
GO

SELECT * FROM Table1
SELECT * FROM Table2
GO

SELECT * FROM (
    SELECT T1.id AS id, T1.var1 AS var1, T2.var2 AS var2,
        CASE
            WHEN T1.valid_from_dttm > T2.valid_from_dttm THEN T1.valid_from_dttm
            ELSE T2.valid_from_dttm 
        END AS valid_from_dttm,
        CASE WHEN T1.valid_to_dttm < T2.valid_to_dttm THEN T1.valid_to_dttm
            ELSE T2.valid_to_dttm
        END AS valid_to_dttm
    FROM Table1 T1 FULL OUTER JOIN Table2 T2 ON T1.id = T2.id
) AS Result
WHERE valid_to_dttm > valid_from_dttm

DELETE FROM Table1
DELETE FROM Table2
GO
