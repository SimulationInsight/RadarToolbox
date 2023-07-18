namespace SimulationInsight.Simulation
{
    public interface ISimulationSettings
    {
        string SimulationName { get; set; }

        string SimulationDescription { get; set; }

        DateTime SimulationStartDateTime { get; set; }

        double StartTime { get; set; }

        double EndTime { get; set; }

        double TimeStep { get; set; }
    }
}