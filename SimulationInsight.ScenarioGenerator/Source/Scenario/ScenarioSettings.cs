using SimulationInsight.MathLibrary;

namespace SimulationInsight.ScenarioGenerator;

public record ScenarioSettings
{
    public LLA LLAOrigin
    {
        get; init;
    }

    public List<FlightpathSettings> FlightpathSettings
    {
        get; init;
    }
}