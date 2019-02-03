CREATE PROCEDURE [dbo].[DodajPaczke]
    @Nadawca INT, 
    @Odbiorca INT,
	@Id UNIQUEIDENTIFIER OUT
AS
	SET @Id = NEWID()
	INSERT INTO [Paczki] (Id, Nadawca, Odbiorca, CzasNadania) VALUES (@Id, @Nadawca, @Odbiorca, GETDATE())
	