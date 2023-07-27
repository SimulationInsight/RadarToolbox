using SimulationInsight.MathLibrary;

namespace SimulationInsight.ScenarioGenerator;

public class ScenarioSettings : IScenarioSettings
{
    public ILLAOrigin LLAOrigin
    {
        get; init;
    }

    public List<FlightpathSettings> FlightpathSettings
    {
        get; init;
    }
}