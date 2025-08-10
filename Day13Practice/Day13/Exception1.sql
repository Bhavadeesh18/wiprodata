Create proc prcDivision 
	@a INT,
	@b INT
AS
BEGIN
	BEGIN TRY
		Set @a = 5;
		Set @b = @a / 0
		Print @b 
	END TRY
	BEGIN CATCH
		Print 'Error is '
		Print ERROR_MESSAGE()
	END CATCH
END
GO

Exec prcDivision 12,0
GO

CREATE PROC prcEvenChek
    @n INT
AS
BEGIN
    DECLARE @res INT
    BEGIN TRY
        SET @res = @n % 2;

        IF @res = 0
        BEGIN
            PRINT 'NO ERROR';
            PRINT 'Even Number';
        END
        ELSE
        BEGIN
            PRINT 'Error Occurred';
            THROW 70000, 'Error occurred', 1;
        END
    END TRY
    BEGIN CATCH
        PRINT ERROR_MESSAGE();
    END CATCH
END;
