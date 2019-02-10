CREATE PROCEDURE [dbo].[PobierzPaczke]
	@Id VARCHAR(36),
	@Lokalizacja NCHAR(6) OUT,
	@Nadano DATETIME OUT,
	@Miasto VARCHAR(30) OUT,
	@KodPocztowy NCHAR(6) OUT,
	@Ulica VARCHAR(30) OUT,
	@Lokal VARCHAR(5) OUT

AS
	IF EXISTS (SELECT * FROM Paczki WHERE Paczki.Id = @id)
	
	SELECT @Lokalizacja = Paczki.Lokalizacja, @Nadano = Paczki.CzasNadania, @Miasto = Paczki.Miasto, @KodPocztowy = Paczki.KodPocztowy,
	@Ulica = Paczki.Ulica, @Lokal = Paczki.Lokal
	FROM Paczki
	WHERE Paczki.Id = @Id;

	ELSE
	SET @Lokalizacja = 'nn';

	
	