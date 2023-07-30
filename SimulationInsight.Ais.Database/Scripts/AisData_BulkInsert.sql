USE Ais;

SET DATEFORMAT DMY;

BULK INSERT vwAisData
FROM 'C:\Temp\aisdk_20201101.csv'
WITH
(
    FIRSTROW        = 2,
    FIELDQUOTE      = '"',
    FIELDTERMINATOR = ',',
    ROWTERMINATOR   = '0x0a',
    TABLOCK
);