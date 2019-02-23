CREATE PROCEDURE [dbo].[AktualizujStatusPaczki]
    @Paczka UNIQUEIDENTIFIER,
	@Dostarczona bit
AS
	UPDATE [Paczki] SET [Dostarczona] = @Dostarczona, [CzasDostarczenia] = GETDATE() WHERE [Id] = @Paczka
	
