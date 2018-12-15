DROP table Table1
drop table Table2

CREATE TABLE Table1 (
    id INT, 
    var1 NVARCHAR(25),
    valid_from_dttm DATE, 
    valid_to_dttm DATE
);

CREATE TABLE Table2 (
    id INT, 
    var2 NVARCHAR(25),
    valid_from_dttm DATE, 
    valid_to_dttm DATE
);

-- INSERT INTO Table1 VALUES (1,'A','2018-09-01','2018-09-15')
-- INSERT INTO Table1 VALUES (1,'B','2018-09-16','5999-12-31')
-- INSERT INTO Table2 VALUES (1,'C','2018-09-01','2018-09-18')
-- INSERT INTO Table2 VALUES (1,'A','2018-09-19','5999-12-31')


INSERT INTO Table1 VALUES (1,'A','2018-01-01','2018-01-08')
INSERT INTO Table1 VALUES (1,'B','2018-01-09','2018-01-13')
INSERT INTO Table1 VALUES (1,'C','2018-01-14','2018-01-17')
INSERT INTO Table1 VALUES (1,'D','2018-01-18','5999-01-01')
INSERT INTO Table1 VALUES (2,'A','2018-01-01','5999-01-01')


INSERT INTO Table2 VALUES (1,'A','2018-01-01','2018-01-05')
INSERT INTO Table2 VALUES (1,'B','2018-01-06','2018-01-13')
INSERT INTO Table2 VALUES (1,'C','2018-01-14','2018-01-16')
INSERT INTO Table2 VALUES (1,'D','2018-01-17','5999-01-01')
INSERT INTO Table2 VALUES (2,'A','2018-01-01','5999-01-01')


SELECT * FROM Table1
SELECT * FROM Table2

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
WHERE valid_to_dttm >= valid_from_dttm
