namespace SimulationInsight.SystemMessages;

public record RadarProfileDemand
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