namespace SimulationInsight.SystemMessages;

public record PulseParameters
{
    public int PulseId
    {
        get;
        set;
    }

    public int PulseStartTime
    {
        get;
        set;
    }

    public int PulsePower
    {
        get;
        set;
    }

    public int PulseWidth
    {
        get;
        set;
    }
}