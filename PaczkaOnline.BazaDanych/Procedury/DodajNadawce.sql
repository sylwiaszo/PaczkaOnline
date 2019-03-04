CREATE PROCEDURE [dbo].[DodajNadawce]
    @Email NCHAR(30), 
    @Telefon NCHAR(12),
    @IdNadawcy INT OUT 
AS

SET @IdNadawcy = (SELECT Id FROM [Nadawcy] WHERE Email = @Email and Telefon = @Telefon);

IF (@IdNadawcy IS NOT NULL)
	RETURN @IdNadawcy;
ELSE
	INSERT INTO [Nadawcy] (Email, Telefon) VALUES (@Email, @Telefon);
	SET @IdNadawcy = SCOPE_IDENTITY();
	RETURN SCOPE_IDENTITY()
	
