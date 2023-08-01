namespace SimulationInsight.Ais.Server;

public class AisServerSettings : IAisServerSettings
{
    public DateTime DateTimeStart
    {
        get;
        set;
    }

    public DateTime DateTimeEnd
    {
        get;
        set;
    }

    public double LatitudeMinDeg
    {
        get;
        set;
    }

    public double LatitudeMaxDeg
    {
        get;
        set;
    }

    public double LongitudeMinDeg
    {
        get;
        set;
    }

    public double LongitudeMaxDeg
    {
        get;
        set;
    }
}