CREATE PROCEDURE [dbo].[PobierzPaczke]
	@Id VARCHAR(36),
	@Lokalizacja NCHAR(6) OUT,
	@Nadano DATETIME OUT,
	@Miasto VARCHAR(30) OUT,
	@KodPocztowy NCHAR(6) OUT,
	@Ulica VARCHAR(30) OUT,
	@Lokal VARCHAR(5) OUT,
	@Nadawca INT OUT,
	@Odbiorca INT OUT,
	@Dostarczona BIT OUT

AS
	IF EXISTS (SELECT * FROM Paczki WHERE Paczki.Id = @Id)
	
	SELECT @Lokalizacja = Paczki.Lokalizacja, @Nadano = Paczki.CzasNadania, @Miasto = Paczki.Miasto, @KodPocztowy = Paczki.KodPocztowy,
	@Ulica = Paczki.Ulica, @Lokal = Paczki.Lokal, @Nadawca = Paczki.Nadawca, @Odbiorca = Paczki.Odbiorca, @Dostarczona = Paczki.Dostarczona

	FROM Paczki
	WHERE Paczki.Id = @Id;

	
	