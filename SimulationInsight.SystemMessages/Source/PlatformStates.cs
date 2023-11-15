namespace SimulationInsight.SystemMessages;

public record PlatformStates
{
    public double PlatformTime
    {
        get;
        set;
    }

    public double PlatformId
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

    public double HeadingAngleDeg
    {
        get;
        set;
    }

    public double PitchAngleDeg
    {
        get;
        set;
    }

    public double BankAngleDeg
    {
        get;
        set;
    }
}