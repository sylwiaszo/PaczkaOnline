CREATE TABLE [dbo].[Lokalizacje]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[KodPocztowy] NCHAR(8) NOT NULL, 
    [Adres] NCHAR(300) NOT NULL, 
    [Miasto] NCHAR(100) NOT NULL, 
    [Wojewodztwo] NCHAR(100) NOT NULL, 
    [Powiat] NCHAR(100) NOT NULL, 
)
