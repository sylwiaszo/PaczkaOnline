CREATE PROCEDURE [dbo].[GenerujTrasePaczki]
    @Paczka UNIQUEIDENTIFIER,
	@Nadawca INT,
	@Odbiroca INT,
	@Start INT,
	@Koniec INT 
AS
	SET @Nadawca = (SELECT [Nadawca] FROM [Paczki] WHERE [Id] = @Paczka)
	SET @Odbiroca = (SELECT [Odbiorca] FROM [Paczki] WHERE [Id] = @Paczka)
	SET @Start = (SELECT [Miasto] FROM [Nadawcy] WHERE [Id] = @Nadawca)
	SET @Koniec = (SELECT [Miasto] FROM [Odbiorcy] WHERE [Id] = @Nadawca)



	
