CREATE PROCEDURE [dbo].[DodajOdbiorce]
	@Imie NCHAR(25), 
    @Nazwisko NCHAR(25), 
    @Email NCHAR(30), 
    @Telefon NCHAR(12),
    @idOdbiorcy INT OUT
AS
SET @idOdbiorcy = (SELECT Id FROM [Odbiorcy] WHERE Email = @Email and Telefon = @Telefon);

IF (@idOdbiorcy IS NOT NULL)
	RETURN @idOdbiorcy;
ELSE
	INSERT INTO [Odbiorcy] (Imie, Nazwisko, Email, Telefon) VALUES (@Imie, @Nazwisko, @Email, @Telefon)
	SET @idOdbiorcy = SCOPE_IDENTITY();

	RETURN SCOPE_IDENTITY()