CREATE TABLE [dbo].[Trasy]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Paczka] UNIQUEIDENTIFIER NOT NULL, 
    [Polaczenie] INT NOT NULL, 
    CONSTRAINT [FK_Trasy_Paczki] FOREIGN KEY ([Paczka]) REFERENCES [Paczki]([Id]),
	CONSTRAINT [FK_Trasy_Polaczenia] FOREIGN KEY ([Polaczenie]) REFERENCES [Polaczenia]([Id]),
)
