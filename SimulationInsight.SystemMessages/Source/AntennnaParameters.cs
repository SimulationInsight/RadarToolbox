namespace SimulationInsight.SystemMessages;

public record AntennnaParameters
{
    public int AntennaId
    {
        get;
        set;
    }

    public int BeamPatternId
    {
        get;
        set;
    }

    public int BeamAzimuthDeg
    {
        get;
        set;
    }

    public int BeamElevationDeg
    {
        get;
        set;
    }
}