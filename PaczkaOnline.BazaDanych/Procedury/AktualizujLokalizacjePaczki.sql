CREATE PROCEDURE [dbo].[AktualizujLokalizacjePaczki]
    @Paczka UNIQUEIDENTIFIER,
	@Lokalizacja NCHAR(6)
AS
	UPDATE [Paczki] SET [Lokalizacja] = @Lokalizacja WHERE [Id] = @Paczka
	
