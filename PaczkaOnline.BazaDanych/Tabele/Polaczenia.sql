CREATE TABLE [dbo].[Polaczenia]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [LokalizacjaPoczatkowa] NCHAR(6) NOT NULL, 
    [LokalizacjaKoncowa] NCHAR(6) NOT NULL, 
    CONSTRAINT [FK_Polaczenia_Lokalizacje_Poczatkowe] FOREIGN KEY ([LokalizacjaPoczatkowa]) REFERENCES [Lokalizacje]([KodPocztowy]),
	CONSTRAINT [FK_Polaczenia_Lokalizacje_Koncowe] FOREIGN KEY ([LokalizacjaKoncowa]) REFERENCES [Lokalizacje]([KodPocztowy]),
)
