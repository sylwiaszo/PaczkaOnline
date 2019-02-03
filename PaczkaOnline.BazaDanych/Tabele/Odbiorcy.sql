CREATE TABLE [dbo].[Odbiorcy]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Imie] NCHAR(25) NOT NULL, 
    [Nazwisko] NCHAR(25) NOT NULL, 
    [Email] NCHAR(30) NOT NULL, 
    [Telefon] NCHAR(12) NOT NULL, 
)
