CREATE TABLE [dbo].[Paczki]
(
    [Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(), 
    [Nadawca] INT NOT NULL, 
    [Odbiorca] INT NOT NULL, 
    [Lokalizacja] NCHAR(6) NULL DEFAULT 00-000, 
    [CzasNadania] DATETIME NOT NULL, 
    [Dostarczona] BIT NULL DEFAULT 0, 
    CONSTRAINT [PK_Paczki] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Paczki_Nadawcy] FOREIGN KEY ([Nadawca]) REFERENCES [Nadawcy]([Id]),
	CONSTRAINT [FK_Paczki_Odbiorcy] FOREIGN KEY ([Odbiorca]) REFERENCES [Odbiorcy]([Id])
)
