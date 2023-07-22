namespace SimulationInsight.ScenarioGenerator;

public record FlightpathData
{
    public int FlightpathId
    {
        get; init;
    }

    public double Time
    {
        get; init;
    }

    public double LatitudeDeg
    {
        get; init;
    }

    public double LongitudeDeg
    {
        get; init;
    }

    public double Altitude
    {
        get; init;
    }

    public double PositionNorth
    {
        get; init;
    }

    public double PositionEast
    {
        get; init;
    }

    public double PositionDown
    {
        get; init;
    }

    public double VelocityNorth
    {
        get; init;
    }

    public double VelocityEast
    {
        get; init;
    }

    public double VelocityDown
    {
        get; init;
    }

    public double TotalSpeed
    {
        get; init;
    }

    public double TotalSpeed_kts
    {
        get; init;
    }

    public double GroundSpeed
    {
        get; init;
    }

    public double GroundSpeed_kts
    {
        get; init;
    }

    public double AccelerationNorth
    {
        get; init;
    }

    public double AccelerationEast
    {
        get; init;
    }

    public double AccelerationDown
    {
        get; init;
    }

    public double AccelerationAxial
    {
        get; init;
    }

    public double AccelerationLateral
    {
        get; init;
    }

    public double AccelerationVetical
    {
        get; init;
    }

    public double HeadingAngleDeg
    {
        get; init;
    }

    public double PitchAngleDeg
    {
        get; init;
    }

    public double BankAngleDeg
    {
        get; init;
    }

    public double HeadingRateDeg
    {
        get; init;
    }

    public double PitchRateDeg
    {
        get; init;
    }

    public double BankRateDeg
    {
        get; init;
    }
}