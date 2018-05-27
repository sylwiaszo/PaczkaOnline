CREATE PROCEDURE [dbo].[AktualizujLokalizacjePaczki]
    @Paczka UNIQUEIDENTIFIER,
	@Lokalizacja int
AS
	UPDATE [Paczki] SET [Lokalizacja] = @Lokalizacja WHERE [Id] = @Paczka
	
