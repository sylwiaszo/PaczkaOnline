CREATE PROCEDURE [dbo].[PobierzLokalizacje]
	@KodPocztowy CHAR(6),
	@Miasto VARCHAR(30) OUT,
	@Wojewodztwo VARCHAR(20) OUT,
	@Adres VARCHAR(100) OUT

AS
	SELECT @Miasto = Lokalizacje.Miasto, @Wojewodztwo = Lokalizacje.Wojewodztwo,
	@Adres = Lokalizacje.Adres 
	FROM Lokalizacje
	WHERE KodPocztowy = @KodPocztowy;

	
	