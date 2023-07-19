namespace SimulationInsight.SystemMessages;

public record ScanData
{
    public double RadarId { get; init; }

    public double Time { get; init; }

    public int ScanIndex { get; init; }

    public double AzimuthAngleDeg { get; init; }

    public double AzimuthAngleRateDeg { get; init; }

    public double ElevationAngleDeg { get; init; }

    public double ElevationAngleRateDeg { get; init; }
}