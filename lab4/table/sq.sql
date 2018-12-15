use testdb
go
IF EXISTS (SELECT name FROM sysobjects WHERE name = 'FindInvalidTwitters')  
   DROP FUNCTION FindInvalidTwitters;  
go  

IF EXISTS (SELECT name FROM sys.assemblies WHERE name = 'MyClrCode')  
   DROP ASSEMBLY MyClrCode;  
go  

CREATE ASSEMBLY MyClrCode FROM '/home/ivan/db/lab4/table/podst_table.dll'  
WITH PERMISSION_SET = SAFE -- EXTERNAL_ACCESS;  
GO  

CREATE FUNCTION FindInvalidTwitters()   
RETURNS TABLE (  
   ID INT,
   TasterName nvarchar(200),
   Twitter nvarchar(200)    
)  
AS EXTERNAL NAME MyClrCode.UserDefinedFunctions.[FindInvalidTwitter];  
go  

SELECT * FROM FindInvalidTwitters();  
go  
