namespace SimulationInsight.Ais.Server;

public interface IAisServerSettings
{
    DateTime DateTimeStart
    {
        get;
        set;
    }

    DateTime DateTimeEnd
    {
        get;
        set;
    }

    double LatitudeMinDeg
    {
        get;
        set;
    }

    double LatitudeMaxDeg
    {
        get;
        set;
    }

    double LongitudeMinDeg
    {
        get;
        set;
    }

    double LongitudeMaxDeg
    {
        get;
        set;
    }
}