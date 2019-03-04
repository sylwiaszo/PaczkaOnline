CREATE PROCEDURE [dbo].[GenerujStatystyki]
	@WyslanoPaczek INT OUT, 
        @PaczekWDrodze INT OUT, 
        @Dostarczono INT OUT, 
        @DostarczonoProcent INT OUT, 
        @SredniCzasDostarczenia INT OUT
AS
	SET @WyslanoPaczek = (SELECT COUNT(*) FROM Paczki);
	SET @PaczekWDrodze = (SELECT COUNT(*) FROM Paczki WHERE Paczki.Dostarczona = 0);
	SET @Dostarczono = (SELECT COUNT(*) FROM Paczki WHERE Paczki.Dostarczona = 1);

	IF (@Dostarczono = 0)
		SET @DostarczonoProcent = 0;
	ELSE
		SET @DostarczonoProcent = (@PaczekWDrodze / @Dostarczono / 100);

	IF (@Dostarczono = 0)
		SET @SredniCzasDostarczenia = 0
	ELSE
		SET @SredniCzasDostarczenia = ((SELECT SUM(DATEDIFF(HOUR, CzasDostarczenia, CzasNadania)) FROM Paczki WHERE Paczki.Dostarczona = 1) / @Dostarczono);
		
		
	

	
