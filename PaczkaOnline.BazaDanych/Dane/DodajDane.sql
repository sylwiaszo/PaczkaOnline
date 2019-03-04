 
BULK INSERT Lokalizacje
    FROM 'C:\Users\Sylwia\Desktop\PaczkaOnline\PaczkaOnline.BazaDanych\Dane\KodyPocztowe.csv'
    WITH
    (
	FIRSTROW = 2,
    FIELDTERMINATOR = ';',
    ROWTERMINATOR = '\n', 
    TABLOCK
    )