CREATE TABLE [dbo].[Nadawcy]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Imie] NCHAR(25) NOT NULL, 
    [Nazwisko] NCHAR(25) NOT NULL, 
    [Email] NCHAR(30) NOT NULL, 
    [Telefon] NCHAR(12) NULL, 
    [Miasto] NCHAR(30) NOT NULL, 
    [KodPocztowy] NCHAR(6) NOT NULL, 
    [Ulica] NCHAR(50) NOT NULL, 
    [NumerLokalu] NCHAR(8) NULL
)
