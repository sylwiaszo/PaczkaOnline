CREATE PROCEDURE [dbo].[DodajOdbiorce]
	@Imie NCHAR(25), 
    @Nazwisko NCHAR(25), 
    @Email NCHAR(30), 
    @Telefon NCHAR(12), 
    @Miasto NCHAR(30), 
    @KodPocztowy NCHAR(6), 
    @Ulica NCHAR(50), 
    @NumerLokalu NCHAR(8) NULL
AS
	INSERT INTO [Odbiorcy] VALUES (@Imie, @Nazwisko, @Email, @Telefon, @Miasto, @KodPocztowy, @Ulica, @NumerLokalu)
	
	RETURN SCOPE_IDENTITY()