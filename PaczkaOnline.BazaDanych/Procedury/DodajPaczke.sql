CREATE PROCEDURE [dbo].[DodajPaczke]
    @Nadawca INT, 
    @Odbiorca INT,
    @Miasto VARCHAR(30),
    @KodPocztowy NCHAR(6),
    @Ulica VARCHAR(30),
    @Lokal VARCHAR(5),
	@Id VARCHAR(36) OUT
AS
DECLARE @ID_GUID UNIQUEIDENTIFIER;
SET @ID_GUID = NEWID();
	
	INSERT INTO [Paczki] (Id, Nadawca, Odbiorca, CzasNadania, Miasto, KodPocztowy, Ulica, Lokal) 
	VALUES (@ID_GUID, @Nadawca, @Odbiorca, GETDATE(), @Miasto, @KodPocztowy, @Ulica, @Lokal)

	SET @Id = CONVERT(VARCHAR(36), @ID_GUID)
	