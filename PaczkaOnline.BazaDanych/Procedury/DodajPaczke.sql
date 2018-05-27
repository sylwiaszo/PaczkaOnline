CREATE PROCEDURE [dbo].[DodajPaczke]
    @Nadawca INT, 
    @Odbiorca INT, 
    @Trasa INT, 
    @Lokalizacja INT, 
    @CzasNadania DATETIME,
	@Id UNIQUEIDENTIFIER
AS
	SET @ID = NEWID()
	INSERT INTO [Paczki] VALUES (@ID, @Nadawca, @Odbiorca, @Trasa, @Lokalizacja, GETDATE(), 0)
	
	RETURN @ID