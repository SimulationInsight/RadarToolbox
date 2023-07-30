USE Ais;

DROP VIEW IF EXISTS vwAisData;
GO

CREATE VIEW vwAisData AS
SELECT 
    TimeStamp,
    TypeOfMobile,
    MMSI,
    Latitude,
    Longitude,
    NavigationalStatus,
    RateOfTurn,
    SpeedOverGround,
    CourseOverGround,
    Heading,
    IMO,
    Callsign,
    Name,
    ShipType,
    CargoType,
    Width,
    Length,
    TypeOfPositionFixingDevice,
    Draught,
    Destination,
    ETA,
    DataSourceType,
    SizeA,
    SizeB,
    SizeC,
    SizeD
FROM AisData;