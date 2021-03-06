﻿CREATE TABLE [dbo].[Paczki]
(
    [Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(), 
    [Nadawca] INT NOT NULL, 
    [Odbiorca] INT NOT NULL, 
	[Miasto] VARCHAR(30) NOT NULL,
	[KodPocztowy] NCHAR(6) NOT NULL,
	[Ulica] VARCHAR(30) NOT NULL,
	[Lokal] VARCHAR(5) NULL,
    [Lokalizacja] NCHAR(6) NOT NULL DEFAULT 00-000, 
    [CzasNadania] DATETIME NOT NULL, 
    [Dostarczona] BIT NULL DEFAULT 0, 
    [CzasDostarczenia] DATETIME NULL, 
    CONSTRAINT [PK_Paczki] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Paczki_Nadawcy] FOREIGN KEY ([Nadawca]) REFERENCES [Nadawcy]([Id]),
	CONSTRAINT [FK_Paczki_Odbiorcy] FOREIGN KEY ([Odbiorca]) REFERENCES [Odbiorcy]([Id])
)
