namespace SimulationInsight.Radar;

public record ScanPattern
{
    public double RadarId { get; init; }

    public double ScanPatternType { get; init; }

    public double Time { get; init; }

    public double AzimuthScanRateDeg { get; init; }
}