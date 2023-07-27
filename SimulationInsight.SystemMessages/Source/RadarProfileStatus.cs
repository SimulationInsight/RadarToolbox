namespace SimulationInsight.SystemMessages;

public record RadarProfileStatus
{
    public double RadarId
    {
        get;
        init;
    }

    public string ProfileName
    {
        get;
        init;
    }
}