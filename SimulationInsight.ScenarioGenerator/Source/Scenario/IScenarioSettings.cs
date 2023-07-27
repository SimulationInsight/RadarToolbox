using SimulationInsight.MathLibrary;

namespace SimulationInsight.ScenarioGenerator;

public interface IScenarioSettings
{
    List<FlightpathSettings> FlightpathSettings
    {
        get;
        init;
    }
    ILLAOrigin LLAOrigin
    {
        get;
        init;
    }
}