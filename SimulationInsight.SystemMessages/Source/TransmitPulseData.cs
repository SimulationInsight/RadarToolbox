namespace SimulationInsight.SystemMessages;

public record TransmitPulseData
{
    public double TransmitPulseTime
    {
        get; set;
    }

    public double TransmitPulseId
    {
        get; set;
    }

    public PlatformStates PlatformStates
    {
        get; set;
    }

    public RadarParameters RadarParameters
    {
        get; set;
    }

    public AntennnaParameters AntennnaParameters
    {
        get; set;
    }

    public PulseParameters PulseParameters
    {
        get;set;
    } 

}
