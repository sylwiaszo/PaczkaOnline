﻿CREATE TABLE [dbo].[Nadawcy]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Email] NCHAR(30) NOT NULL, 
    [Telefon] NCHAR(12) NOT NULL
)
