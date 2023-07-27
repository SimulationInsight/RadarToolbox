namespace SimulationInsight.Radar;

public record TargetReport
{
    public int TargetReportId
    {
        get;
        set;
    }

    public int RadarId
    {
        get;
        set;
    }

    public int PlatformId
    {
        get;
        set;
    }

    public int Time
    {
        get;
        set;
    }

    public double Range
    {
        get;
        set;
    }

    public int RangeRate
    {
        get;
        set;
    }

    public int AzimuthAngle
    {
        get;
        set;
    }

    public int ElevationAngle
    {
        get;
        set;
    }

    public double RangeSd
    {
        get;
        set;
    }

    public double RangeRateSd
    {
        get;
        set;
    }

    public double AzimuthAngleSd
    {
        get;
        set;
    }

    public double ElevationAngleSd
    {
        get;
        set;
    }
}