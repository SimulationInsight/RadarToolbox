namespace SimulationInsight.Simulation;

public class SimulationSettings : ISimulationSettings
{
    public string SimulationName
    {
        get; set;
    }

    public string SimulationDescription
    {
        get; set;
    }

    public DateTime SimulationStartDateTime
    {
        get; set;
    }

    public double StartTime
    {
        get; set;
    }

    public double EndTime
    {
        get; set;
    }

    public double TimeStep
    {
        get; set;
    }
}