namespace SimulationInsight.SystemMessages;

public record AzimuthChangePulseData
{
    public double RadarId
    {
        get; init;
    }

    public double Time
    {
        get; init;
    }

    public int ScanIndex
    {
        get; init;
    }
}