namespace SimulationInsight.Simulation
{
    public interface ISimulationSettings
    {
        string SimulationName { get; set; }

        string SimulationDescription { get; set; }

        DateTime SimulationStartDateTime { get; set; }
    }
}