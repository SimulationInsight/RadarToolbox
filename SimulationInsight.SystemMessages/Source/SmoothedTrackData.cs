namespace SimulationInsight.SystemMessages;

public record SmoothedTrackData
{
    public int RadarId
    {
        get;
        set;
    }

    public int TrackId
    {
        get;
        set;
    }

    public double LastUpdateTime
    {
        get;
        set;
    }

    public int NumberOfUpdates
    {
        get;
        set;
    }

    public double LatitudeDeg
    {
        get;
        set;
    }

    public double LongitudeDeg
    {
        get;
        set;
    }

    public double Altitude
    {
        get;
        set;
    }

    public double PositionNorth
    {
        get;
        set;
    }

    public double PositionEast
    {
        get;
        set;
    }

    public double PositionDown
    {
        get;
        set;
    }

    public double VelocityNorth
    {
        get;
        set;
    }

    public double VelocityEast
    {
        get;
        set;
    }

    public double VelocityDown
    {
        get;
        set;
    }

    public double Range
    {
        get;
        set;
    }

    public double RangeRate
    {
        get;
        set;
    }

    public double AzimuthAngleDeg
    {
        get;
        set;
    }

    public double AzimuthAngleRateDeg
    {
        get;
        set;
    }

    public double ElevationAngleDeg
    {
        get;
        set;
    }

    public double ElevationAngleRateDeg
    {
        get;
        set;
    }

    public double SlantRange
    {
        get;
        set;
    }

    public double HorizontalRange
    {
        get;
        set;
    }

    public double HeadingAngleDeg
    {
        get;
        set;
    }

    public double CourseOverGroundDeg
    {
        get;
        set;
    }

    public double SpeedOverGroundDeg
    {
        get;
        set;
    }
}