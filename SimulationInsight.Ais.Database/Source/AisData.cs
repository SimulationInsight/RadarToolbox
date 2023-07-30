namespace SimulationInsight.Ais.Database;

public record AisData
{
    public int Id
    {
        get; set;
    }

    public DateTime TimeStamp
    {
        get; set;
    }

    public string TypeOfMobile
    {
        get; set;
    }

    public int MMSI
    {
        get; set;
    }

    public double Latitude
    {
        get; set;
    }

    public double Longitude
    {
        get; set;
    }

    public string NavigationalStatus
    {
        get; set;
    }

    public double? RateOfTurn
    {
        get; set;
    }

    public double? SpeedOverGround
    {
        get; set;
    }

    public double? CourseOverGround
    {
        get; set;
    }

    public double? Heading
    {
        get; set;
    }

    public string IMO
    {
        get; set;
    }

    public string Callsign
    {
        get; set;
    }

    public string Name
    {
        get; set;
    }

    public string ShipType
    {
        get; set;
    }

    public string CargoType
    {
        get; set;
    }

    public string Width
    {
        get; set;
    }

    public string Length
    {
        get; set;
    }

    public string TypeOfPositionFixingDevice
    {
        get; set;
    }

    public string Draught
    {
        get; set;
    }

    public string Destination
    {
        get; set;
    }

    public string ETA
    {
        get; set;
    }

    public string DataSourceType
    {
        get; set;
    }

    public string SizeA
    {
        get; set;
    }

    public string SizeB
    {
        get; set;
    }

    public string SizeC
    {
        get; set;
    }

    public string SizeD
    {
        get; set;
    }
}