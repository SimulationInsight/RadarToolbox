namespace SimulationInsight.SystemMessages;

public record ScanControlData
{
    public double RadarId
    {
        get; 
        init;
    }

    public double Time
    {
        get; 
        init;
    }

    public double AzimuthScanRateDemand
    {
        get; 
        init;
    }
}