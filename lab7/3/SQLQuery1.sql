USE testdb
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.GetDiffAge(@FirstAge INT, @SecondAge INT, @ThirdParam AS INT OUTPUT) AS
BEGIN
    SET @ThirdParam = @FirstAge - @SecondAge
END
GO

--DROP PROCEDURE GetDiffAge
--GO
