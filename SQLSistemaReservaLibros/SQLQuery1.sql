IF OBJECT_ID('SP_ListBook') IS NOT NULL
	DROP PROC SP_ListBook
GO
CREATE PROC SP_ListBook
AS
	SELECT * FROM Books;
GO

IF OBJECT_ID('SP_InsertBook') IS NOT NULL
	DROP PROC SP_InsertBook
GO
CREATE PROC SP_InsertBook(@Title VARCHAR(50),@Code VARCHAR(50))
AS
INSERT INTO Books VALUES(@Title,@Code,'False',GETDATE(),NULL,NULL);
GO


IF OBJECT_ID('SP_InsertReservation') IS NOT NULL
	DROP PROC SP_InsertReservation
GO
CREATE PROC SP_InsertReservation(@IdUser INT, @IdBook INT)
AS
BEGIN
INSERT INTO Reservations VALUES(@IdUser,@IdBook,GETDATE());
UPDATE Books SET bitStatus = 'True' WHERE idBook = @IdBook;
END
GO

IF OBJECT_ID('SP_ValidateUser') IS NOT NULL
	DROP PROC SP_ValidateUser
GO
CREATE PROC SP_ValidateUser(@Correo VARCHAR(50), @Clave VARCHAR(50))
AS
BEGIN
	IF(EXISTS(SELECT * FROM Users WHERE varEmail = @Correo and varPassword = @Clave))
		SELECT idUser FROM Users WHERE varEmail = @Correo and varPassword = @Clave
	ELSE
		SELECT '0'
END
GO

IF OBJECT_ID('SP_SearchBook') IS NOT NULL
	DROP PROC SP_SearchBook
GO
CREATE PROC SP_SearchBook(@Letra VARCHAR(50))
AS
SELECT * FROM Books WHERE varCode LIKE '%' + @Letra + '%';
GO



EXEC SP_ValidateUser 'felipe@gmail.com', '123';
EXEC SP_InsertReservation '1','1';
EXEC SP_SearchBook 'pre';

SELECT * FROM Users;
SELECT * FROM Reservations;
DELETE FROM Reservations;