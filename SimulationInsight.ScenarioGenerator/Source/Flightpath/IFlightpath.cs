namespace SimulationInsight.ScenarioGenerator;

public interface IFlightpath
{
    FlightpathData GetFlightpathData(double time);
}