USE Ais;

DROP TABLE IF EXISTS AisData;

CREATE TABLE AisData (
    Id                         INT PRIMARY  KEY IDENTITY (1,1),
    TimeStamp                  DATETIME2    NOT NULL,
    TypeOfMobile               VARCHAR(250) NOT NULL,
    MMSI                       INT          NOT NULL,
    Latitude                   FLOAT        NOT NULL,
    Longitude                  FLOAT        NOT NULL,
    NavigationalStatus         VARCHAR(500) NOT NULL,
    RateOfTurn                 FLOAT            NULL,
    SpeedOverGround            FLOAT            NULL,
    CourseOverGround           FLOAT            NULL,
    Heading                    FLOAT            NULL,
    IMO                        VARCHAR(250) NOT NULL,
    Callsign                   VARCHAR(250) NOT NULL,
    Name                       VARCHAR(250) NOT NULL,
    ShipType                   VARCHAR(250) NOT NULL,
    CargoType                  VARCHAR(250) NOT NULL,
    Width                      VARCHAR(250) NOT NULL,
    Length                     VARCHAR(250) NOT NULL,
    TypeOfPositionFixingDevice VARCHAR(250) NOT NULL,
    Draught                    VARCHAR(250) NOT NULL,
    Destination                VARCHAR(250) NOT NULL,
    ETA                        VARCHAR(250)     NULL,
    DataSourceType             VARCHAR(250) NOT NULL,
    SizeA                      VARCHAR(250)     NULL,
    SizeB                      VARCHAR(250)     NULL,
    SizeC                      VARCHAR(250)     NULL,
    SizeD                      VARCHAR(250)     NULL
);

CREATE INDEX IDX_MMSI      ON AisData (MMSI);

CREATE INDEX IDX_TimeStamp ON AisData (TimeStamp);

CREATE INDEX IDX_Latitude  ON AisData (Latitude);

CREATE INDEX IDX_Longitude ON AisData (Longitude);